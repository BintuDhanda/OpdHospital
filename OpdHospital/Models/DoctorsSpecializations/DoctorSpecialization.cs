using OpdHospital.Models.Base;
using OpdHospital.Models.Doctors;
using OpdHospital.Models.Specializations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models.DoctorsSpecializations
{
    public class DoctorSpecialization : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
