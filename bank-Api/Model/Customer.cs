using System;
using System.ComponentModel.DataAnnotations;

namespace bank_Api.Model
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string IdNumber { get; set; }

        public string Role { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
