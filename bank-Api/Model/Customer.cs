using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank_Api.Model
{
    public class Customer : User
    {
        public required string FullName { get; set; }

        public required  string IdNumber { get; set; }

        public required decimal AvailableBalance { get; set; }

        public required string AccountNumber { get; set; } = string.Empty;

    }
}
