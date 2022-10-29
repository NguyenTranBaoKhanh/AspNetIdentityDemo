using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityDemo.Api.Models
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Entity<IdentityUser>().ToTable("Users");
            // // builder.Entity<IdentityUser<int>>().Ignore(x => x.PhoneNumber);
            // builder.Entity<IdentityRole>().ToTable("Roles");

            // Bỏ tiền tố AspNet của các bảng: mặc định
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (!tableName.StartsWith("AspNet"))
                {
                    continue;
                }
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
