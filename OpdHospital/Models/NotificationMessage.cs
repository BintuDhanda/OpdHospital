using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class NotificationMessage : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public NotificationType Type { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public NotificationStatus Status { get; set; } = NotificationStatus.Pending;
        public DateTime? SentAt { get; set; }
        public string? Error { get; set; }
    }
}
