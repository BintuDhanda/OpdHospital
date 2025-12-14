using OpdHospital.Enums;

namespace OpdHospital.Models
{
    public class FixedTimeAppointments : BaseEntity
    {
        public long FixedTimeAppointmentId { get; set; }
        public int AppointmentTypeId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int HospitalId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public string BookingReference { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}