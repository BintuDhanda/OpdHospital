using System.ComponentModel.DataAnnotations;
using OpdHospital.Enums;
namespace OpdHospital.Models
{
    public class AnyTimeAppointments : BaseEntity
    {
        [Key]
        public int AnyTimeAppointmentId { get; set; }
        public int AppointmentTypeId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int HospitalId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public int StatusId { get; set; }
        public AppointmentStatus Status { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}