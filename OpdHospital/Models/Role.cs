using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class Role : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
