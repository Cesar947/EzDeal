using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework; // Manejo de identidades de Microsoft
using AnunciApp.Models;
namespace AnunciApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ApplicationDbContext db = new ApplicationDbContext();
            CrearRoles(db);
            CreateSuperUsuario(db);
            AsignarPermiso(db);

            db.Dispose();
        }

        private void CrearRoles(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (!roleManager.RoleExists("view"))
            {
                roleManager.Create(new IdentityRole("view"));
            }

            if (!roleManager.RoleExists("create"))
            {
                roleManager.Create(new IdentityRole("create"));
            }
        }



        private void CreateSuperUsuario(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("megauser@gmail.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "megauser@gmail.com",
                    Email = "megauser@gmail.com"
                };
                userManager.Create(user, "abcABC123*");
            }
        }



        private void AsignarPermiso(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName("megauser@gmail.com");

            if (!userManager.IsInRole(user.Id, "view"))
                userManager.AddToRole(user.Id, "view");

            if (!userManager.IsInRole(user.Id, "create"))
                userManager.AddToRole(user.Id, "create");
        }
    }
}
