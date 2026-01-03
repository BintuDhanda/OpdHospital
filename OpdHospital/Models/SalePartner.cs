namespace OpdHospital.Models
{
    public class SalePartner : BaseEntity
    {
        public int SalePartnerId { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? DefaultCommPct { get; set; } = 0;
        public string GstNumber { get; set; } = string.Empty;
        public string PanNumber { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string AlternateNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CityId { get; set; }
        public int PincodeId { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string BankIFSC { get; set; } = string.Empty;
        public string BankAccountNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public bool IsPayoutEnabled { get; set; } = false;
    }
}
