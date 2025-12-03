using OpdHospital.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace OpdHospital.Models.Patients
{
    public class Patient : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
    }
}
