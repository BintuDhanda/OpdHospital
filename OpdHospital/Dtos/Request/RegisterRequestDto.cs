using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Dtos.Request
{
    public class RegisterRequestDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string RoleName { get; set; } 

    }
}