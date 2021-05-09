using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRelationClient.Models
{
    public class Client : Utilisateur
    {
        //public int ClientId { get; set; }

        [Required(ErrorMessage = "Nom requis !")]
        public String Nom { get; set; }

        [Required(ErrorMessage = "Prénom requis !")]
        public String Prenom { get; set; }

        [Required(ErrorMessage = "Mail requis !")]
        public String Mail { get; set; }

        [Required(ErrorMessage = "Téléphone requis !")]
        public String Telephone { get; set; }

        [Required(ErrorMessage = "Age requis !")]
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
