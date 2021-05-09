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

        Models.GestionRelationClient_DBContext DBContext;
        private DbSet<Utilisateur> test;

        public ClientController()
        {
            this.DBContext = new Models.GestionRelationClient_DBContext();
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
            return View(DBContext.Utilisateurs.ToList());
        }
    }
}
