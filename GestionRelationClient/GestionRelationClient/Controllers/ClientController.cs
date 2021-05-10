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
            return View(_context.Clients.ToList());
        }

        [HttpPost]
        public IActionResult InscriptionClient(Models.Client client)
        {
            if(ModelState.IsValid)
            {
                client.LoginStatus = "offline";
                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("ConnectClient");
            }

            return View();
        }

        [HttpGet]
        public IActionResult InscriptionClient()
        {
            return View();
        }
    }
}
