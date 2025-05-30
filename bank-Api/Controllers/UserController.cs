﻿using bank_Api.Data;
using bank_Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bank_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Staff Login
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] User request)
        {
            if (string.IsNullOrWhiteSpace(request.EmployeeId) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Employee ID and Password are required." });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.EmployeeId == request.EmployeeId);

            if (user == null || user.Password != request.Password)
            {
                return Unauthorized(new { message = "Invalid Employee ID or Password." });
            }

            user.IsAuthenticated = true;
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // Get Current User by EmployeeId
        [HttpGet("current-user/{employeeId}")]
        public async Task<ActionResult<User>> GetCurrentUser(string employeeId)
        {
            if (string.IsNullOrWhiteSpace(employeeId))
            {
                return BadRequest(new { message = "Employee ID is required." });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.EmployeeId == employeeId);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(user);
        }

        // Staff Logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string employeeId)
        {
            if (string.IsNullOrWhiteSpace(employeeId))
            {
                return BadRequest(new { message = "Employee ID is required." });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.EmployeeId == employeeId);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            user.IsAuthenticated = false;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Logged out successfully." });
        }

        // Customer Login
        [HttpPost("customer-login")]
        public async Task<ActionResult<Customer>> CustomerLogin([FromBody] Customer request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password) || string.IsNullOrWhiteSpace(request.AccountNumber)) 
            {
                return BadRequest(new { message = "Customer username, account number and Password are required." });
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(u => u.UserName == request.UserName && 
                                                                     u.AccountNumber == request.AccountNumber);

            if (customer == null || customer.Password != request.Password)
            {
                return Unauthorized(new { message = "Invalid Username, account number or Password." });
            }

            customer.IsAuthenticated = true;
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        // Customer Logout
        [HttpPost("customer-logout")]
        public async Task<IActionResult> CustomerLogout([FromBody] int customerId)
        {
            if (customerId <= 0)
            {
                return BadRequest(new { message = "Customer Id is required." });
            }

            var user = await _context.Customers.FirstOrDefaultAsync(u => u.Id == customerId);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            user.IsAuthenticated = false;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Logged out successfully." });
        }

        [HttpGet("current-customer/{customerId}")]
        public async Task<ActionResult<User>> GetCurrentCustomer(int customerId)
        {
            if (customerId <= 0)
            {
                return BadRequest(new { message = "Customer Id is required." });
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(u => u.Id== customerId);

            if (customer == null)
            {
                return NotFound(new { message = "Customer not found." });
            }

            return Ok(customer);
        }
    }
}
