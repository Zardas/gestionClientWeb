using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using GestionRelationClient.Models;

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

        [HttpGet]
        public IActionResult InscriptionClient()
        {
            //ObservableCollection<Models.Utilisateur> clients = Models.Utilitaire.ToObservableCollection<Models.Utilisateur>(this.DBContext.Utilisateurs);

            /*List<Models.Client> clients = new List<Models.Client>()
            {
                new Models.Client() { Nom = "Billy", Prenom = "TheKid" },
                new Models.Client() { Nom = "General", Prenom = "Draven" }
            };*/
            return View(_context.Roles.ToList());
        }
    }
}
