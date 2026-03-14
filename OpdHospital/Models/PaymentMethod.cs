using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class PaymentMethod : BaseEntity, IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
