namespace webapi.Models
{
    public class RepairOrder
    {
        private StatusRepair status = StatusRepair.Queued;

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Device? Device { get; set; }
        public int DeviceId { get; set; }
        public StatusRepair Status { get => status; set {
                if (value == StatusRepair.InWork)
                    StartedAt = DateTime.UtcNow;
                if (value == StatusRepair.Success)
                    EndedAt = DateTime.UtcNow;
                status = value;
            } }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public List<InventoryItem> PartsUsed { get; set; } = new List<InventoryItem>();
        public List<RepairService> repairServices { get; set; } = new List<RepairService>();
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }

    public enum StatusRepair
    {
        Success,
        InWork,
        Queued
    }
}
