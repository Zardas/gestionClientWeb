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
                client.Inscrire(client.MotDePasse);
                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("InscriptionClient");
            }

            return View();
        }






        /* -------- ListeComptesClient -------- */

        [HttpGet]
        public IActionResult ListeComptesClient(Client client)
        {
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
            return RedirectToAction("IndexClient", compteToFind);
        }


        [HttpPost]
        public IActionResult AjoutCompteClient(IFormCollection nouveauRole)
        {
            if(nouveauRole["NomRole"] != "")
            {
                int idClient = Int32.Parse(nouveauRole["Id"]);

                Debug.WriteLine("Id : " + idClient);
                Debug.WriteLine("Nom nouveau rôle : " + nouveauRole["NomRole"]);

                Client client = _context.Clients.Where(c => (c.UtilisateurId.Equals(idClient))).FirstOrDefault();

                Compte compteATrouver = _context.Comptes.Where(c => (
                    c.ClientId.Equals(client.UtilisateurId) &&
                    c.NomCompte.Equals(nouveauRole["NomRole"])
                    )).FirstOrDefault();

                if (compteATrouver == null)
                {
                    Debug.WriteLine("Nouveau compte");

                    Compte newCompte = new Compte() { ClientId = client.UtilisateurId, DateCreation = System.DateTime.Now, NomCompte = nouveauRole["NomRole"] };
                    Debug.WriteLine("Id du client du nouveau compte : " + newCompte.ClientId);


                    client.AjouterCompte(newCompte);
                    _context.Comptes.Add(newCompte);
                    _context.SaveChanges();
                    return RedirectToAction("ListeComptesClient", client);
                }
            }
            
            return RedirectToAction("ConnectClient");
        }




        /* -------- IndexClient -------- */
        [HttpGet]
        public IActionResult IndexClient(Compte compte)
        {
            Debug.WriteLine("Login du client " + compte.NomCompte);

            //ViewData["Compte"] = compte;
            return View(compte);
        }
    }
}
