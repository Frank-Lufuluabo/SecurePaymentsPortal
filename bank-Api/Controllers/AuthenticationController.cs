using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace bank_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(IConfiguration configuration) : ControllerBase
{
    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Validate user credentials (this is just a placeholder, replace with actual validation logic)
        if (request.Username != "testuser" || request.Password != "password")
        {
            return Unauthorized("Invalid username or password.");
        }
        // Generate JWT token
        var token = GenerateJwtToken(request.Username);
        return Ok(new { Token = token });
    }
    private string GenerateJwtToken(string username)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, username)
        };
        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"])),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}