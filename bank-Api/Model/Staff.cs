using System.ComponentModel.DataAnnotations;

namespace bank_Api.Model
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
