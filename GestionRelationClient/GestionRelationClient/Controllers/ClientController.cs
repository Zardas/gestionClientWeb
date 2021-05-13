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

        private readonly GestionRelationClient_DBContext _context;

        public ClientController(GestionRelationClient_DBContext context)
        {
            _context = context;
        }



        /* -------- ConnectClient -------- */
        [HttpGet]
        public IActionResult ConnectClient()
        {
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
                    Debug.WriteLine("Utilisateur connu :)");
                    utilisateurATrouver.Connexion();
                    _context.SaveChanges();


                    // On redirige différemment selon que l'on a trouvé un client, un gestionnaire ou un administrateur
                    Debug.WriteLine("Type : " + utilisateurATrouver.GetType());

                    switch(utilisateurATrouver.GetType().ToString())
                    {
                        case "GestionRelationClient.Models.Client":
                            return RedirectToAction("ListeComptesClient", new { ClientId = utilisateurATrouver.UtilisateurId });
                        case "GestionRelationClient.Models.Gestionnaire":
                            return RedirectToAction("InterfaceGestionnaire", "Gestionnaire", new { IdGestionnaire = utilisateurATrouver.UtilisateurId });
                        case "GestionRelationClient.Models.Administrateur":
                            return RedirectToAction("InterfaceAdministrateur", "Administrateur", utilisateurATrouver);
                        default:
                            return View();
                    }

                }
            }


            return View();
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
                return RedirectToAction("InscriptionClient");
            }

            return View();
        }






        /* -------- ListeComptesClient -------- */

        // TODO : passer cette méthode en POST pour ne plus avoir toutes les infos dans l'url ?
        [HttpGet]
        public IActionResult ListeComptesClient(int ClientId)
        {
            Debug.WriteLine("Id client fourni : " + ClientId);

            Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(ClientId)).FirstOrDefault();

            Debug.WriteLine("Login du client " + client.Login);

            List<Compte> comptes = _context.Comptes.Where(c => (c.ClientId.Equals(client.UtilisateurId))).ToList();


            ViewData["Client"] = client;
            return View(comptes);
        }

        [HttpPost]
        public IActionResult SelectionCompteClient(IFormCollection compte)
        {
            Debug.WriteLine("Sélection du compte numéro " + compte["IdCompte"]);

            Compte compteToFind = _context.Comptes.Where(c => (c.CompteId.Equals(Int32.Parse(compte["IdCompte"])))).FirstOrDefault();

            Debug.WriteLine("Envoi du compte : " + compteToFind.NomCompte);
            return RedirectToAction("InterfaceClient", new { CompteId = compteToFind.CompteId });
        }


        [HttpPost]
        public IActionResult AjoutCompteClient(IFormCollection nouveauCompte)
        {
            if(nouveauCompte["NomRole"] != "")
            {
                int idClient = Int32.Parse(nouveauCompte["Id"]);


                Client client = _context.Clients.Where(c => (c.UtilisateurId.Equals(idClient))).FirstOrDefault();

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
            
            return RedirectToAction("ConnectClient");
        }




        /* -------- ModificationCompteClient -------- */

        [HttpPost]
        public IActionResult ModificationCompteClient(IFormCollection clientPasse)
        {
            int clientId = Int32.Parse(clientPasse["ClientId"]);

            Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(clientId)).FirstOrDefault();

            // Tout ça aurait pû être directement géré dans Client.cs, mais je toruve plus propre de ne pas incorporé de bibliothèque http dans le modèle
            string Login;
            if(!clientPasse.ContainsKey("Login")) { 
                Login = "";
            } else
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
            else if(clientPasse["Age"] == "")
            {
                Age = 0;
            } else
            {
                Age = Int32.Parse(clientPasse["Age"]);
            }



            // Modification du compte avec les infos passé (s'il n'a pas rempli de champ, on ne modifie pas)
            client.ModifierProfil(Login, Mail, Nom, Prenom, MotDePasse, Telephone, Age);
            _context.SaveChanges();



            ViewData["Client"] = client;
            return View();
        }









        /* -------- IndexClient -------- */
        [HttpGet]
        public IActionResult InterfaceClient(int CompteId)
        {
            Compte compte = _context.Comptes.Where(c => c.CompteId.Equals(CompteId)).FirstOrDefault();

            Debug.WriteLine("Login du client " + compte.NomCompte);

            //ViewData["Compte"] = compte;
            return View(compte);
        }
    }
}
