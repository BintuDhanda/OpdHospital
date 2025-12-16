using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class State : BaseEntity
    {
        [Key]
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; } = string.Empty;
    }
}
