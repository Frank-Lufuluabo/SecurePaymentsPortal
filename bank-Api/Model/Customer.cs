using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bank_Api.IdentityAuth;

namespace bank_Api.Model
{
<<<<<<< HEAD
    public class Customer : ApplicationUser
=======
    public class Customer : User
>>>>>>> jwt-token
    {
        public required string FullName { get; set; }

        public required  string IdNumber { get; set; }

        public required decimal AvailableBalance { get; set; }

        public required string AccountNumber { get; set; } = string.Empty;

    }
}
