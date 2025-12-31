using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class BaseEntity
    {
        [Key]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public long? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
