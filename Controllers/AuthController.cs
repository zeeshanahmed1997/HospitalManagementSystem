using HospitalManagementSystem.Data.Models;
using HospitalManagementSystem.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("reset-all-passwords")]
        public async Task<IActionResult> ResetAllPasswords()
        {
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, "Password@123");
            }

            // Flat success - no wrapper needed for simple messages
            return Ok(new
            {
                success = true,
                message = "All user passwords have been reset to Password@123"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Age = model.Age,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Check if a role was provided, otherwise default to "Patient"
                string roleToAssign = string.IsNullOrWhiteSpace(model.Role) ? "Admin" : model.Role;

                // Optional: You might want to verify if the role exists in your RoleManager here
                await _userManager.AddToRoleAsync(user, roleToAssign);

                return Ok(new
                {
                    success = true,
                    message = $"User registered successfully as {roleToAssign}"
                });
            }

            var errorMessages = result.Errors.Select(e => e.Description);
            return BadRequest(new
            {
                success = false,
                message = "Registration failed",
                errors = errorMessages
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized(new { success = false, message = "Invalid email or password" });
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName!),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        // Optional: add more claims for quick client decode if you want
        new Claim("fullName", $"{user.FirstName} {user.LastName}".Trim()),
        new Claim("email", user.Email ?? ""),
    };
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenObj = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddHours(3),   // ← use UtcNow
                claims: authClaims,
                signingCredentials: creds
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenObj);

            // Set HTTP-only cookie
            Response.Cookies.Append("hms_auth_token", token, new CookieOptions
            {
                HttpOnly = true,          // ← prevents JS access (XSS protection)
                Secure = true,            // ← only HTTPS (set false in local dev if needed)
                SameSite = SameSiteMode.Strict,
                Expires = tokenObj.ValidTo,
                Path = "/"
            });

            // Return user info (no token in body anymore)
            return Ok(new
            {
                success = true,
                message = "Login successful",
                token = token,
                role = userRoles.FirstOrDefault(),
                user = new
                {
                    id = user.Id,
                    fullName = $"{user.FirstName}"+ $" {user.LastName}",
                    email = user.Email ?? "",
                    phoneNumber = user.PhoneNumber ?? "",
                    roles = userRoles
                }
            });
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "User not found"
                });
            }

            // For profile you can keep wrapper or make flat - flat is simpler here too
            var roles = await _userManager.GetRolesAsync(user);

            return Ok(new
            {
                success = true,
                user = new
                {
                    id = user.Id,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    fullname = $"{user.FirstName} {user.LastName}".Trim(),
                    email = user.Email,
                    phoneNumber = user.PhoneNumber,
                    gender = user.Gender,
                    age = user.Age,
                    address = user.Address,
                    roles
                }
            });
        }
    }
}