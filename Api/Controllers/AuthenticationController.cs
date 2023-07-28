using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public record AuthenticationData(string Email, string Password);
        
        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Authentication([FromBody] AuthenticationData data)
        {
            // Validate user
            IdentityUser? user = await ValidateCredentials(data);

            if (user is null)
            {
                return Unauthorized("Invalid user and/or password.");
            }

            Task<IList<string>> userInfo = _userManager.GetRolesAsync(user);
            
            // Get validated user role (Mechanic or Manager)
            string role = userInfo.Result.FirstOrDefault()!;

            string token = GenerateToken(user, role);

            return Ok(token);
        }

        private string GenerateToken(IdentityUser user, string role)
        {
            var secretKey =
                new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("Authentication:SecretKey")!));

            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new()
            {
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.UniqueName, user.UserName!),
                new(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
            Environment.GetEnvironmentVariable("Authentication:Issuer"),
            Environment.GetEnvironmentVariable("Authentication:Audience"),
                    claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(60),
            signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<IdentityUser?> ValidateCredentials(AuthenticationData data)
        {
            // Use Asp.Net Sign In Manager to validate user
            var result = await _signInManager.PasswordSignInAsync(data.Email, data.Password, false, false);

            if (result.Succeeded)
            {
                return _userManager.Users.SingleOrDefault(u => u.Email == data.Email);
            }
            return null;
        }
    }
}
