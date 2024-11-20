using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SajjadCalculator.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SajjadCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        /// <summary>
        /// Generates a JWT token for testing purposes.
        /// </summary>
        /// <remarks>
        /// Any combination of username and password is accepted for this endpoint.
        /// This endpoint is intended for testing purposes only.
        /// </remarks>
        /// <param name="request">The login request containing username and password.</param>
        /// <returns>A JWT token.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
                var token = GenerateJwtToken(request.Username);
                return Ok(token);
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSecretKey = "YourSecretKey12345678901234567890";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Name", username),
                new Claim("Role", "User"),
            };

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(10),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}

