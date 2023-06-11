namespace webapi.Models
{
    public class AdvertisingСompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public List<RepairOrder>? RepairOrders { get; set; } = new List<RepairOrder>();
    }
}
