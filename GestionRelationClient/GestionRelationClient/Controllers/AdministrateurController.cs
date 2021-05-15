using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionRelationClient.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace GestionRelationClient.Controllers
{
    public class AdministrateurController : Controller
    {

        private readonly GestionRelationClient_DBContext _context;

        public AdministrateurController(GestionRelationClient_DBContext context)
        {
            _context = context;
        }


        // Retourne l'id de l'administrateur associé à la session, si celle-ci est encore valide ; sinon, retourne 0;
        public int GetIdAdministrateur()
        {

            if (HttpContext.Session.GetInt32("AdministrateurId") == null || HttpContext.Session.GetString("DateFinSession") == null)
            {
                return 0;
            } else
            {
                DateTime dateFin = Convert.ToDateTime(HttpContext.Session.GetString("DateFinSession"));
                DateTime dateActuelle = DateTime.Now;
                if(dateActuelle > dateFin)
                {
                    return 0;
                }

                return (int)HttpContext.Session.GetInt32("AdministrateurId");
            }
        }


        public Administrateur GetAdministrateur(int administrateurId)
        {
            return _context.Administrateurs.Where(a => a.UtilisateurId.Equals(administrateurId)).FirstOrDefault();
        }

        public Administrateur GetAdministrateur(string administrateurId)
        {
            return _context.Administrateurs.Where(a => a.UtilisateurId.Equals(Int32.Parse(administrateurId))).FirstOrDefault();
        }

        /* -------- Interface adminisatrateur -------- */
        [HttpGet]
        public IActionResult InterfaceAdministrateur()
        {

            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if(IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            } else
            {
                Administrateur administrateur = GetAdministrateur(IdAdministrateur);

                List<Client> clients = _context.Clients.ToList();
                List<Gestionnaire> gestionnaires = _context.Gestionnaires.ToList();

                // On supprime le client par défaut
                Client clientDefaut = _context.Clients.Where(c => c.Login.Equals("ClientDefaut")).FirstOrDefault();
                clients.Remove(clientDefaut);

                ViewData["Clients"] = clients;
                ViewData["Gestionnaires"] = gestionnaires;

                return View(administrateur);
            }
            
        }





        /* -------- Ajout de clients -------- */
        [HttpGet]
        public IActionResult AjoutClient()
        {
            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if (IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Administrateur administrateur = GetAdministrateur(IdAdministrateur);

                return View(administrateur);
            }
        }
        /* -------- Ajouter un client -------- */
        [HttpPost]
        public IActionResult AjoutClient(IFormCollection client)
        {
            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if (IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Administrateur administrateur = GetAdministrateur(IdAdministrateur);

                Client clientAajouter = new Client()
                {
                    Login = client["Login"],
                    Mail = client["Mail"],
                    Nom = client["Nom"],
                    Prenom = client["Prenom"],
                    Telephone = client["Telephone"],
                    Age = Int32.Parse(client["Age"])
                };

                // On choisit un gestionnaire au hasard à affecter au client
                List<Gestionnaire> gestionnaires = _context.Gestionnaires.ToList();

                Random rand = new Random();
                int index = rand.Next(gestionnaires.Count);

                Debug.WriteLine("Gestionnaire " + gestionnaires[index].NomGestionnaire + " choisi au hasard");
                clientAajouter.GestionnaireAssocieId = gestionnaires[index].UtilisateurId;


                clientAajouter.Inscrire(client["MotDePasse"]);

                gestionnaires[index].ClientsAssocies.Add(clientAajouter);

                _context.Clients.Add(clientAajouter);
                _context.SaveChanges();

                return RedirectToAction("InterfaceAdministrateur", "Administrateur");
            }
        }
        /* -------- Modification d'un client -------- */
        [HttpGet]
        public IActionResult ModificationClient(int ClientId)
        {
            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if (IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Administrateur administrateur = GetAdministrateur(IdAdministrateur);

                Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(ClientId)).FirstOrDefault();

                ViewData["Client"] = client;

                return View(administrateur);
            }
        }
        [HttpPost]
        public IActionResult ModificationClient(IFormCollection clientEnvoye)
        {
            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if (IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                int ClientId = Int32.Parse(clientEnvoye["ClientId"]);

                Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(ClientId)).FirstOrDefault();

                client.Login = clientEnvoye["Login"];
                client.Mail = clientEnvoye["Mail"];
                client.Nom = clientEnvoye["Nom"];
                client.Prenom = clientEnvoye["Prenom"];
                client.Telephone = clientEnvoye["Telephone"];
                client.Age = Int32.Parse(clientEnvoye["Age"]);

                _context.SaveChanges();

                return RedirectToAction("InterfaceAdministrateur", "Administrateur");
            }
        }

        /* -------- Suppression d'un client -------- */
        [HttpPost]
        public IActionResult SuppressionClient(IFormCollection clientASupprimer)
        {
            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if (IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {

                Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(Int32.Parse(clientASupprimer["ClientId"]))).FirstOrDefault();

                _context.Clients.Remove(client);
                _context.SaveChanges();

                return RedirectToAction("InterfaceAdministrateur", "Administrateur");
            }
        }







        /* -------- Ajout de gestionnaire -------- */
        [HttpGet]
        public IActionResult AjoutGestionnaire()
        {
            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if (IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Administrateur administrateur = GetAdministrateur(IdAdministrateur);

                List<Role> roles = _context.Roles.ToList();
                List<Stock> stocks = _context.Stocks.ToList();

                ViewData["Roles"] = roles;
                ViewData["Stocks"] = stocks;

                return View(administrateur);
            }
        }
        /* -------- Ajouter un gestionnaire -------- */
        //[HttpPost]
        public IActionResult AjoutGestionnaire(IFormCollection gestionnaire)
        {
            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if (IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {

                Role role = _context.Roles.Where(r => r.RoleId.Equals(Int32.Parse(gestionnaire["Role"]))).FirstOrDefault();

                Stock stock = new Stock()
                {
                    Titre = gestionnaire["Stock"]
                };

                Gestionnaire gestionnaireAajouter = new Gestionnaire()
                {
                    Login = gestionnaire["Login"],
                    Email = gestionnaire["Email"],
                    NomGestionnaire = gestionnaire["Nom"],
                    MotDePasse = Utilitaire.HashPassword(gestionnaire["MotDePasse"]),
                    Role = role,
                    Stock = stock
                };

                _context.Stocks.Add(stock);
                _context.Gestionnaires.Add(gestionnaireAajouter);
                _context.SaveChanges();

                return RedirectToAction("InterfaceAdministrateur", "Administrateur");
            }
        }


        /* -------- Modification d'un gestionnaire -------- */
        [HttpGet]
        public IActionResult ModificationGestionnaire(int GestionnaireId)
        {
            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if (IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {
                Administrateur administrateur = GetAdministrateur(IdAdministrateur);

                Gestionnaire gestionnaire = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(GestionnaireId)).FirstOrDefault();

                List<Role> roles = _context.Roles.ToList();

                ViewData["Gestionnaire"] = gestionnaire;
                ViewData["Roles"] = roles;

                return View(administrateur);
            }
        }
        [HttpPost]
        public IActionResult ModificationGestionnaire(IFormCollection gestionnaireEnvoye)
        {
            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if (IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {

                int GestionnaireId = Int32.Parse(gestionnaireEnvoye["GestionnaireId"]);

                Gestionnaire gestionnaire = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(GestionnaireId)).FirstOrDefault();

                Role roleChoisi = _context.Roles.Where(r => r.RoleId.Equals(Int32.Parse(gestionnaireEnvoye["Role"]))).FirstOrDefault();

                gestionnaire.Login = gestionnaireEnvoye["Login"];
                gestionnaire.Email = gestionnaireEnvoye["Email"];
                gestionnaire.NomGestionnaire = gestionnaireEnvoye["Nom"];
                gestionnaire.Role = roleChoisi;

                _context.SaveChanges();

                return RedirectToAction("InterfaceAdministrateur", "Administrateur");
            }
        }

        /* -------- Suppression d'un gestionnaire -------- */
        [HttpPost]
        public IActionResult SuppressionGestionnaire(IFormCollection gestionnaireAsupprimer)
        {
            // On vérifie que la session fonctionne
            int IdAdministrateur = GetIdAdministrateur();
            if (IdAdministrateur == 0)
            {
                return RedirectToAction("ConnectClient", "Client", new { sessionExpiree = true });
            }
            else
            {

                Gestionnaire gestionnaire = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(Int32.Parse(gestionnaireAsupprimer["GestionnaireId"]))).FirstOrDefault();


                // On doit aussi affecter un nouveau gestionnaire à tout les client qui lui était précédemment affectés
                List<Client> clientsAssocies = _context.Clients.Where(c => c.GestionnaireAssocieId.Equals(gestionnaire.UtilisateurId)).ToList();

                List<Gestionnaire> autresGestionnaires = _context.Gestionnaires.Where(g => !(g.UtilisateurId.Equals(gestionnaire.UtilisateurId))).ToList();

                clientsAssocies.ForEach(client =>
                {
                    Random rand = new Random();
                    int index = rand.Next(autresGestionnaires.Count);

                    Debug.WriteLine("Gestionnaire " + autresGestionnaires[index].NomGestionnaire + " choisi au hasard");
                    client.GestionnaireAssocieId = autresGestionnaires[index].UtilisateurId;

                    autresGestionnaires[index].ClientsAssocies.Add(client);
                });


                _context.Gestionnaires.Remove(gestionnaire);
                _context.SaveChanges();

                return RedirectToAction("InterfaceAdministrateur", "Administrateur");
            }
        }
    }
}
