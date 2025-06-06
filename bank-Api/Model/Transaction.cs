using System;
using System.ComponentModel.DataAnnotations;

namespace bank_Api.Model
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string RecipientAccount { get; set; }
        public string SwiftCode { get; set; }
        public string RecipientName { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string Reference { get; set; }
        public bool Verified { get; set; }

        public DateTime Date { get; set; }
    }
}
