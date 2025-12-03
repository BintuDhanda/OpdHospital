using OpdHospital.Models.Base;
using OpdHospital.Models.Countries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models.States
{
    public class State : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
        public string StateCode { get; set; }
    }
}
