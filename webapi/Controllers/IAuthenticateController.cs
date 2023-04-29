using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Models.Authenticate;

namespace webapi.Controllers
{
    public interface IAuthenticateController
    {
        Task<ActionResult> ChangePassword([FromBody] ChangePasswordModel model);
        Task<ActionResult<ApplicationUser>> GetCurrentUser();
        Task<ActionResult> Login([FromBody] LoginModel model);
        Task<IActionResult> Register([FromBody] RegisterModel model);
        Task<ActionResult> RegisterAdmin([FromBody] RegisterModel model);
        Task<ActionResult> ResetPassword([FromBody] ResetPasswordModel model);
        Task<ActionResult> ResetPasswordAdmin([FromBody] ResetPasswordAdminModel model);
        Task<ActionResult> ResetPasswordToken([FromBody] ResetPasswordModel model);
    }
}