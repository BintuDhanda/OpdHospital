using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class City : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
    }
}
