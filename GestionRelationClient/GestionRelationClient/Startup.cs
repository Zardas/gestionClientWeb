using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestionRelationClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Pour les sessions (from : https://www.youtube.com/watch?v=Xu-y5ZfKahc)
            services.AddDistributedMemoryCache();
            services.AddSession();


            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDbContext<Models.GestionRelationClient_DBContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // DefaultConnection est indiqu?e dans appsettings.json

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute("Default", "{controller=Client}/{action=ConnectClient}");
                routes.MapRoute("Gestionnaire", "{controller=Gestionnaire}/{action=InterfaceGestionnaire}");
                routes.MapRoute("Administrateur", "{controller=Administrateur}/{action=InterfaceAdministrateur}");
            });
            app.UseStaticFiles();
        }
    }
}
