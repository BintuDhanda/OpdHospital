using System.ComponentModel.DataAnnotations.Schema;

namespace OpdHospital.Models
{
    public class SalePartner : BaseEntity
    {
        public int Id { get; set; }
        public string PartnerCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal? DefaultCommPct { get; set; }
        public string CommissionType { get; set; }
        public string GstNumber { get; set; }
        public string PanNumber { get; set; }
        public string ContactInfo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }
        [ForeignKey("Pincode")]
        public int PincodeId { get; set; }
        public Pincode Pincode { get; set; }
        public decimal CreditLimit { get; set; }
        public string Remarks { get; set; }
    }
}
