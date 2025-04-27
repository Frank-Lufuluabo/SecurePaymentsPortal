using System;
using System.ComponentModel.DataAnnotations;

namespace bank_Api.Model
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
