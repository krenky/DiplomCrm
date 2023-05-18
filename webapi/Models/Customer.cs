namespace webapi.Models
{
    public class Customer
    {
        private int id;
        private string firstName;
        private string lastName;
        private string phone;
        private string email;
        private string? address;
        private DateTime birthdate;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string? Address { get => address; set => address = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public List<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();
        public Customer() { }

    }
}
