using OpdHospital.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models.Roles
{
    public class Role : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
