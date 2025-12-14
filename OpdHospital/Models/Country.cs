using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class Country : BaseEntity
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

    }
}
