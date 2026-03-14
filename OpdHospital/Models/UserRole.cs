namespace OpdHospital.Models
{
    public class UserRole : IEntity<long>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
    }
}
