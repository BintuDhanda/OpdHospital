using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class User : BaseEntity
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsUserLocked { get; set; }
        public int FailedAttempts { get; set; }
    }
}
