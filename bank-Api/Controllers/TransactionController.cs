using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bank_Api.Data;
using bank_Api.Model;
using Microsoft.AspNetCore.Authorization;

namespace bank_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController(ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "customer")]
    public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
    {
        try
        {
            var customer = await context.Customers.SingleAsync(x => x.Id == transaction.CustomerId);
            customer.AvailableBalance = customer.AvailableBalance > transaction.Amount ? customer.AvailableBalance - transaction.Amount : 0;
            context.Customers.Update(customer);

            transaction.Date = DateTime.Now;
            context.Transactions.Add(transaction);

            await context.SaveChangesAsync();
            return Ok(transaction);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });            
        }

    }
    
    [HttpGet("Customer/{userId:int}")]
    [Authorize(Roles = "customer")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(int userId)
    {
        try
        {
            return await context.Transactions.Where(x => x.CustomerId == userId).OrderByDescending(x => x.Id).ToListAsync();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("Customer/Details/id={transactionId:int}&userId={userId:int}")]
    [Authorize(Roles = "customer")]
    public async Task<ActionResult<Transaction>> GetTransaction(int transactionId, int userId)
    {
        try
        {
            return await context.Transactions.SingleAsync(x => x.Id == transactionId && x.CustomerId == userId);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("Staff")]
    [Authorize(Roles = "staff")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetStaffTransactions()
    {
        try
        {
            return await context.Transactions.OrderByDescending(x => x.Id).ToListAsync();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("Staff/Details/{transactionId:int}")]
    [Authorize(Roles = "staff")]
    public async Task<ActionResult<Transaction>> GetStaffTransaction(int transactionId)
    {
        try
        {
            return await context.Transactions.SingleAsync(x => x.Id == transactionId);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("Staff/Verify")]
    [Authorize(Roles = "staff")]
    public async Task<ActionResult<Transaction>> Verify([FromBody] int transactionId)
    {
        var transaction = context.Transactions.Single(x => x.Id == transactionId);
        transaction.Verified = true;

        context.Update(transaction);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetStaffTransactions), new { }, transaction);
    }
}
