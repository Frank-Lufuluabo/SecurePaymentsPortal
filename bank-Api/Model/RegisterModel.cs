using System.ComponentModel.DataAnnotations;

namespace bank_Api.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Password is required")]
        public string Password { get; set; }
      
    }
}
