namespace richinni.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using richinni.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<richinni.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(richinni.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Users.AddOrUpdate(
            //  p => p.FullName,
            //  new Person { FullName = "Andrew Peters" },
            //  new Person { FullName = "Brice Lambson" },
            //  new Person { FullName = "Rowan Miller" }
            //);
            //
            this.AddUserAndRoles();
        }

         bool AddUserAndRoles()
        {
            bool success = false;
            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;
                success = idManager.CreateRole("CanEdit");
            if (!success == true) return success;
                success = idManager.CreateRole("User");
            if (!success) return success;
                var newUser = new ApplicationUser()
                {
                    UserName = "ynic",
                    Email = "ynic@tw.pwc.com"
                };
            success = idManager.CreateUser(newUser, "reserved");

            if (!success) return success;
                success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;
                success = idManager.AddUserToRole(newUser.Id, "CanEdit");
            if (!success) return success;
                success = idManager.AddUserToRole(newUser.Id, "User");
            if (!success) return success;
                return success;
        }
    }
}
