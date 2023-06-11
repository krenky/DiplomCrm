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
            modelBuilder.Entity<SalesStages>().HasData(new SalesStages[] 
            {
                new SalesStages {Id = 1, Name = "Обращение клиента", IsFirstDefault = true,  NextStagesId = 2, },
                new SalesStages {Id = 2, Name = "Приемка устройства", IsFirstDefault = false, NextStagesId = 3 },
                new SalesStages {Id = 3, Name = "Информирование клиента о стоимости ремонта", IsFirstDefault = false, NextStagesId = 4 },
                new SalesStages {Id = 4, Name = "Ожидание запчастей", IsFirstDefault = false, NextStagesId = 5, },
                new SalesStages {Id = 5, Name = "Ремонт", IsFirstDefault = false, NextStagesId = 6 },
                new SalesStages {Id = 6, Name = "Оплата ремонта", IsFirstDefault = false, NextStagesId = 7 },
                new SalesStages {Id = 7, Name = "Завершен", IsFirstDefault = false, IsLastDefault = true },
                new SalesStages {Id = 8, Name = "Отказ", IsFirstDefault = false, IsCancelDefault = true },
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<webapi.Models.Customer> Customer { get; set; } = default!;
        public DbSet<webapi.Models.Device> Device { get; set; } = default!;
        public DbSet<webapi.Models.InventoryItem> InventoryItem { get; set; } = default!;
        public DbSet<webapi.Models.RepairOrder> RepairOrders { get; set; } = default!;
        public DbSet<EmailMessage> EmailMessages { get; set; } = default!;
        public DbSet<RepairWork> RepairWorks { get; set; }
        public DbSet<CustomerHistory> customerHistories { get; set; } = default!;
        public DbSet<SalesStages> SalesStages { get; set; } = default!;
        public DbSet<RepairOrderHistory> RepairOrderHistory { get; set; }
        public DbSet<AdvertisingСompany> AdvertisingСompany { get; set; }
    }
}