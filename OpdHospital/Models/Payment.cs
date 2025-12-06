using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models
{
    public class Payment : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        [ForeignKey("PaymentMethod")]
        public int? PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        [ForeignKey("PaymentStatus")]
        public int PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string ProviderTransactionId { get; set; }
        public DateTime? PaidAt { get; set; }
        public bool Refundable { get; set; } = false;
        public decimal? RefundAmount { get; set; }
        public string Notes { get; set; }
    }
}
