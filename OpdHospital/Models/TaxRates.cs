using System;
using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class TaxRate : BaseEntity
    {
        [Key]
        public int TaxRateId { get; set; }

        /// <summary>
        /// Example values:
        /// APPOINTMENT_GST
        /// PLATFORM_GST
        /// PACKAGE_GST
        /// </summary>
        public string TaxCode { get; set; } = string.Empty;

        /// <summary>
        /// GST percentage (e.g. 5, 12, 18)
        /// </summary>
        public decimal RatePercent { get; set; }

        /// <summary>
        /// Date from which this GST rate is effective
        /// </summary>
        public DateTime EffectiveFrom { get; set; }

        /// <summary>
        /// Date until which this GST rate is valid (NULL = currently active)
        /// </summary>
        public DateTime? EffectiveTo { get; set; }

        /// <summary>
        /// Soft flag for faster lookup
        /// </summary>
        public bool IsActive { get; set; }
    }
}
