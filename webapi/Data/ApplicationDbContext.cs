using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.Utils;

namespace webapi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<ApplicationUser> AspNetUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyUtcDateTimeConverter();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<webapi.Models.Customer> Customer { get; set; } = default!;
        public DbSet<webapi.Models.Device> Device { get; set; } = default!;
        public DbSet<webapi.Models.InventoryItem> InventoryItem { get; set; } = default!;
        public DbSet<webapi.Models.RepairOrder> RepairOrder { get; set; } = default!;
        public DbSet<EmailMessage> EmailMessages { get; set; } = default!;
    }
}