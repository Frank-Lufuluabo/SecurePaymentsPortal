using System.ComponentModel.DataAnnotations;
using bank_Api.IdentityAuth;

namespace bank_Api.Model
{
<<<<<<< HEAD
    public class Staff : ApplicationUser
    {
        public int Id { get; set; }
=======
    public class Staff : User
    {      
        public required string Position { get; set; }
>>>>>>> jwt-token

        [EmailAddress]
        public required string Email { get; set; }
    }
}
