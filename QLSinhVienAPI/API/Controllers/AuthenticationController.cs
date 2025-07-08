using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "test_user"),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var claimIdentity = new ClaimsIdentity(claims, "MyAuthCookies");
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("MyAuthCookies", claimsPrincipal);
            return Ok("Login successful");
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyAuthCookies");
            return Ok("Logout successful");
        }
        [HttpGet("accessdenied")]
        public IActionResult AccessDenied()
        {
            return Unauthorized("Access denied");
        }
    }
}