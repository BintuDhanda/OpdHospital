using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class Refund : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string? ProviderRefundId { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ProcessedAt { get; set; }
    }
}
