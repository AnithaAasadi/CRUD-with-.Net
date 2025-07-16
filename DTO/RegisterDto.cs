using System.ComponentModel.DataAnnotations;

namespace CRUD.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; } = "User"; // Optional override
    }

}
