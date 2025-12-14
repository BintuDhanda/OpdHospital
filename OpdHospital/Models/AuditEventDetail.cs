using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models.Audit
{
    public class AuditEventDetail
    {
        [Key]
        public long AuditDetailId { get; set; }

        [ForeignKey(nameof(AuditEvent))]
        public long AuditEventId { get; set; }

        [Required]
        public string ColumnName { get; set; } = null!;

        public string? OldValue { get; set; }

        public string? NewValue { get; set; }

        public AuditEvent AuditEvent { get; set; } = null!;
    }
}
