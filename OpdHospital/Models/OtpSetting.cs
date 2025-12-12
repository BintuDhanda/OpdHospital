using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class OtpSetting
    {
        [Key]
        public int Id { get; set; }
        public int Length { get; set; }
        public int ExpiryMinutes { get; set; }
        public int CooldownSeconds { get; set; }
        public int DailyLimitPerIdentifier { get; set; }
    }
}
