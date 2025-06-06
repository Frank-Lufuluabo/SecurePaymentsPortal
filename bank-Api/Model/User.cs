using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank_Api.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string EmployeeId { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;

        [Required]
    
        public string Password { get; set; } = string.Empty;

        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty; 

        public bool IsAuthenticated { get; set; } = false;
    }
}

