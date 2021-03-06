using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRelationClient.Models
{
    public class Gestionnaire : Utilisateur
    {
        //public int GestionnaireId { get; set; }
        public string NomGestionnaire { get; set; }
        public string Email { get; set; }

        // Un gestionnaire possède un rôle
        public int RoleId { get; set; }
        public Role Role { get; set; }

        // Un gestionnaire est responsable d'un stock
        public int StockId { get; set; }
        public Stock Stock { get; set; }

        public int Gain { get; set; }

        public List<Client> ClientsAssocies { get; set; }

        public Gestionnaire()
        {
            Gain = 0; // On initialise les gains à 0
            ClientsAssocies = new List<Client>();
        }

        // Gagne 15% du montant de la facture
        public void ajoutFacture(Facture facture)
        {
            Gain += (int)(facture.Montant*0.15);
        }

        public void SupprimerRole()
        {
            this.Role = null;
        }
    }
}
