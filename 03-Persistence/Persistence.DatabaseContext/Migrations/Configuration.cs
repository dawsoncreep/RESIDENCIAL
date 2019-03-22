namespace Persistence.DatabaseContext.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Auth;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Persistence.DatabaseContext.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Persistence.DatabaseContext.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole { Name = "Admin" };

                manager.Create(role);
            }


            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser {
                    UserName = "admin",
                    Email = "admin@residencial.com"
                };

                manager.Create(user, "Admin123.");

                ApplicationUserRole userRole = new ApplicationUserRole();
                //userRole.AddToRole(user.Id, "Admin", manager);
                userRole.UserId = user.Id;
                userRole.RoleId = context.ApplicationRole.Where(w => w.Name == "Admin").FirstOrDefault().Id;

                context.ApplicationUserRole.Add(userRole);
                context.SaveChanges();
                //manager.AddToRole(userRole.UserId, "Admin");




            }

        
        }
    }
}
