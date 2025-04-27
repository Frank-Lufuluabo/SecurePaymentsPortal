using Microsoft.EntityFrameworkCore;
using bank_Api.Model;

namespace bank_Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
