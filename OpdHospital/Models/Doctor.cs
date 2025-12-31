using System.ComponentModel.DataAnnotations;
using OpdHospital.Enums;

namespace OpdHospital.Models
{
    public class Doctor : BaseEntity
    {
        [Key]
        public int DoctorId { get; set; }
        public int HospitalId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public Gender Gender { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public SpecializationType Department { get; set; }
    }
}
