using Microsoft.AspNetCore.Identity;

namespace webapi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? JobTitle { get; set; }
        public RepairOrder[] RepairOrders { get; set; }
    }
}