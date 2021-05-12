using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRelationClient.Controllers
{
    public class GestionnaireController : Controller
    {

        /* -------- ConnectGestionnaire -------- */
        [HttpPost]
        public IActionResult ConnectGestionnaire(IFormCollection client)
        {
            return View();
        }
    }
}
