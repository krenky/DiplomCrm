namespace webapi.Models
{
    //public class RegisterCustomer
    //{
    //}
    public class RegisterCustomer
    {
        //public int Id;
        private string firstName;
        private string lastName;
        private string email;
        private string manufacturer;
        private DateTime birtdate;
        private string phoneModel;
        private string comment;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public DateTime Birtdate { get => birtdate; set => birtdate = value; }
        public string PhoneModel { get => phoneModel; set => phoneModel = value; }
        public string Comment { get => comment; set => comment = value; }
    }
}
