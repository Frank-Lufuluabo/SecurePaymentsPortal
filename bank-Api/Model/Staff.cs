using System.ComponentModel.DataAnnotations;

namespace bank_Api.Model
{
    public class Staff : User
    {      
        public required string Position { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
    }
}
