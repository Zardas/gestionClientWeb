using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionRelationClient.Models;
using System.Diagnostics;

namespace GestionRelationClient.Controllers
{
    public class GestionnaireController : Controller
    {

        private readonly GestionRelationClient_DBContext _context;

        public GestionnaireController(GestionRelationClient_DBContext context)
        {
            _context = context;
        }


        /* -------- ConnectGestionnaire -------- */
        [HttpGet]
        public IActionResult InterfaceGestionnaire(int IdGestionnaire)
        {
            // On récupère le gestionnaire à partir de l'id envoyée (comme ça on évite de passer le mot de passe et tout via l'url)
            Gestionnaire gestionnaire = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(IdGestionnaire)).FirstOrDefault();


            // On récupère la liste des clients associés pour pouvoir l'afficher
            List<Client> clientsAssocies = _context.Clients.Where(c => c.GestionnaireAssocieId.Equals(gestionnaire.UtilisateurId)).ToList();
            gestionnaire.ClientsAssocies = clientsAssocies;

            // On récupère la liste des produits associés pour pouvoir l'afficher
            List<Produit> produits = _context.Produits.Where(p => p.StockId.Equals(gestionnaire.StockId)).ToList();
            ViewData["ProduitsAssocies"] = produits;


            Debug.WriteLine("Nombre de clients associés : " + gestionnaire.ClientsAssocies.Count());
            return View(gestionnaire);
        }



        /* -------- Désassociation client associé -------- */
        [HttpPost]
        public IActionResult SuppressionClientAssocie(IFormCollection clientASupprimer)
        {
            Debug.WriteLine("Demande de suppression du client " + clientASupprimer["IdClient"]);
            // On récupère le client à supprimer
            Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(Int32.Parse(clientASupprimer["IdClient"]))).FirstOrDefault();

            Debug.WriteLine("Id du client trouvé : " + client.UtilisateurId);

            // On récupère aussi le gestionnaire pour pouvoir le repasser via le get
            Gestionnaire gestionnaire = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(client.GestionnaireAssocieId)).FirstOrDefault();

            client.GestionnaireAssocieId = 0;
            _context.SaveChanges();


            return RedirectToAction("InterfaceGestionnaire", "Gestionnaire", new { IdGestionnaire = gestionnaire.UtilisateurId });
        }


        /* -------- Liste des clients à associer -------- */
        [HttpGet]
        public IActionResult AjoutClientAssocie(int IdGestionnaire)
        {
            Debug.WriteLine("Id envoyé : " + IdGestionnaire);

            Gestionnaire gestionnaire = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(IdGestionnaire)).FirstOrDefault();

            List<Client> clientsDisponibles = _context.Clients.Where(c => !(c.GestionnaireAssocieId.Equals(gestionnaire.UtilisateurId))).ToList();

            ViewData["clientsDisponibles"] = clientsDisponibles;
            return View(gestionnaire);
        }

        /* -------- Ajout client à associer -------- */
        [HttpPost]
        public IActionResult AjoutClientAssocie(IFormCollection clientAajouter)
        {
            Client client = _context.Clients.Where(c => c.UtilisateurId.Equals(Int32.Parse(clientAajouter["IdClient"]))).FirstOrDefault();
            Gestionnaire gestionnaire = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(Int32.Parse(clientAajouter["IdGestionnaire"]))).FirstOrDefault();

            client.GestionnaireAssocieId = gestionnaire.UtilisateurId;
            _context.SaveChanges();

            Debug.WriteLine("Client " + client.Nom + " à associer à " + gestionnaire.NomGestionnaire);
            return RedirectToAction("AjoutClientAssocie", "Gestionnaire", new { IdGestionnaire = gestionnaire.UtilisateurId });
        }




        /* -------- Formulaire pour ajouter un produit -------- */
        [HttpGet]
        public IActionResult AjouterProduit(int IdGestionnaire)
        {
            Debug.WriteLine("Id envoyé : " + IdGestionnaire);

            Gestionnaire gestionnaire = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(IdGestionnaire)).FirstOrDefault();

            
            return View(gestionnaire);
        }

        /* -------- Ajouter un produit -------- */
        [HttpPost]
        public IActionResult AjouterProduit(IFormCollection produit)
        {
            Gestionnaire gestionnaire = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(Int32.Parse(produit["GestionnaireId"]))).FirstOrDefault();

            // Un produit n'est pas lié à un abonnement
            Abonnement abonnementNul = _context.Abonnements.Where(a => a.AbonnementId.Equals(1)).FirstOrDefault();

            Produit produitAajouter = new Produit()
            {
                Nom = produit["Nom"],
                Image = produit["Image"],
                Fabricant = produit["Fabricant"],
                Prix = Int32.Parse(produit["Prix"]),
                Quantite = Int32.Parse(produit["Quantite"]),
                Capacite = Int32.Parse(produit["Capacite"]),
                Description = produit["Description"],
                Manuel = produit["Manuel"],
                StockId = gestionnaire.StockId,
                Abonnement = abonnementNul,
                PanierId = 1 // Le panier nul
            };

            _context.Produits.Add(produitAajouter);
            _context.SaveChanges();

            return RedirectToAction("AjouterProduit", "Gestionnaire", new { IdGestionnaire = gestionnaire.UtilisateurId });
        }

        /* -------- Réduire de 1 la quantité un produit -------- */
        [HttpPost]
        public IActionResult SuppressionProduit(IFormCollection produitEnvoye)
        {
            Gestionnaire gestionnaire = _context.Gestionnaires.Where(g => g.UtilisateurId.Equals(Int32.Parse(produitEnvoye["GestionnaireId"]))).FirstOrDefault();
            Produit produit = _context.Produits.Where(p => p.ArticleId.Equals(Int32.Parse(produitEnvoye["ProduitId"]))).FirstOrDefault();

            Debug.WriteLine("Suppresion d'un " + produit.Nom + " de la part de " + gestionnaire.NomGestionnaire);

            produit.Quantite--;
            if(produit.Quantite <= 0)
            {
                _context.Produits.Remove(produit);
            }
            _context.SaveChanges();

            return RedirectToAction("InterfaceGestionnaire", "Gestionnaire", new { IdGestionnaire = gestionnaire.UtilisateurId });
        }
    }
}
