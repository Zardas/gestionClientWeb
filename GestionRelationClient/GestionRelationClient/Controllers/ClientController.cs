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
        public IActionResult ConnectClient(Client client)
        {

            Client clientATrouver = _context.Clients.Where(c => (c.Login.Equals(client.Login) && c.MotDePasse.Equals(Utilitaire.HashPassword(client.MotDePasse)))).FirstOrDefault();

            if (clientATrouver != null)
            {
                Debug.WriteLine("Client connu :)");
                clientATrouver.SeConnecter();
                _context.SaveChanges();
                return RedirectToAction("ListeComptesClient");
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
        public IActionResult ListeComptesClient()
        {
            return View();
        }
    }
}
