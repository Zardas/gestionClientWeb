using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionRelationClient.Models;

namespace GestionRelationClient.Data
{
    // From : https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0#register-the-schoolcontext
    public static class DBInitializer
    {

        public static void Initialize(GestionRelationClient_DBContext context)
        {
            //On s'assure que la BDD a bien été créée
            context.Database.EnsureCreated();

            if(context.Roles.Any())
            {
                return;
            }

            var roles = new Role[]
            {
                new Role() {Title="Jambon"},
                new Role() {Title="Caramel"},
                new Role() {Title="Poulet"}
            };
            foreach(Role r in roles)
            {
                context.Roles.Add(r);
            }
            context.SaveChanges();
        }
    }
}
