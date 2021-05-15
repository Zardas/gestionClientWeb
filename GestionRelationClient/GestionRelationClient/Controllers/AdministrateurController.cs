using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionRelationClient.Models;
using System.Diagnostics;

namespace GestionRelationClient.Controllers
{
    public class AdministrateurController : Controller
    {

        private readonly GestionRelationClient_DBContext _context;

        public AdministrateurController(GestionRelationClient_DBContext context)
        {
            _context = context;
        }

        /* -------- Interface adminisatrateur -------- */
        [HttpGet]
        public IActionResult InterfaceAdministrateur(int IdAdministrateur)
        {
            Debug.WriteLine("Connexion admin " + IdAdministrateur);
            Administrateur administrateur = _context.Administrateurs.Where(a => a.UtilisateurId.Equals(IdAdministrateur)).FirstOrDefault();

            return View(administrateur);
        }
    }
}
