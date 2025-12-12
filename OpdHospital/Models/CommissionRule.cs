using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models
{
    public class CommissionRule : BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [ForeignKey("Partner")]
        public int? PartnerId { get; set; }
        public SalePartner Partner { get; set; }
        public string RuleType { get; set; }
        public string Recipient { get; set; }
        public decimal Value { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
