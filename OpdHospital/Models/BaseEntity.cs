using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public long? CreatedBy { get; set; }

        public long? UpdatedBy { get; set; }
    }
}
