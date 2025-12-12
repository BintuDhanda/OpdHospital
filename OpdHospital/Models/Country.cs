using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class Country : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
    }
}
