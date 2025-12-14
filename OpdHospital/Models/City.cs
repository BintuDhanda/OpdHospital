using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class City : BaseEntity
    {
        [Key]
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
    }
}
