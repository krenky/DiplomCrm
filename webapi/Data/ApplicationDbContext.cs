using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<ApplicationUser> AspNetUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityRole>().HasData(
                                                        new IdentityRole(Role.Administrator.ToString()),
                                                        new IdentityRole(Role.ServiceManager.ToString()),
                                                        new IdentityRole(Role.Technician.ToString()),
                                                        new IdentityRole(Role.ITSupport.ToString()),
                                                        new IdentityRole(Role.Executive.ToString()));
            base.OnModelCreating(modelBuilder);
        }
    }
}