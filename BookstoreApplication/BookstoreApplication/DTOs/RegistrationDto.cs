using System.ComponentModel.DataAnnotations;

namespace BookstoreApplication.DTOs
{
    public class RegistrationDto
    {
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        [MinLength(3)]
        public string Surname { get; set; }
    }
}
