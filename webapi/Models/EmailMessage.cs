using webapi.Models.Enum;

namespace webapi.Models
{
    public class EmailMessage
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsSend { get;set; } = false;
        public TypeEmailMessage Type { get; set; } 
    }
}
