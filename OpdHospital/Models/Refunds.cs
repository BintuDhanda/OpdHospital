using System;
using System.ComponentModel.DataAnnotations;
using OpdHospital.Enums;

namespace OpdHospital.Models
{
    public class Refunds : BaseEntity
    {
        [Key]
        public long RefundId { get; set; }

        /// <summary>
        /// Original payment reference
        /// </summary>
        public long PaymentId { get; set; }

        /// <summary>
        /// Refunded principal amount (appointment / platform as applicable)
        /// </summary>
        public decimal RefundAmount { get; set; }

        /// <summary>
        /// Refunded GST amount (derived from PaymentTaxDetail snapshot)
        /// </summary>
        public decimal RefundTaxAmount { get; set; }

        public string Reason { get; set; } = string.Empty;

        public RefundStatus Status { get; set; }

        public DateTime RefundedOn { get; set; }
    }
}
