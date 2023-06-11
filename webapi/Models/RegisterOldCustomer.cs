namespace webapi.Models
{
    public class RegisterOldCustomer
    {
        private string email;
        private string manufacturer;
        private string phoneModel;
        private string comment;

        public string Email { get => email; set => email = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string PhoneModel { get => phoneModel; set => phoneModel = value; }
        public string Comment { get => comment; set => comment = value; }
        public AdvertisingСompany? Code { get; set; }
    }
}
