using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webapi.Interfaсe;
using webapi.Models;
using webapi.Models.Authenticate;

namespace webapi.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<ApplicationUser>> GetCurrentUser(HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser applicationUser = await _userManager.FindByIdAsync(userId);
            return applicationUser;
        }

        public async Task<JwtSecurityToken?> Login(LoginModel model)
        {
            return await Login(model, _configuration);
        }

        public async Task<JwtSecurityToken?> Login(LoginModel model, IConfiguration configuration)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));

                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return token;
            }
            return null;
        }

        public async Task<IdentityResult> Register(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                throw new Exception("User already exists!");// return StatusCode(500, new { Status = "Error", Message = "User already exists!" });
            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (await _roleManager.RoleExistsAsync(model.UserRole.ToString()))
                await _roleManager.CreateAsync(new IdentityRole(model.UserRole.ToString()));

            if (await _roleManager.RoleExistsAsync(model.UserRole.ToString()))
                await _userManager.AddToRoleAsync(user, model.UserRole.ToString());

            if (!result.Succeeded)
            {
                var errors = new List<string>();
                foreach (var error in result.Errors)
                    errors.Add(error.Description);
                return result; //throw new Exception($"User creation failes! {string.Join(", ", errors)}");//return StatusCode(500, new { Status = "Error", Message = $"User creation failes! {string.Join(", ", errors)}" });
            }
            return result;
        }

        public Task<ActionResult> RegisterAdmin(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> ResetPassword(ResetPasswordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> ResetPasswordAdmin(ResetPasswordAdminModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> ResetPasswordToken(ResetPasswordModel model)
        {
            throw new NotImplementedException();
        }
    }
}
