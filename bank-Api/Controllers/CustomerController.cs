using Microsoft.AspNetCore.Mvc;
using bank_Api.Data;
using bank_Api.Model;
using Microsoft.AspNetCore.Authorization;

namespace bank_Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Staff")]
public class CustomerController(ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Staff")]
    public async Task<ActionResult<Customer>> RegisterCustomer(Customer customer)
    {
        customer.AvailableBalance = 2500m;
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return customer;
    }
}