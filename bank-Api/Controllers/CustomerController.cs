using Microsoft.AspNetCore.Mvc;
using bank_Api.Data;
using bank_Api.Model;
using Microsoft.AspNetCore.Authorization;

namespace bank_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Customer>> RegisterCustomer(Customer customer)
    {
        try
        {
            customer.Password = SimpleHashHelper.Hash(customer.Password);
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return Ok(customer);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("Details/{id}")]
    [Authorize(Roles = "customer")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        try
        {
            var customer = await context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }
}