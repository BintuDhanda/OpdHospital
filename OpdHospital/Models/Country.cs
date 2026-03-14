using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class Country : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
