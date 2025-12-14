// generate model class for Appointment Packages table
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OpdHospital.Models
{
    [Table("AppointmentPackages")]
    public class AppointmentPackages
    {
        [Key]
        public int PackageId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PackageName { get; set; }

       public int DoctorId { get; set; }
       public int TotalVisits { get; set; }
       public decimal PackageAmount { get; set; }

    }
}