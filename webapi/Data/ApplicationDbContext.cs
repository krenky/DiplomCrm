using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole(Role.SystemAdministrator.ToString()),
                                                        new IdentityRole(Role.Administrator.ToString()),
                                                        new IdentityRole(Role.Operator.ToString()),
                                                        new IdentityRole(Role.Manager.ToString()),
                                                        new IdentityRole(Role.HeadOfSales.ToString()),
                                                        new IdentityRole(Role.MarketingSpecialist.ToString()),
                                                        new IdentityRole(Role.HeadOfService.ToString()),
                                                        new IdentityRole(Role.ServiceManger.ToString()));
            base.OnModelCreating(modelBuilder);
        }
    }
}