using System.ComponentModel.DataAnnotations;
using OpdHospital.Enums;

namespace OpdHospital.Models
{
    public class Hospital : BaseEntity
    {
        [Key]
        public int HospitalId { get; set; }
        public string HospitalName { get; set; } = null!;
        public HospitalType HospitalType { get; set; }
        public HospitalStatus Status { get; set; }
        public string ContactPersonName { get; set; } = string.Empty!;
        public string ContactMobile { get; set; } = string.Empty!;
        public string ContactEmail { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty!;
        public string AddressLine2 { get; set; } = string.Empty;
        public int CityId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public string RegistrationAuthority { get; set; } = string.Empty;
        public DateTime? RegistrationValidTill { get; set; }
        public string GSTNumber { get; set; } = string.Empty;
        public string BankAccountHolderName { get; set; } = string.Empty!;
        public string BankName { get; set; } = string.Empty!;
        public string AccountNumber { get; set; } = string.Empty!;
        public string IFSCCode { get; set; } = string.Empty;
        public PayoutCycle PayoutCycle { get; set; }
        public PayoutStatus PayoutStatus { get; set; }
        public long OnboardedByUserId { get; set; }
        public DateTime OnboardedOn { get; set; }
    }
}
