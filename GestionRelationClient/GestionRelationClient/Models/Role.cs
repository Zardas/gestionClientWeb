using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRelationClient.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Title requis !")]
        public String Title { get; set; }

 
        public void ModifierRole(string newTitle)
        {
            this.Title = newTitle;
        }
    }
}
