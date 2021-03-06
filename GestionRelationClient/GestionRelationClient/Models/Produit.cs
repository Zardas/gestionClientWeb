using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRelationClient.Models
{
    public class Produit : Article
    {
        // La clé primaire est déjà dans Article

        public String Fabricant { get; set; }
        public int Quantite { get; set; }
        public int Capacite { get; set; }

        // Un produit est lié à un stock
        public int StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
