using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionRelationClient.Models;
using System.Diagnostics;

namespace GestionRelationClient.Controllers
{
    public class GestionnaireController : Controller
    {

        private readonly GestionRelationClient_DBContext _context;

        public GestionnaireController(GestionRelationClient_DBContext context)
        {
            _context = context;
        }

        // Retourne l'id du gestionaire associé à la session, si celle-ci est encore valide ; sinon, retourne 0;
        public int GetIdGestionnaire()
        {

            if (HttpContext.Session.GetInt32("GestionnaireId") == null || HttpContext.Session.GetString("DateFinSession") == null)
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

                return (int)HttpContext.Session.GetInt32("GestionnaireId");
            }
        }

        public Gestionnaire getGestionnaire(int gestionnaireId)
        {
            return _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(gestionnaireId)).FirstOrDefault();
        }

        public Gestionnaire getGestionnaire(string gestionnaireId)
        {
            return _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(Int32.Parse(gestionnaireId))).FirstOrDefault();
        }

        /* -------- ConnectGestionnaire -------- */
        [HttpGet]
        public IActionResult InterfaceGestionnaire()
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);


                // On récupère la liste des clients associés pour pouvoir l'afficher
                List<Client> clientsAssocies = _context.Clients.Where(c => c.GestionnaireAssocieId.Equals(gestionnaire.UtilisateurId)).ToList();
                gestionnaire.ClientsAssocies = clientsAssocies;

                // On récupère la liste des produits associés pour pouvoir l'afficher
                List<Produit> produits = _context.Produits.Where(p => p.StockId.Equals(gestionnaire.StockId)).ToList();
                ViewData["ProduitsAssocies"] = produits;

                // On récupère la liste des services pour pouvoir l'afficher
                List<Service> services = _context.Services.ToList();
                ViewData["Services"] = services;

                return View(gestionnaire);
            }
        }



        /* -------- Désassociation client associé -------- */
        [HttpPost]
        public IActionResult SuppressionClientAssocie(IFormCollection clientASupprimer)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                // On récupère le client à supprimer
                Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(Int32.Parse(clientASupprimer["IdClient"]))).FirstOrDefault();

                Debug.WriteLine("Id du client trouvé : " + client.UtilisateurId);


                client.GestionnaireAssocieId = 0;
                _context.SaveChanges();


                return RedirectToAction("InterfaceGestionnaire", "Gestionnaire");
            }
        }


        /* -------- Liste des clients à associer -------- */
        [HttpGet]
        public IActionResult AjoutClientAssocie()
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);

                List<Client> clientsDisponibles = _context.Clients.Where(c => !(c.GestionnaireAssocieId.Equals(gestionnaire.UtilisateurId))).ToList();

                ViewData["clientsDisponibles"] = clientsDisponibles;
                return View(gestionnaire);
            }
        }

        /* -------- Ajout client à associer -------- */
        [HttpPost]
        public IActionResult AjoutClientAssocie(IFormCollection clientAajouter)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);

                Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(Int32.Parse(clientAajouter["IdClient"]))).FirstOrDefault();


                client.GestionnaireAssocieId = gestionnaire.UtilisateurId;
                _context.SaveChanges();

                Debug.WriteLine("Client " + client.Nom + " à associer à " + gestionnaire.NomGestionnaire);
                return RedirectToAction("AjoutClientAssocie", "Gestionnaire");
            }
        }












        /* -------- Formulaire pour ajouter un produit -------- */
        [HttpGet]
        public IActionResult AjouterProduit()
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);

                return View(gestionnaire);
            }
        }

        /* -------- Ajouter un produit -------- */
        [HttpPost]
        public IActionResult AjouterProduit(IFormCollection produit)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);

                // Un produit n'est pas lié à un abonnement
                Abonnement abonnementNul = _context.Abonnements.Where(a => a.AbonnementId.Equals(1)).FirstOrDefault();

                Produit produitAajouter = new Produit()
                {
                    Nom = produit["Nom"],
                    Image = produit["Image"],
                    Fabricant = produit["Fabricant"],
                    Type = produit["Type"],
                    Prix = Int32.Parse(produit["Prix"]),
                    Quantite = Int32.Parse(produit["Quantite"]),
                    Capacite = Int32.Parse(produit["Capacite"]),
                    Description = produit["Description"],
                    Manuel = produit["Manuel"],
                    StockId = gestionnaire.StockId,
                    Abonnement = abonnementNul,
                    PanierId = 1 // Le panier nul
                };

                _context.Produits.Add(produitAajouter);
                _context.SaveChanges();

                return RedirectToAction("AjouterProduit", "Gestionnaire");
            }
        }

        /* -------- Réduire de 1 la quantité un produit -------- */
        [HttpPost]
        public IActionResult SuppressionProduit(IFormCollection produitEnvoye)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Produit produit = _context.Produits.Where(p => p.ArticleId.Equals(Int32.Parse(produitEnvoye["ProduitId"]))).FirstOrDefault();

                produit.Quantite--;
                if (produit.Quantite <= 0)
                {
                    _context.Produits.Remove(produit);
                }
                _context.SaveChanges();

                return RedirectToAction("InterfaceGestionnaire", "Gestionnaire");
            }
        }



        /* -------- Modification du produit -------- */
        [HttpGet]
        public IActionResult ModificationProduit(int ProduitId)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);

                Produit produit = _context.Produits.Where(p => p.ArticleId.Equals(ProduitId)).FirstOrDefault();
                ViewData["Produit"] = produit;

                return View(gestionnaire);
            }
        }
        [HttpPost]
        public IActionResult ModifierProduit(IFormCollection produitAmodifier)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Produit produit = _context.Produits.Where(p => p.ArticleId.Equals(Int32.Parse(produitAmodifier["ProduitId"]))).FirstOrDefault();

                produit.Nom = produitAmodifier["Nom"];
                produit.Image = produitAmodifier["Image"];
                produit.Fabricant = produitAmodifier["Fabricant"];
                produit.Type = produitAmodifier["Type"];
                produit.Prix = Int32.Parse(produitAmodifier["Prix"]);
                produit.Quantite = Int32.Parse(produitAmodifier["Quantite"]);
                produit.Capacite = Int32.Parse(produitAmodifier["Capacite"]);
                produit.Description = produitAmodifier["Description"];
                produit.Manuel = produitAmodifier["Manuel"];

                _context.SaveChanges();

                return RedirectToAction("InterfaceGestionnaire", "Gestionnaire");
            }
        }
















        /* -------- Formulaire pour ajouter un service -------- */
        [HttpGet]
        public IActionResult AjouterService()
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);

                List<Abonnement> abonnements = _context.Abonnements.ToList();
                ViewData["Abonnements"] = abonnements;

                return View(gestionnaire);
            }
        }

        /* -------- Ajouter un service -------- */
        [HttpPost]
        public IActionResult AjouterService(IFormCollection service)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);


                Abonnement abonnement;
                // Un abonnement peut ou non être lié à un abonnement
                if (service["AbonnementAssocie"] == "on")
                {
                    Debug.WriteLine("Abonnement choisi id : " + service["Abonnement"]);
                    abonnement = _context.Abonnements.Where(a => a.AbonnementId.Equals(Int32.Parse(service["Abonnement"]))).FirstOrDefault();
                    Debug.WriteLine("Abonnement choisi durée " + abonnement.DureeAbonnement);
                }
                else
                {
                    Debug.WriteLine("Aucun abonnement choisi");
                    abonnement = _context.Abonnements.Where(a => a.AbonnementId.Equals(1)).FirstOrDefault();
                }

                Service serviceAajouter = new Service()
                {
                    Nom = service["Nom"],
                    Image = service["Image"],
                    Type = service["Type"],
                    Prix = Int32.Parse(service["Prix"]),
                    Description = service["Description"],
                    Manuel = service["Manuel"],
                    Conditions = service["Conditions"],
                    Abonnement = abonnement,
                    PanierId = 1 // Le panier nul
                };

                _context.Services.Add(serviceAajouter);
                _context.SaveChanges();

                return RedirectToAction("AjouterService", "Gestionnaire");
            }
        }

        /* -------- Supprimer un service -------- */
        [HttpPost]
        public IActionResult SuppressionService(IFormCollection serviceEnvoye)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Service service = _context.Services.Where(p => p.ArticleId.Equals(Int32.Parse(serviceEnvoye["ServiceId"]))).FirstOrDefault();

                _context.Services.Remove(service);
                _context.SaveChanges();

                return RedirectToAction("InterfaceGestionnaire", "Gestionnaire");
            }
        }


        /* -------- Modification du service -------- */
        [HttpGet]
        public IActionResult ModificationService(int ServiceId)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);

                Service service = _context.Services.Where(s => s.ArticleId.Equals(ServiceId)).FirstOrDefault();
                ViewData["Service"] = service;

                List<Abonnement> abonnements = _context.Abonnements.ToList();
                ViewData["Abonnements"] = abonnements;

                return View(gestionnaire);
            }
        }
        [HttpPost]
        public IActionResult ModifierService(IFormCollection serviceAmodifier)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {

                Service service = _context.Services.Where(s => s.ArticleId.Equals(Int32.Parse(serviceAmodifier["ServiceId"]))).FirstOrDefault();

                service.Nom = serviceAmodifier["Nom"];
                service.Image = serviceAmodifier["Image"];
                service.Type = serviceAmodifier["Type"];
                service.Prix = Int32.Parse(serviceAmodifier["Prix"]);
                service.Description = serviceAmodifier["Description"];
                service.Manuel = serviceAmodifier["Manuel"];
                service.Conditions = serviceAmodifier["Conditions"];

                // Un abonnement peut ou non être lié à un abonnement
                if (serviceAmodifier["AbonnementAssocie"] == "on")
                {
                    service.Abonnement = _context.Abonnements.Where(a => a.AbonnementId.Equals(Int32.Parse(serviceAmodifier["Abonnement"]))).FirstOrDefault();
                }
                else
                {
                    service.Abonnement = _context.Abonnements.Where(a => a.AbonnementId.Equals(1)).FirstOrDefault();
                }
                _context.SaveChanges();

                return RedirectToAction("InterfaceGestionnaire", "Gestionnaire");
            }
        }
















        /* -------- Formulaire pour ajouter un abonnement -------- */
        [HttpGet]
        public IActionResult AjouterAbonnement()
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);

                return View(gestionnaire);
            }
        }
        /* -------- Ajout d'un abonnement -------- */
        [HttpPost]
        public IActionResult AjouterAbonnement(IFormCollection abonnementEnvoye)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {

                Abonnement abonnement = new Abonnement()
                {
                    DureeAbonnement = Int32.Parse(abonnementEnvoye["Duree"])
                };
                _context.Abonnements.Add(abonnement);
                _context.SaveChanges();

                return RedirectToAction("InterfaceGestionnaire", "Gestionnaire");
            }
        }







        [HttpGet]
        public IActionResult ListeTicketsGestionnaire()
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Gestionnaire gestionnaire = getGestionnaire(IdGestionnaire);


                List<Client> clients = _context.Clients.Where(c => c.GestionnaireAssocieId.Equals(gestionnaire.UtilisateurId)).ToList();

                // Liste de tout les comptes associés
                List<Compte> comptes = new List<Compte>();
                clients.ForEach(client =>
                {
                    List<Compte> comptesDuClient = _context.Comptes.Where(c => c.ClientId.Equals(client.UtilisateurId)).ToList();
                    comptesDuClient.ForEach(compte =>
                    {
                        comptes.Add(compte);
                    });

                });


                List<Support> supportsAssocies = new List<Support>();

                comptes.ForEach(compte =>
                {
                    List<Support> supports = _context.Supports.Where(s => s.CompteId.Equals(compte.CompteId)).ToList();

                    supports.ForEach(support =>
                    {
                        supportsAssocies.Add(support);
                    });

                });

                ViewData["Supports"] = supportsAssocies;

                return View(gestionnaire);
            }
        }

        [HttpPost]
        public IActionResult ResoudreTicket(IFormCollection resolutionEnvoyee)
        {
            // On vérifie que la session n'est pas expirée
            int IdGestionnaire = GetIdGestionnaire();
            if (IdGestionnaire == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {

                int GestionnaireId = Int32.Parse(resolutionEnvoyee["GestionnaireId"]);
                int SupportId = Int32.Parse(resolutionEnvoyee["SupportId"]);

                Debug.WriteLine("Résolution du ticket n°" + SupportId);

                Support support = _context.Supports.Where(s => s.SupportId.Equals(SupportId)).FirstOrDefault();

                support.Resoudre(resolutionEnvoyee["Resolution"]);
                _context.SaveChanges();

                return RedirectToAction("ListeTicketsGestionnaire", "Gestionnaire");
            }
        }
    }
}
