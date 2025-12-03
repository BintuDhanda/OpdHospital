using OpdHospital.Models.Roles;
using OpdHospital.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models.UsersRoles
{
    public class UserRole
    {
        public int UserRoleId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime? AssignedAt { get; set; }
    }
}
