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
            
            //新增帳號和角色
            this.AddUserAndRoles();
        }

        //新增帳號和角色
         bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new IdentityManager();
            if (!idManager.RoleExists("管理者"))
                success = idManager.CreateRole("管理者");
            if (!success == true) return success;
            if (!idManager.RoleExists("使用者"))
                success = idManager.CreateRole("使用者");
            if (!success == true) return success;
            if (!idManager.RoleExists("閱覽者"))
                success = idManager.CreateRole("閱覽者");
            if (!success) return success;
                var newUser = new ApplicationUser()
                {
                    UserName = "ynic",
                    Email = "ynic@tw.pwc.com"
                };
            success = idManager.CreateUser(newUser, "reserved");

            if (!success) return success;
            success = idManager.AddUserToRole(newUser.Id, "管理者");
            if (!success) return success;
            success = idManager.AddUserToRole(newUser.Id, "使用者");
            if (!success) return success;
            success = idManager.AddUserToRole(newUser.Id, "閱覽者");
            if (!success) return success;
                return success;
        }
    }
}
