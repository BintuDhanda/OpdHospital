using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class PaymentTaxDetail : BaseEntity
    {
        [Key]
        public long PaymentTaxDetailId { get; set; }

        public long PaymentId { get; set; }

        /// <summary>
        /// Example values:
        /// APPOINTMENT_GST
        /// PLATFORM_GST
        /// </summary>
        public string TaxCode { get; set; } = string.Empty;

        /// <summary>
        /// GST percentage applied at payment time (snapshot)
        /// </summary>
        public decimal TaxRatePercent { get; set; }

        /// <summary>
        /// Amount on which GST is calculated
        /// </summary>
        public decimal TaxableAmount { get; set; }

        /// <summary>
        /// Calculated GST amount
        /// </summary>
        public decimal TaxAmount { get; set; }
    }
}
