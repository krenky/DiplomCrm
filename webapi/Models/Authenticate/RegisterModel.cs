using System.ComponentModel.DataAnnotations;

namespace webapi.Models.Authenticate
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public Role UserRole { get; set; }
    }
}
