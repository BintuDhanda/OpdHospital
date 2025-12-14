namespace OpdHospital.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime? AssignedAt { get; set; }
    }
}
