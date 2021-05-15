using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using GestionRelationClient.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace GestionRelationClient.Controllers
{
    public class ClientController : Controller
    {

        private int DureeSessionMinutes;

        private readonly GestionRelationClient_DBContext _context;

        public ClientController(GestionRelationClient_DBContext context)
        {
            DureeSessionMinutes = 2;
            _context = context;
        }


        // Retourne l'id du client associé à la session, si celle-ci est encore valide ; sinon, retourne 0;
        public int GetIdClient()
        {

            if (HttpContext.Session.GetInt32("ClientId") == null || HttpContext.Session.GetString("DateFinSession") == null)
            {
                return 0;
            }
            else
            {
                DateTime dateFin = Convert.ToDateTime(HttpContext.Session.GetString("DateFinSession"));
                DateTime dateActuelle = DateTime.Now;
                if (dateActuelle > dateFin)
                {
                    return 0;
                }

                return (int)HttpContext.Session.GetInt32("ClientId");
            }
        }

        /* -------- On a souvent besoin d'accéder au client -------- */
        public Client GetClient(int clientId)
        {
            return _context.Clients.Where(c => c.UtilisateurId.Equals(clientId)).FirstOrDefault();
        }

        public Client GetClient(string clientId)
        {
            return _context.Clients.Where(c => c.UtilisateurId.Equals(Int32.Parse(clientId))).FirstOrDefault();
        }






        // Retourne l'id du compte associé à la session, si celle-ci est encore valide ; sinon, retourne 0;
        public int GetIdCompte()
        {

            if (HttpContext.Session.GetInt32("CompteId") == null || HttpContext.Session.GetString("DateFinSession") == null)
            {
                return 0;
            }
            else
            {
                Debug.WriteLine("CompteId : " + HttpContext.Session.GetInt32("CompteId"));
                DateTime dateFin = Convert.ToDateTime(HttpContext.Session.GetString("DateFinSession"));
                DateTime dateActuelle = DateTime.Now;
                if (dateActuelle > dateFin)
                {
                    return 0;
                }

                return (int)HttpContext.Session.GetInt32("CompteId");
            }
        }

        /* -------- On a souvent besoin d'accéder au compte -------- */
        public Compte GetCompte(int compteId)
        {
            return _context.Comptes.Where(c => c.CompteId.Equals(compteId)).FirstOrDefault();
        }

        public Compte GetCompte(string compteId)
        {
            return _context.Comptes.Where(c => c.CompteId.Equals(Int32.Parse(compteId))).FirstOrDefault();
        }









        /* -------- ConnectClient -------- */
        [HttpGet]
        public IActionResult ConnectClient(bool erreurConnexion, bool sessionErreur, bool sessionExpiree)
        {
            // On supprime toutes les variables de sessions

            HttpContext.Session.Clear();
            if(erreurConnexion)
            {
                Debug.WriteLine("Erreur à la connexion");
            } else
            {
                Debug.WriteLine("Pas d'erreur à la connexion");
            }

            ViewData["sessionErreur"] = sessionErreur;
            ViewData["sessionExpiree"] = sessionExpiree;
            ViewData["ErreurConnexion"] = erreurConnexion;

            return View();
        }

        [HttpPost]
        public IActionResult ConnectClient(IFormCollection utilisateur)
        {

            if(utilisateur["Login"] != "" && utilisateur["MotDePasse"] != "")
            {
                Utilisateur utilisateurATrouver = _context.Utilisateurs.Where(c => (c.Login.Equals(utilisateur["Login"]) && c.MotDePasse.Equals(Utilitaire.HashPassword(utilisateur["MotDePasse"])))).FirstOrDefault();

                if (utilisateurATrouver != null)
                {
                    utilisateurATrouver.Connexion();
                    _context.SaveChanges();


                    // On redirige différemment selon que l'on a trouvé un client, un gestionnaire ou un administrateur
                    Debug.WriteLine("Type : " + utilisateurATrouver.GetType());

                    // On setup le moment où la session ne serra plus valide
                    HttpContext.Session.SetString("DateFinSession", DateTime.Now.AddMinutes(DureeSessionMinutes).ToString());

                    switch(utilisateurATrouver.GetType().ToString())
                    {
                        case "GestionRelationClient.Models.Client":

                            HttpContext.Session.SetInt32("ClientId", utilisateurATrouver.UtilisateurId);
                            return RedirectToAction("ListeComptesClient", "Client");

                        case "GestionRelationClient.Models.Gestionnaire":

                            HttpContext.Session.SetInt32("GestionnaireId", utilisateurATrouver.UtilisateurId);
                            return RedirectToAction("InterfaceGestionnaire", "Gestionnaire");

                        case "GestionRelationClient.Models.Administrateur":

                            HttpContext.Session.SetInt32("AdministrateurId", utilisateurATrouver.UtilisateurId);
                            return RedirectToAction("InterfaceAdministrateur", "Administrateur");

                        default:
                            return RedirectToAction("ConnectClient", "Client", new { erreurConnexion = true });
                    }

                }
            }

            return RedirectToAction("ConnectClient", "Client", new { erreurConnexion = true });
        }

        /* -------- ConnectClient -------- */
        [HttpGet]
        public IActionResult Deconnexion()
        {
            return RedirectToAction("ConnectClient", "Client", new { erreurConnexion = false });
        }








        /* -------- InscriptionClient -------- */
        [HttpGet]
        public IActionResult InscriptionClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InscriptionClient(Client client)
        {
            if(ModelState.IsValid)
            {
                // On choisit un gestionnaire au hasard à affecter au client
                List<Gestionnaire> gestionnaires = _context.Gestionnaires.ToList();

                Random rand = new Random();
                int index = rand.Next(gestionnaires.Count);

                Debug.WriteLine("Gestionnaire " + gestionnaires[index].NomGestionnaire + " choisi au hasard");
                client.GestionnaireAssocieId = gestionnaires[index].UtilisateurId;

                
                client.Inscrire(client.MotDePasse);

                gestionnaires[index].ClientsAssocies.Add(client);

                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("ConnectClient", "Client");
            }

            return View();
        }






        /* -------- ListeComptesClient -------- */

        // TODO : passer cette méthode en POST pour ne plus avoir toutes les infos dans l'url ?
        [HttpGet]
        public IActionResult ListeComptesClient()
        {
            // On vérifie que la session n'est pas expirée
            int ClientId = GetIdClient();
            if (ClientId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Client client = GetClient(ClientId);

                List<Compte> comptes = _context.Comptes.Where(c => (c.ClientId.Equals(client.UtilisateurId))).ToList();

                ViewData["Client"] = client;
                return View(comptes);
            }
        }

        [HttpPost]
        public IActionResult SelectionCompteClient(IFormCollection compte)
        {
            //Compte compteToFind = _context.Comptes.Where(c => (c.CompteId.Equals(Int32.Parse(compte["IdCompte"])))).FirstOrDefault();
            Compte compteToFind = GetCompte(compte["IdCompte"]);

            HttpContext.Session.SetInt32("CompteId", compteToFind.CompteId);
            return RedirectToAction("InterfaceClient", new { stringRecherchee = "" });
        }


        [HttpPost]
        public IActionResult AjoutCompteClient(IFormCollection nouveauCompte)
        {
            if(nouveauCompte["NomRole"] != "")
            {
                

                // On vérifie que la session n'est pas expirée
                int ClientId = GetIdClient();
                if (ClientId == 0)
                {
                    return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
                }
                else
                {
                    Client client = GetClient(ClientId);

                    Compte compteATrouver = _context.Comptes.Where(c => (
                        c.ClientId.Equals(client.UtilisateurId) &&
                        c.NomCompte.Equals(nouveauCompte["NomRole"])
                        )).FirstOrDefault();

                    if (compteATrouver == null)
                    {

                        Compte newCompte = new Compte() { ClientId = client.UtilisateurId, DateCreation = System.DateTime.Now, NomCompte = nouveauCompte["NomRole"] };
                        Panier newPanier = new Panier() { Compte = newCompte };

                        client.AjouterCompte(newCompte);

                        _context.Comptes.Add(newCompte);
                        _context.Paniers.Add(newPanier);
                        _context.SaveChanges();


                        return RedirectToAction("ListeComptesClient", new { ClientId = client.UtilisateurId });
                    }
                }
            }
            return RedirectToAction("ConnectClient");
        }




        /* -------- ModificationCompteClient -------- */

        [HttpPost]
        public IActionResult ModificationCompteClient(IFormCollection clientPasse)
        {
            // On vérifie que la session n'est pas expirée
            int ClientId = GetIdClient();
            if (ClientId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Client client = GetClient(ClientId);

                // Tout ça aurait pû être directement géré dans Client.cs, mais je toruve plus propre de ne pas incorporé de bibliothèque http dans le modèle
                string Login;
                if (!clientPasse.ContainsKey("Login"))
                {
                    Login = "";
                }
                else
                {
                    Login = clientPasse["Login"];
                }
                string Mail;
                if (!clientPasse.ContainsKey("Mail"))
                {
                    Mail = "";
                }
                else
                {
                    Mail = clientPasse["Mail"];
                }
                string Nom;
                if (!clientPasse.ContainsKey("Nom"))
                {
                    Nom = "";
                }
                else
                {
                    Nom = clientPasse["Nom"];
                }
                string Prenom;
                if (!clientPasse.ContainsKey("Prenom"))
                {
                    Prenom = "";
                }
                else
                {
                    Prenom = clientPasse["Prenom"];
                }
                string MotDePasse;
                if (!clientPasse.ContainsKey("MotDePasse"))
                {
                    MotDePasse = "";
                }
                else
                {
                    MotDePasse = clientPasse["MotDePasse"];
                }
                string Telephone;
                if (!clientPasse.ContainsKey("Telephone"))
                {
                    Telephone = "";
                }
                else
                {
                    Telephone = clientPasse["Telephone"];
                }
                int Age;
                if (!clientPasse.ContainsKey("Age"))
                {
                    Age = 0;
                }
                else if (clientPasse["Age"] == "")
                {
                    Age = 0;
                }
                else
                {
                    Age = Int32.Parse(clientPasse["Age"]);
                }



                // Modification du compte avec les infos passé (s'il n'a pas rempli de champ, on ne modifie pas)
                client.ModifierProfil(Login, Mail, Nom, Prenom, MotDePasse, Telephone, Age);
                _context.SaveChanges();



                ViewData["Client"] = client;
                return View();
            }
        }









        /* -------- IndexClient -------- */
        [HttpGet]
        public IActionResult InterfaceClient(string stringRecherchee, bool erreurSolde)
        {

            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);


                Panier panier = _context.Paniers.Where(p => p.CompteId.Equals(compte.CompteId)).FirstOrDefault();

                List<Article> articleDansPanier = _context.Articles.Where(a => a.PanierId.Equals(panier.PanierId)).ToList();

                List<Produit> produitsDisponibles = _context.Produits.Where(p => p.PanierId.Equals(1)).ToList();
                List<Service> servicesDisponibles = _context.Services.Where(s => s.PanierId.Equals(1)).ToList();



                // Le modèle est parfois incomplet après les redémarrage, donc mieux vaux calculer le total du panier direct dans le controller
                int totalPanier = 0;
                articleDansPanier.ForEach(a =>
                {
                    totalPanier += a.Prix;
                });


                // Si le client a précisé une string, on ne sort que les éléments dont le nom possède cette string
                if (!(String.IsNullOrEmpty(stringRecherchee) || String.IsNullOrWhiteSpace(stringRecherchee)))
                {

                    List<Article> articleDansPanier_newList = new List<Article>();
                    articleDansPanier.ForEach(article =>
                    {
                        if (article.Nom.ToLower().Contains(stringRecherchee.ToLower()))
                        {
                            articleDansPanier_newList.Add(article);
                        }
                    });
                    articleDansPanier = articleDansPanier_newList;

                    List<Produit> produitsDisponibles_newList = new List<Produit>();
                    produitsDisponibles.ForEach(article =>
                    {
                        if (article.Nom.ToLower().Contains(stringRecherchee.ToLower()))
                        {
                            produitsDisponibles_newList.Add(article);
                        }
                    });
                    produitsDisponibles = produitsDisponibles_newList;

                    List<Service> servicesDisponibles_newList = new List<Service>();
                    servicesDisponibles.ForEach(article =>
                    {
                        if (article.Nom.ToLower().Contains(stringRecherchee.ToLower()))
                        {
                            servicesDisponibles_newList.Add(article);
                        }
                    });
                    servicesDisponibles = servicesDisponibles_newList;
                }


                ViewData["Panier"] = articleDansPanier;
                ViewData["Produit"] = produitsDisponibles;
                ViewData["Service"] = servicesDisponibles;
                ViewData["PrixTotal"] = totalPanier;
                // Permet d'affiche un message d'erreur (utilisé si on a tenté de générer un facture avec un solde trop bas
                ViewData["ErreurSolde"] = erreurSolde;

                return View(compte);
            }
        }

        [HttpPost]
        public IActionResult InterfaceClient(IFormCollection recherche)
        {
            String stringRecherchee = recherche["StringRecherchee"];

            Debug.WriteLine("Post string recherchée : " + stringRecherchee);

            return RedirectToAction("InterfaceClient", new { stringRecherchee = stringRecherchee });
        }


        /* -------- Ajout article au panier -------- */
        [HttpPost]
        public IActionResult AjoutPanierArticle(IFormCollection articleEnvoye)
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                Panier panier = _context.Paniers.Where(p => p.CompteId.Equals(compte.CompteId)).FirstOrDefault();
                Article article = _context.Articles.Where(a => a.ArticleId.Equals(Int32.Parse(articleEnvoye["ArticleId"]))).FirstOrDefault();

                panier.AjoutArticle(article);
                _context.SaveChanges();

                return RedirectToAction("InterfaceClient", new { stringRecherchee = "" });
            }
        }

        /* -------- Ajout article au panier -------- */
        [HttpPost]
        public IActionResult EnlevementPanierArticle(IFormCollection articleEnvoye)
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                Panier panier = _context.Paniers.Where(p => p.CompteId.Equals(compte.CompteId)).FirstOrDefault();
                Article article = _context.Articles.Where(a => a.ArticleId.Equals(Int32.Parse(articleEnvoye["ArticleId"]))).FirstOrDefault();

                panier.SupprimerPanierArticle(article);
                _context.SaveChanges();

                return RedirectToAction("InterfaceClient", new { stringRecherchee = "" });
            }
        }

        [HttpPost]
        public IActionResult GenererFacture(IFormCollection factureGeneration)
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                Panier panier = _context.Paniers.Where(p => p.CompteId.Equals(compte.CompteId)).FirstOrDefault();
                Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(compte.ClientId)).FirstOrDefault();

                List<Article> articlesDansPanier = _context.Articles.Where(a => a.PanierId.Equals(panier.PanierId)).ToList();
            

                int montantTotal = 0;
                articlesDansPanier.ForEach(article =>
                {
                    montantTotal += article.Prix;
                });


                if (montantTotal > client.Solde)
                {
                    return RedirectToAction("InterfaceClient", new { stringRecherchee = "", erreurSolde = true });
                }
                else
                {
                    Facture facture = new Facture()
                    {
                        Compte = compte,
                        DateEmission = DateTime.Now,
                        Montant = montantTotal
                    };
                    _context.Factures.Add(facture);

                    // On retire les articles du panier
                    articlesDansPanier.ForEach(article =>
                    {
                        panier.SupprimerPanierArticle(article);
                        _context.Articles.Remove(article);
                    });

                    // Le gestionnaire associé gagne 15% du montant total
                    Gestionnaire gestionnaireAssocie = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(client.GestionnaireAssocieId)).FirstOrDefault();
                    gestionnaireAssocie.ajoutFacture(facture);

                    // On réduit évidemment le solde du client
                    client.GenererFacture(facture);

                    _context.SaveChanges();

                    return RedirectToAction("InterfaceClient", new { stringRecherchee = "" });
                }
            }

        }



        /* -------- Accéder aux détails d'un article -------- */
        [HttpGet]
        public IActionResult DetailsArticle(int ArticleId)
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Article article = _context.Articles.Where(a => a.ArticleId.Equals(ArticleId)).FirstOrDefault();

                switch (article.GetType().ToString())
                {

                    case "GestionRelationClient.Models.Produit":
                        return RedirectToAction("DetailsProduit", new { ArticleId = ArticleId });
                    case "GestionRelationClient.Models.Service":
                        return RedirectToAction("DetailsService", new { ArticleId = ArticleId });
                    default:
                        return RedirectToAction("InterfaceClient", new { stringRecherchee = "" });
                }
            }
        }
        [HttpGet]
        public IActionResult DetailsProduit(int ArticleId)
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                Produit article = _context.Produits.Where(p => p.ArticleId.Equals(ArticleId)).FirstOrDefault();

                ViewData["Produit"] = article;

                // On indique à la vue si le produit peut être acheté pour qu'elle affiche ou non le bouton d'achat
                Panier panier = _context.Paniers.Where(p => p.CompteId.Equals(compte.CompteId)).FirstOrDefault();
                ViewData["PeutEtreAchete"] = !(article.PanierId.Equals(panier.PanierId));

                return View(compte);
            }
        }
        [HttpGet]
        public IActionResult DetailsService(int ArticleId)
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                Service article = _context.Services.Where(s => s.ArticleId.Equals(ArticleId)).FirstOrDefault();

                ViewData["Service"] = article;

                // On indique à la vue si le service peut être acheté pour qu'elle affiche ou non le bouton d'achat
                Panier panier = _context.Paniers.Where(p => p.CompteId.Equals(compte.CompteId)).FirstOrDefault();
                ViewData["PeutEtreAchete"] = !(article.PanierId.Equals(panier.PanierId));

                // On passe aussi la durée de l'abonnement à la vue s'il existe
                Abonnement abonnement = _context.Abonnements.Where(a => a.AbonnementId.Equals(article.AbonnementId)).FirstOrDefault();
                ViewData["DureeAbonnement"] = abonnement.DureeAbonnement;

                return View(compte);
            }
        }











        /* -------- Accéder au solde -------- */
        [HttpGet]
        public IActionResult SoldeClient()
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(compte.ClientId)).FirstOrDefault();

                ViewData["Client"] = client;

                return View(compte);
            }
        }
        [HttpPost]
        public IActionResult SoldeClient(IFormCollection ajout)
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(compte.ClientId)).FirstOrDefault();

                client.AjoutSolde(Int32.Parse(ajout["Montant"]));
                _context.SaveChanges();

                return RedirectToAction("SoldeClient");
            }
        }





        /* -------- Liste des factures -------- */
        [HttpGet]
        public IActionResult ListeFactures()
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                List<Facture> factures = _context.Factures.Where(f => f.CompteId.Equals(compte.CompteId)).ToList();

                ViewData["Factures"] = factures;
                return View(compte);
            }
        }






        [HttpGet]
        public IActionResult OuvrirTicketSupport(int ArticleId)
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                Article article = _context.Articles.Where(a => a.ArticleId.Equals(ArticleId)).FirstOrDefault();

                ViewData["Article"] = article;

                return View(compte);
            }
        }

        [HttpPost]
        public IActionResult AjouterTicketSupport(IFormCollection ticketAouvrir)
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                int ArticleId = Int32.Parse(ticketAouvrir["ArticleId"]);
                Article article = _context.Articles.Where(a => a.ArticleId.Equals(ArticleId)).FirstOrDefault();


                Support support = new Support(article)
                {
                    Objet = ticketAouvrir["Objet"],
                    Description = ticketAouvrir["Description"],
                    DateCreation = DateTime.Now,
                    Compte = compte,
                };
                _context.Supports.Add(support);
                _context.SaveChanges();

                return RedirectToAction("InterfaceClient", new { stringRecherchee = "" });
            }
        }




        [HttpGet]
        public IActionResult ListeTicketsClient()
        {
            // On vérifie que la session n'est pas expirée
            int CompteId = GetIdCompte();
            if (CompteId == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Compte compte = GetCompte(CompteId);

                List<Support> supports = _context.Supports.Where(s => s.CompteId.Equals(CompteId)).ToList();

                ViewData["Supports"] = supports;
                return View(compte);
            }
        }
    }
}
