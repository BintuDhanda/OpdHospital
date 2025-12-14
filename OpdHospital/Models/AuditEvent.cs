using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models.Audit
{
    public class AuditEvent
    {
        [Key]
        public long AuditEventId { get; set; }

        [Required]
        public string EntityName { get; set; } = null!;

        [Required]
        public string EntityId { get; set; } = null!; // string to support GUID/int

        [Required]
        public string Action { get; set; } = null!; // INSERT / UPDATE / DELETE

        public int PerformedByUserId { get; set; }

        public DateTime PerformedOn { get; set; }

        public string? IpAddress { get; set; }

        public ICollection<AuditEventDetail> Details { get; set; }
            = new List<AuditEventDetail>();
    }
}
