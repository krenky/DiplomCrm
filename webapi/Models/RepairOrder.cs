namespace webapi.Models
{
    public class RepairOrder
    {
        public int Id { get; set; }
        //public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Device Device { get; set; }
        public int DeviceId { get; set; }
        public StatusRepair Status { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
        public List<InventoryItem> PartsUsed { get; set; } = new List<InventoryItem>();
        public string? AspNetUserId { get; set; }
    }

    public enum StatusRepair
    {
        Success,
        InWork
    }
}
