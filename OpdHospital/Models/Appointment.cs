using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models
{
    public class Appointment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        [ForeignKey("TimeSlot")]
        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string BookingReference { get; set; }
        public bool IsReschedule { get; set; }
        public string RescheduleReason { get; set; }
        public int? RescheduledByUserId { get; set; }
        public User RescheduledByUser { get; set; }
        public DateTime? RescheduledAt { get; set; }
        public DateTime? OriginalAppointmentDate { get; set; }
        public int? OriginalTimeSlotId { get; set; }
        public TimeSlot OriginalTimeSlot { get; set; }
        public string Remarks { get; set; }
    }
}
