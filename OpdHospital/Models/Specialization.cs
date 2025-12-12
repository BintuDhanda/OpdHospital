using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class Specialization : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
