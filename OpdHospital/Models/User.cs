using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class User : BaseEntity
    {
        [Key]
        public long UserId { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public bool IsMobileNumberVerified { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsEmailVerified { get; set; }
        public string Password { get; set; } = string.Empty;
        public bool IsUserLocked { get; set; }
        public int FailedAttempts { get; set; }
    }
}
