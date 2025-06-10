using bank_Api.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace bank_Api.IdentityAuth
{
    public class AuthService
    {
        public List<User> Users { get; set; }
        //public async Task<bool> CheckUserIsAuth(int userId)
        //{
        //    var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        //    return (!(user?.IsAuthenticated).GetValueOrDefault());
        //}

        //public string GenerateJwtToken(string username)
        //{
        //    var jwtSettings = configuration.GetSection("JwtSettings");
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.Sub, username),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    new Claim(ClaimTypes.Name, username)
        //};

        //    //Add Roles

        //    var token = new JwtSecurityToken(
        //        issuer: jwtSettings["Issuer"],
        //        audience: jwtSettings["Audience"],
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"])),
        //        signingCredentials: credentials
        //    );
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
