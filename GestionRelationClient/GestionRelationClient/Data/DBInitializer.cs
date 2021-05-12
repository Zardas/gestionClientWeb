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

            if (context.Roles.Any())
            {
                return;
            }

            // Ajout de rôles
            Role role1 = new Role() { Title = "Role1" };
            Role role2 = new Role() { Title = "Role2" };
            Role role3 = new Role() { Title = "Role3" };
            Role role4 = new Role() { Title = "Role4" };
            context.Roles.Add(role1);
            context.Roles.Add(role2);
            context.Roles.Add(role3);
            context.Roles.Add(role4);

            // Ajout de gestionnaires
            Gestionnaire gestionnaire1 = new Gestionnaire() {
                Login = "Kenny",
                Email = "kMc@sp.ca",
                NomGestionnaire = "McCormick",
                Role = role2,
                MotDePasse = Utilitaire.HashPassword("gsnPsw1")
            };
            Gestionnaire gestionnaire2 = new Gestionnaire()
            {
                Login = "Stan",
                Email = "sm@sp.ca",
                NomGestionnaire = "Marsh",
                Role = role3,
                MotDePasse = Utilitaire.HashPassword("gsnPsw2")
            };
            Gestionnaire gestionnaire3 = new Gestionnaire()
            {
                Login = "Kyle",
                Email = "kBr@sp.ca",
                NomGestionnaire = "Broslovsky",
                Role = role1,
                MotDePasse = Utilitaire.HashPassword("gsnPsw3")
            };
            context.Gestionnaires.Add(gestionnaire1);
            context.Gestionnaires.Add(gestionnaire2);
            context.Gestionnaires.Add(gestionnaire3);



            // Ajout de stocks
            Stock stock1 = new Stock() { Titre = "stockClassique", ResponsableStock = gestionnaire2 };
            Stock stock2 = new Stock() { Titre = "stockNouveautes", ResponsableStock = gestionnaire3 };
            Stock stock3 = new Stock() { Titre = "stockAncien", ResponsableStock = gestionnaire1 };
            context.Stocks.Add(stock1);
            context.Stocks.Add(stock2);
            context.Stocks.Add(stock3);


            // Ajout d'administrateur
            Administrateur administrateur1 = new Administrateur() {
                Login = "Butters",
                NomAdministrateur = "Butters",
                Mail = "bt@sp.ca",
                MotDePasse = Utilitaire.HashPassword("adminPsw1")
            };
            context.Administrateurs.Add(administrateur1);


            context.SaveChanges();




        }
    }
}
