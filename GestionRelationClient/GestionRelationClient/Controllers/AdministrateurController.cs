using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionRelationClient.Models;

namespace GestionRelationClient.Controllers
{
    public class AdministrateurController : Controller
    {
        /* -------- ConnectGestionnaire -------- */
        [HttpGet]
        public IActionResult InterfaceAdministrateur(Administrateur administrateur)
        {
            return View(administrateur);
        }
    }
}
