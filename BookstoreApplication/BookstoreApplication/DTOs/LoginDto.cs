using System.ComponentModel.DataAnnotations;

namespace BookstoreApplication.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
