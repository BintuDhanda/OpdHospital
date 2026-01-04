using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Dtos.Request
{
    public class RegisterRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}