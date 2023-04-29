namespace webapi.Models
{
    public class Device
    {
        public Device()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ModelDevice { get; set; }
        public string SerialNumber { get; set; }

    }
}
