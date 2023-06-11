namespace webapi.Models
{
    public class SalesStages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RepairOrder> Orders { get; set; } = new List<RepairOrder>();
        public bool IsFirstDefault { get; set; } = false;
        public bool IsLastDefault { get; set; } = false;
        public bool IsCancelDefault { get; set; } = false;
        public SalesStages? NextStages { get; set; }
        public int? NextStagesId { get; set; }
    }
}
