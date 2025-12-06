using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models
{
    public class OpdVisit : BaseEntity
    {
        public int Id { get; set; }
        public string VisitNumber { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [ForeignKey("Partner")]
        public int? PartnerId { get; set; }
        public SalePartner Partner { get; set; }
        public DateTime VisitDate { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("PaymentStatus")]
        public int PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsPaid { get; set; }
        public string Notes { get; set; }
    }
}
