using System;
using System.ComponentModel.DataAnnotations;
using OpdHospital.Enums;

namespace OpdHospital.Models
{
    public class Payment : BaseEntity
    {
        [Key]
        public long PaymentId { get; set; }

        public long AppointmentId { get; set; }

        /// <summary>
        /// Base appointment/service amount (GST excluded)
        /// </summary>
        public decimal AppointmentAmount { get; set; }

        /// <summary>
        /// Platform/service fee charged by app (GST excluded)
        /// </summary>
        public decimal PlatformAmount { get; set; }

        /// <summary>
        /// Total GST amount applied at payment time (snapshot)
        /// </summary>
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Final amount paid by patient (including GST)
        /// </summary>
        public decimal TotalPaidAmount { get; set; }

        public string PaymentGateway { get; set; } = "Razorpay";

        /// <summary>
        /// Razorpay / gateway payment reference id
        /// </summary>
        public string GatewayPaymentId { get; set; } = string.Empty;

        public PaymentStatus Status { get; set; }

        public DateTime PaidOn { get; set; }
    }
}
