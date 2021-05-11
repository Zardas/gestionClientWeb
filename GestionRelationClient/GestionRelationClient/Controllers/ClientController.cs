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

        [HttpGet]
        public IActionResult ConnectClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConnectClient(IFormCollection client)
        {

            if(client["Login"] != "" && client["MotDePasse"] != "")
            {
                Client clientATrouver = _context.Clients.Where(c => (c.Login.Equals(client["Login"]) && c.MotDePasse.Equals(Utilitaire.HashPassword(client["MotDePasse"])))).FirstOrDefault();

                if (clientATrouver != null)
                {
                    Debug.WriteLine("Client connu :)");
                    clientATrouver.SeConnecter();
                    _context.SaveChanges();
                    return RedirectToAction("ListeComptesClient", clientATrouver);
                }
            }


            return View();
        }











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
                client.Inscrire(client.MotDePasse);
                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("InscriptionClient");
            }

            return View();
        }

        


        [HttpGet]
        public IActionResult ListeComptesClient(Client client)
        {
            Debug.WriteLine("Login liste comptes client : " + client.Login);
            ViewData["Client"] = client;
            return View();
        }

        [HttpPost]
        public IActionResult AjoutCompteClient(IFormCollection nouveauRole)
        {
            int idClient = Int32.Parse(nouveauRole["Id"]);

            Debug.WriteLine("Id : " + idClient);
            Debug.WriteLine("Nom nouveau rôle : " + nouveauRole["NomRole"]);

            Client client = _context.Clients.Where(c => (c.UtilisateurId.Equals(idClient))).FirstOrDefault();

            Compte compteATrouver = _context.Comptes.Where(c => (
                c.ClientId.Equals(client.UtilisateurId) &&
                c.NomCompte.Equals(nouveauRole["NomRole"])
                )).FirstOrDefault();

            if(compteATrouver == null)
            {
                Debug.WriteLine("Nouveau compte");

                Compte newCompte = new Compte() { ClientId = client.UtilisateurId, DateCreation = System.DateTime.Now, NomCompte = nouveauRole["NomRole"] };
                Debug.WriteLine("Id du client du nouveau compte : " + newCompte.ClientId);


                client.AjouterCompte(newCompte);
                _context.Comptes.Add(newCompte);
                _context.SaveChanges();
                return RedirectToAction("ListeComptesClient", client);
            }

            return RedirectToAction("ConnectClient");
        }
    }
}
