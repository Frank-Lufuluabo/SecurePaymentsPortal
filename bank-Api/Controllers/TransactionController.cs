using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bank_Api.Data;
using bank_Api.Model;

namespace bank_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController(ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
    {
        var customer = await context.Customers.SingleAsync(x => x.Id == transaction.CustomerId);
        customer.AvailableBalance = customer.AvailableBalance > transaction.Amount ? customer.AvailableBalance - transaction.Amount : 0;
        context.Customers.Update(customer);

        transaction.Date = DateTime.Now;
        context.Transactions.Add(transaction);

        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTransactions), new { id = transaction.CustomerId }, transaction);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(int id)
    {
        return await context.Transactions.Where(x => x.CustomerId == id).OrderByDescending(x=>x.Id).ToListAsync();
    }

    [HttpGet("CurrentTransaction/{id}")]
    public async Task<ActionResult<Transaction>> GetTransaction(int id)
    {
        return await context.Transactions.SingleAsync(x => x.Id == id);
    }

    [HttpGet("Transactions")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetStaffTransactions()
    {
        return await context.Transactions.OrderByDescending(x => x.Id).ToListAsync();
    }

    [HttpGet("Verify/{id}")]
    public async Task<ActionResult<Transaction>> Verify(int id)
    {
        var transaction = context.Transactions.Single(x => x.Id == id);
        transaction.Verified = true;

        context.Update(transaction);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetStaffTransactions), new {}, transaction);
    }
}