namespace webapi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public List<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();
        public Customer() { }

    }
}
