using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class RepairOrder
    {
        //private StatusRepair? status = StatusRepair.Queued;
        private decimal price;

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Device? Device { get; set; }
        public int DeviceId { get; set; }
        public SalesStages? SalesStages { get; set; }
        public int? SalesStagesId { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        //public DateTime StartedAt { get; set; }
        //public DateTime EndedAt { get; set; }
        public List<InventoryItem>? PartsUsed { get; set; } = new List<InventoryItem>();
        public List<RepairWork>? repairWorks { get; set; } = new List<RepairWork>();
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public List<RepairOrderHistory> History { get; set; } = new List<RepairOrderHistory>();
        public AdvertisingСompany? AdvertisingСompany { get; set; }
        public int? AdvertisingСompanyId { get; set; }
        public bool LoyaltyDiscount { get; set; } = false;
        [NotMapped]
        public decimal Price
        {
            get
            {
                if (AdvertisingСompany != null)
                {
                    return LoyaltyDiscount
                        ? (PartsUsed.Sum(x => x != null ? x.Price : 0) + repairWorks.Sum(x => x != null ? x.Price : 0)) * 0.75m * ((100.0m - (decimal)AdvertisingСompany.Discount)/ 100.0m)
                        : (PartsUsed.Sum(x => x != null ? x.Price : 0) + repairWorks.Sum(x => x != null ? x.Price : 0 )) * ((100.0m - (decimal)AdvertisingСompany.Discount) / 100.0m);
                }
                else
                {
                    List<InventoryItem>? partsUsed = PartsUsed;
                    return LoyaltyDiscount
                        ? (partsUsed != null?partsUsed.Sum(x => x!=null?x.Price:0):0 + (repairWorks != null?repairWorks.Sum(x => x != null ? x.Price : 0) :0)) * 0.75m
                        : partsUsed != null ? partsUsed.Sum(x => x != null ? x.Price : 0):0 + (repairWorks != null ? repairWorks.Sum(x => x != null ? x.Price : 0):0);
                }
            }
        }
        [NotMapped]
        public bool BirthdayLoyaltyDiscount { get
            {
                return Customer?.Birthdate.Day == DateTime.Now.Day && Customer?.Birthdate.Month == DateTime.Now.Month;
            }
        }
        [NotMapped]
        public bool IsWithLoyaltyDiscount
        {
            get
            {
                return BirthdayLoyaltyDiscount || LoyaltyDiscount;
            }
        }
        public enum StatusRepair
        {
            Success,
            InWork,
            Queued
        }
    }
}
