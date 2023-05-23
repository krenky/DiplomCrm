namespace webapi.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public List<RepairOrder> repairOrders { get; set; } = new List<RepairOrder>();
        public InventoryItem() { }
    }
}
