using OpdHospital.Models.Base;
using OpdHospital.Models.Payments;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models.Invoicies
{
    public class Invoice : BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("Payment")]
        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
