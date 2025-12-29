using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models
{
    public class Invoice : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
