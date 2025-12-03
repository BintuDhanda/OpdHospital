using OpdHospital.Models.Base;
using OpdHospital.Models.States;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models.Cities
{
    public class City : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }
        public string Name { get; set; }
        public bool IsMetroBit { get; set; }
    }
}
