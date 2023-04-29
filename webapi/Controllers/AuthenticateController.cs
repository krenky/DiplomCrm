﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using webapi.Interfase;
using webapi.Models;
using webapi.Models.Authenticate;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, IAuthenticateService authenticateService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _authenticateService = authenticateService;
        }
        /// <summary>
        /// Метод регистрации пользователя
        /// </summary>
        /// <param name="model">Данные нового пользователя</param>
        /// <returns>Успешность регистрации(IActionResult)</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var result = await _authenticateService.Register(model);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(500, new { Status = "Error", Message = $"User creation failes! {string.Join(", ", result.Errors)}" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = "Error", Message = ex.Message });
            }
        }

        /// <summary>
        /// Метод регистрации администратора
        /// </summary>
        /// <param name="model">Данные нового администратора</param>
        /// <returns>Успешность регистрации(ActionResult)</returns>
        [HttpPost]
        [Route("register-admin")]
        public async Task<ActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(500, new { Status = "Error", Message = "User already exists!" });
            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = new List<string>();
                foreach (var error in result.Errors)
                    errors.Add(error.Description);
                return StatusCode(500, new { Status = "Error", Message = $"User creation failes! {string.Join(", ", errors)}" });
            }
            //if (await _roleManager.RoleExistsAsync(UserRole.User))
            //    await _roleManager.CreateAsync(new IdentityRole(UserRole.User));

            //if (await _roleManager.RoleExistsAsync(UserRole.Admin))
            //    await _userManager.AddToRoleAsync(user, UserRole.Admin);

            return Ok(new { Status = "Success", Message = "User created successfully" });
        }
        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="model">Данные для для авторизации</param>
        /// <returns>Токен доступа</returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _authenticateService.Login(model);
            if (result != null)
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(result), expiration = result.ValidTo });
            else
                return Unauthorized();
        }

        /// <summary>
        /// Метод проверки авторизации
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("CurrentUser")]
        public async Task<ActionResult<ApplicationUser>> GetCurrentUser()
        {
            return await _authenticateService.GetCurrentUser(HttpContext);
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Name);
            if (user == null)
                return NotFound(model.Name);

            if (string.Compare(model.NewPassword, model.ConfirmNewPassword) != 0)
                return BadRequest("The new password and confirm new password does not match");

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result != null)
            {
                var errors = new List<string>();
                foreach (var error in result.Errors)
                    errors.Add(error.Description);
                return StatusCode(500, new { Status = "Error", Message = $"User creation failes! {string.Join(", ", errors)}" });
            }

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("reset-password-admin")]
        public async Task<ActionResult> ResetPasswordAdmin([FromBody] ResetPasswordAdminModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return NotFound(model.Username);

            if (string.Compare(model.NewPassword, model.ConfirmNewPassword) != 0)
                return BadRequest("The new password and confirm new password does not match");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

            if (result != null)
            {
                var errors = new List<string>();
                foreach (var error in result.Errors)
                    errors.Add(error.Description);
                return StatusCode(500, new { Status = "Error", Message = $"Password reset failes! {string.Join(", ", errors)}" });
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("reset-password-token")]
        public async Task<ActionResult> ResetPasswordToken([FromBody] ResetPasswordModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return NotFound(model.Username);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return Ok(token);
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return NotFound(model.Username);

            if (string.Compare(model.NewPassword, model.ConfirmNewPassword) != 0)
                return BadRequest("The new password and confirm new password does not match");

            //var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (string.IsNullOrEmpty(model.Token))
                return BadRequest("Invalid token");

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);

            if (result != null)
            {
                var errors = new List<string>();
                foreach (var error in result.Errors)
                    errors.Add(error.Description);
                return StatusCode(500, new { Status = "Error", Message = $"Password reset failes! {string.Join(", ", errors)}" });
            }
            return Ok(result);
        }

    }
}
