using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using webapi.Models;
using webapi.Models.Authenticate;

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
