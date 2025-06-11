using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bank_Api.Data;
using bank_Api.IdentityAuth;
using bank_Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace bank_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IConfiguration configuration, ApplicationDbContext context) : ControllerBase
{
    // Staff Login
    [HttpPost("login")]
    public async Task<ActionResult<User>> Login([FromBody] UserLogin request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Employee ID and Password are required." });
            }

            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);
            if (user == null || user.Password != SimpleHashHelper.Hash(request.Password))
            {
                return Unauthorized(new { message = "Invalid Employee ID or Password." });
            }

            user.IsAuthenticated = true;
            await context.SaveChangesAsync();

            // Generate JWT token
            var token = GenerateJwtToken(user.UserName!, user.Role);
            return Ok(new { EmployeeId = user.Id, Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }

    // Get Current User by EmployeeId
    [HttpGet("current-user/{userId:int}")]
    [Authorize(Roles = "staff")]
    public async Task<ActionResult<User>> GetCurrentUser(int userId)
    {
        try
        {
            if (userId <= 0)
            {
                return BadRequest(new { message = "Employee ID is required." });
            }

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            var isAuth = await CheckUserIsAuth(userId);
            if (!isAuth)
            {
                return BadRequest(new { message = "User is not authenticated." });
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }

    // Staff Logout
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] int userId)
    {
        try
        {
            if (userId <= 0)
            {
                return BadRequest(new { message = "Employee ID is required." });
            }

            var user = await context.Staff.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            user.IsAuthenticated = false;
            await context.SaveChangesAsync();

            return Ok(new { message = "Logged out successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }

    // Customer Login
    [HttpPost("customer-login")]
    public async Task<ActionResult<Customer>> CustomerLogin([FromBody] CustomerLogin request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password) || string.IsNullOrWhiteSpace(request.AccountNumber))
            {
                return BadRequest(new { message = "Customer username, account number and Password are required." });
            }

            var customer = await context.Customers.FirstOrDefaultAsync(u => u.UserName == request.UserName && u.AccountNumber == request.AccountNumber);
            if (customer == null || customer.Password != SimpleHashHelper.Hash(request.Password))
            {
                return Unauthorized(new { message = "Invalid Username, account number or Password." });
            }

            customer.IsAuthenticated = true;
            await context.SaveChangesAsync();

            var token = GenerateJwtToken(customer.UserName!, customer.Role);

            return Ok(new { User = customer, Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }

    // Customer Logout
    [HttpPost("customer-logout")]
    public async Task<IActionResult> CustomerLogout([FromBody] int customerId)
    {
        try
        {
            if (customerId <= 0)
            {
                return BadRequest(new { message = "Customer Id is required." });
            }

            var user = await context.Customers.FirstOrDefaultAsync(u => u.Id == customerId);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            user.IsAuthenticated = false;
            await context.SaveChangesAsync();

            return Ok(new { message = "Logged out successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }

    [HttpGet("current-customer/{userId}")]
    [Authorize(Roles = "customer")]
    public async Task<ActionResult<User>> GetCurrentCustomer(int userId)
    {
        try
        {
            if (userId <= 0)
            {
                return BadRequest(new { message = "User Id is required." });
            }

            var customer = await context.Customers.FirstOrDefaultAsync(u => u.Id == userId);
            if (customer == null)
            {
                return NotFound(new { message = "Customer not found." });
            }

            var isAuth = await CheckUserIsAuth(userId);
            if (!isAuth)
            {
                return BadRequest(new { message = "User is not authenticated." });
            }

            return Ok(customer);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }

    private string GenerateJwtToken(string username, string role)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
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

    private async Task<bool> CheckUserIsAuth(int userId)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        return (user?.IsAuthenticated).GetValueOrDefault();
    }
}