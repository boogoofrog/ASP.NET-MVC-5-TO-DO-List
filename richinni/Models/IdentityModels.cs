using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace richinni.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public virtual ICollection<ToDo> ToDoes { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<richinni.Models.ToDo> ToDoes { get; set; }
    }
}