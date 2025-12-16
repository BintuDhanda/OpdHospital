using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpdHospital.Enums;

namespace OpdHospital.Models
{
    [Table("Appointments")]
    public class Appointment : BaseEntity
    {
        [Key]
        public long AppointmentId { get; set; }

        public AppointmentType AppointmentType { get; set; }

        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int HospitalId { get; set; }

        // Fixed-time appointment
        public DateTime? AppointmentDate { get; set; }
        public TimeSpan? AppointmentTime { get; set; }

        // Package support
        public int? PackageId { get; set; }
        public int? PackageVisitNumber { get; set; }

        public AppointmentStatus Status { get; set; }

        public decimal AppointmentFee { get; set; }
        public decimal PlatformFee { get; set; }

        public string Remarks { get; set; } = string.Empty;
    }
}
