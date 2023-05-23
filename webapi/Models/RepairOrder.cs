using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class RepairOrder
    {
        private StatusRepair status = StatusRepair.Queued;
        private decimal price;

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Device? Device { get; set; }
        public int DeviceId { get; set; }
        public StatusRepair Status
        {
            get => status; set
            {
                if (value == StatusRepair.InWork)
                    StartedAt = DateTime.UtcNow;
                if (value == StatusRepair.Success)
                    EndedAt = DateTime.UtcNow;
                status = value;
            }
        }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public List<InventoryItem> PartsUsed { get; set; } = new List<InventoryItem>();
        public List<RepairWork> repairWorks { get; set; } = new List<RepairWork>();
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public bool LoyaltyDiscount { get; set; } = false;
        [NotMapped]
        public decimal Price
        {
            get
            {
                return LoyaltyDiscount ? (PartsUsed.Sum(x => x.Price) + repairWorks.Sum(x => x.Price)) * 0.75m : PartsUsed.Sum(x => x.Price) + repairWorks.Sum(x => x.Price);
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
