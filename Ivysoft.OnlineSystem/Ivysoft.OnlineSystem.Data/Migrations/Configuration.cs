namespace Ivysoft.OnlineSystem.Data.Migrations
{
    using Ivysoft.OnlineSystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<OnlineSystemDbContext>
    {
        private const string AdministratorUserName = "nayden.kirov@gmail.com";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineSystemDbContext context)
        {
            this.SeedUsers(context);
        }

        private void SeedUsers(OnlineSystemDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Administrator";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<Customer>(context);
                var userManager = new UserManager<Customer>(userStore);
                var customer = new Customer
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(customer, AdministratorPassword);
                userManager.AddToRole(customer.Id, roleName);
            }
        }
    }
}
