using Microsoft.AspNetCore.Mvc;
using bank_Api.Data;
using bank_Api.Model;

namespace bank_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
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