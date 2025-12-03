using OpdHospital.Models.Base;
using OpdHospital.Models.Cities;
using OpdHospital.Models.States;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models.Hospitals
{
    public class Hospital : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public string Address { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }

    }
}
