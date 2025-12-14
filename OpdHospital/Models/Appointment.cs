using System.ComponentModel.DataAnnotations;
using OpdHospital.Enums;

namespace OpdHospital.Models
{
    public class Appointment : BaseEntity
    {
        [Key]
        public Int64 AppointmentId { get; set; }
        public int AppointmentTypeId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int TimeSlotId { get; set; }
        public int StatusId { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsReschedule { get; set; }
        public string RescheduleReason { get; set; } = string.Empty;
        public int? RescheduledByUserId { get; set; }
        public DateTime? RescheduledAt { get; set; }
        public int? OriginalAppointmentId { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}
