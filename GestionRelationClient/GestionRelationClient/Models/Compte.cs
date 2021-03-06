using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRelationClient.Models
{
    public class Compte
    {
        public int CompteId { get; set; }
        public DateTime DateCreation { get; set; }
        public String NomCompte { get; set; }

        // Un compte est lié à un seul client
        public int ClientId { get; set; }
        private Client Client { get; set; }

        // Un compte possède plusieurs factures
        private ICollection<Facture> Factures { get; set; }

        // Un compte peut bénéfier de plusieurs supports
        private ICollection<Support> Supports;

        // Un compte possède un panier -> relation de composition : le panier ne peut pas vivre dans le compte
        public Panier Panier { get; set; }


        public Compte()
        {
            this.Factures = new List<Facture>();
            this.Supports = new List<Support>();

            //this.Panier = new Panier(this);
        }


        // TODO
        private ICollection<Facture> GetFactureParPeriode()
        {
            return null;
        }


        // TODO
        public void ModifierNomCompte(string nouveauNom)
        {
            this.NomCompte = nouveauNom;
        }

        private ICollection<Article> GetArticlesPanier()
        {
            return this.Panier.GetAllArticles();
        }

        // TODO
        public void ajouterFacture()
        {

        }

        // TODO
        public void AjouterPanier()
        {

        }
    }
}
