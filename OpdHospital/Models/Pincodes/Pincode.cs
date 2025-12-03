using OpdHospital.Models.Base;
using OpdHospital.Models.Cities;
using OpdHospital.Models.States;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models.Pincodes
{
    public class Pincode : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string PinCode { get; set; }
        public string AreaName { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
