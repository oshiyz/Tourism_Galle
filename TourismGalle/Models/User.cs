using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourismGalle.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, NotMapped] // Add this attribute
        public string Password { get; set; } // For API input only (not stored in DB)

        [Required]
        public string PasswordHash { get; set; } // Store hashed password

        public string Role { get; set; } = "User";
    }
}