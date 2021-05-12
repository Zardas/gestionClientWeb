using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GestionRelationClient.Models
{
    public abstract class Utilisateur
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UtilisateurId { get; set; }

        [Required(ErrorMessage = "Login requis !")]
        public String Login { get; set; }

        [Required(ErrorMessage = "Mot de passe requis !")]
        public String MotDePasse { get; set; }

        public String LoginStatus { get; set; }




        public void Connexion()
        {
            this.LoginStatus = "online";
        }
        public void Deconnexion()
        {
            this.LoginStatus = "offline";
        }
    }
}
