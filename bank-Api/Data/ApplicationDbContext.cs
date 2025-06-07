using Microsoft.EntityFrameworkCore;
using bank_Api.Model;

namespace bank_Api.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    EmployeeId = "emp001",
                    Password = "password123", 
                    Name = "Franck ",
                    Role = "employee",
                    IsAuthenticated = false
                },
                new User
                {
                    UserId = 2,
                    EmployeeId = "em002",
                    Password = "password123",
                    Name = "Bob",
                    Role = "employee",
                    IsAuthenticated = false
                }
            );
        }
    }
}
