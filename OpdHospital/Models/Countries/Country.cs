using OpdHospital.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models.Countries
{
    public class Country : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
    }
}
