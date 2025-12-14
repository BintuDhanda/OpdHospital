// generate class for any_time_appointments table
using System.ComponentModel.DataAnnotations.Schema;
namespace OpdHospital.Models
{
    public class AnyTimeAppointments : BaseEntity
    {
        public int Id { get; set; }
        public int AppointmentTypeId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public AppointmentStatus Status { get; set; }

        public string BookingReference { get; set; }
        public string Remarks { get; set; }
    }
}