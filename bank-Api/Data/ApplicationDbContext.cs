using Microsoft.EntityFrameworkCore;
using bank_Api.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace bank_Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set decimal precision for Customer.AvailableBalance
            modelBuilder.Entity<Customer>()
                .Property(c => c.AvailableBalance)
                .HasPrecision(18, 2);

            // Set decimal precision for Transaction.Amount
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            // Seed Staff
            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    EmployeeId = "emp001",
                    UserName = "franck",
                    Password = "password",
                    Name = "Franck",
                    Role = "staff",
                    Email = "employee@gmail.com",
                    Position = "Bank Teller",
                    IsAuthenticated = false
                }
            );

            // Seed Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 2,
                    EmployeeId = "em002",
                    UserName = "alice",
                    Password = "password",
                    FullName = "Alice Smith",
                    IdNumber = "ID123456789",
                    Name = "Bob",
                    Role = "customer",
                    IsAuthenticated = false,
                    AvailableBalance = 2500m,
                    AccountNumber = "0123456789"
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
