using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpdHospital.Enums;

namespace OpdHospital.Models
{
    public class Hospital : BaseEntity
    {
        [Key]
        public int HospitalId { get; set; }

        [Required, StringLength(20)]
        public string HospitalCode { get; set; } = null!;

        [Required, StringLength(200)]
        public string HospitalName { get; set; } = null!;

        [Required]
        public HospitalType HospitalType { get; set; }

        [Required]
        public HospitalStatus Status { get; set; }

        // Contact Details
        [Required, StringLength(100)]
        public string ContactPersonName { get; set; } = null!;

        [Required, StringLength(15)]
        public string ContactMobile { get; set; } = null!;

        [EmailAddress, StringLength(150)]
        public string? ContactEmail { get; set; }

        // Address
        [Required, StringLength(250)]
        public string AddressLine1 { get; set; } = null!;

        [StringLength(250)]
        public string? AddressLine2 { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; } = null!;

        // Geo Location
        [Column(TypeName = "decimal(10,8)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(11,8)")]
        public decimal? Longitude { get; set; }

        // Registration
        [StringLength(100)]
        public string? RegistrationNumber { get; set; }

        [StringLength(100)]
        public string? RegistrationAuthority { get; set; }

        public DateTime? RegistrationValidTill { get; set; }

        [StringLength(15)]
        public string? GSTNumber { get; set; }

        // Bank Details
        [Required, StringLength(150)]
        public string BankAccountHolderName { get; set; } = null!;

        [Required, StringLength(100)]
        public string BankName { get; set; } = null!;

        [Required, StringLength(25)]
        public string AccountNumber { get; set; } = null!;

        [Required, StringLength(15)]
        public string IFSCCode { get; set; } = null!;

        [StringLength(50)]
        public string? UPIId { get; set; }

        public PayoutCycle PayoutCycle { get; set; }

        public PayoutStatus PayoutStatus { get; set; }

        // Onboarding
        public int OnboardedByUserId { get; set; }

        public DateTime OnboardedOn { get; set; }
    }
}
