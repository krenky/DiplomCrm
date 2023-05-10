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
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<webapi.Models.Customer> Customer { get; set; } = default!;
        public DbSet<webapi.Models.Device> Device { get; set; } = default!;
        public DbSet<webapi.Models.InventoryItem> InventoryItem { get; set; } = default!;
        public DbSet<webapi.Models.RepairOrder> RepairOrder { get; set; } = default!;
        public DbSet<EmailMessage> EmailMessages { get; set; } = default!;
    }
}