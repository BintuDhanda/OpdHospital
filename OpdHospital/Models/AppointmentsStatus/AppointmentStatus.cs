using OpdHospital.Models.Base;

namespace OpdHospital.Models.AppointmentsStatus
{
    public class AppointmentStatus : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
