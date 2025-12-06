using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
