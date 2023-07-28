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

        public record UserData(int Id, string FirstName, string LastName, string UserName);
        
        [HttpPost("token")]
        public async Task<ActionResult<string>> Authentication([FromBody] AuthenticationData data)
        {
            IdentityUser? user = await ValidateCredentials(data)!;

            if (user is null)
            {
                return Unauthorized("nope");
            }

            Task<IList<string>> roles = _userManager.GetRolesAsync(user);

            string role = roles.Result.FirstOrDefault()!;

            string token = GenerateToken(user);

            return Ok(role);
        }

        private string GenerateToken(IdentityUser user)
        {
            return "true";
        }

        private async Task<IdentityUser?> ValidateCredentials(AuthenticationData data)
        {
            var result = await _signInManager.PasswordSignInAsync(data.Email, data.Password, false, false);

            if (result.Succeeded)
            {
                return _userManager.Users.SingleOrDefault(u => u.Email == data.Email);
            }
            return null;
        }
    }
}
