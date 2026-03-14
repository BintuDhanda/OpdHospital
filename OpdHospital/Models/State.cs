using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class State : BaseEntity, IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; } = string.Empty;
    }
}
