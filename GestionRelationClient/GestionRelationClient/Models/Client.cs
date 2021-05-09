using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRelationClient.Models
{
    public class Client : Utilisateur
    {
        //public int ClientId { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Mail { get; set; }
        public String Telephone { get; set; }
        public int Age { get; set; }

        // Un client possède plusieurs comptes
        public ICollection<Compte> Comptes;

        public Client()
        {
            this.Comptes = new List<Compte>();
        }

        // TODO ?
        public void SeConnecter()
        {

        }

        // TODO ?
        public void Inscrire()
        {

        }

        // TODO ?
        public void Recherche()
        {

        }

        // TODO
        public void ModifierProfil()
        {

        }
    }
}
