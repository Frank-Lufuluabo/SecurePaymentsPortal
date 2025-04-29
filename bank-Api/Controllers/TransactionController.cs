using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bank_Api.Data;
using bank_Api.Model;
using System.Data;

namespace bank_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            var customer = await _context.Customers.SingleAsync(x => x.Id == transaction.CustomerId);
            customer.AvailableBalance = customer.AvailableBalance > transaction.Amount ? customer.AvailableBalance - transaction.Amount : 0;
            _context.Customers.Update(customer);

            transaction.Date = DateTime.Now;
            _context.Transactions.Add(transaction);

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransactions), new { id = transaction.CustomerId }, transaction);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(int id)
        {
            return await _context.Transactions.Where(x => x.CustomerId == id).OrderByDescending(x=>x.Id).ToListAsync();
        }

        [HttpGet("CurrentTransaction/{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            return await _context.Transactions.SingleAsync(x => x.Id == id);
        }

        [HttpGet("Transactions")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetStaffTransactions()
        {
            return await _context.Transactions.OrderByDescending(x => x.Id).ToListAsync();
        }

        [HttpGet("Verify/{id}")]
        public async Task<ActionResult<Transaction>> Verify(int id)
        {
            var transaction = _context.Transactions.Single(x => x.Id == id);
            transaction.Verified = true;

            _context.Update(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStaffTransactions), new {}, transaction);

        }
    }
}
