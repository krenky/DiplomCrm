using Microsoft.AspNetCore.Mvc;
using webapi.Models.Authenticate;
using webapi.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace webapi.Interfase
{
    public interface IAuthenticateService
    {
        Task<ActionResult> ChangePassword(ChangePasswordModel model);
        Task<ActionResult<ApplicationUser>> GetCurrentUser(HttpContext httpContext);
        Task<JwtSecurityToken> Login(LoginModel model);
        Task<IdentityResult> Register(RegisterModel model);
        Task<ActionResult> RegisterAdmin(RegisterModel model);
        Task<ActionResult> ResetPassword(ResetPasswordModel model);
        Task<ActionResult> ResetPasswordAdmin(ResetPasswordAdminModel model);
        Task<ActionResult> ResetPasswordToken(ResetPasswordModel model);
    }
}
