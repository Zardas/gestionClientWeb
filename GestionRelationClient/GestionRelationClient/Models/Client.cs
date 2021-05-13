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

        public int GestionnaireAssocieId { get; set; }

        public int Solde { get; set; }

        public Client()
        {
            this.Comptes = new List<Compte>();
        }



        


        public void Inscrire(string password)
        {
            this.LoginStatus = "offline";
            MotDePasse = Utilitaire.HashPassword(password);
        }

        public void AjouterCompte(Compte newCompte)
        {
            this.Comptes.Add(newCompte);
        }

        // TODO ?
        public void Recherche()
        {

        }


        public void ModifierProfil(string nouveauLogin, string nouveauMail, string nouveauNom, string nouveauPrenom, string nouveauMotDePasse, string nouveauTelephone, int nouveauAge)
        {
            if(nouveauLogin != "")
            {
                this.Login = nouveauLogin;
            }
            if(nouveauMail != "")
            {
                this.Mail = nouveauMail;
            }
            if (nouveauNom != "")
            {
                this.Nom = nouveauNom;
            }
            if (nouveauPrenom != "")
            {
                this.Prenom = nouveauPrenom;
            }
            if (nouveauMotDePasse != "")
            {
                this.MotDePasse = Utilitaire.HashPassword(nouveauMotDePasse);
            }
            if (nouveauTelephone != "")
            {
                this.Telephone = nouveauTelephone;
            }
            if (nouveauAge != 0)
            {
                this.Age = nouveauAge;
            }
        }

    }
}
