// generate RegisterResponseDto class
namespace OpdHospital.Dtos.Response
{
    public class RegisterResponseDto
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int SalePartnerId {get ;set;}
        public int HospitalId { get; set; }
        public int DoctorId { get; set; }
        public string RoleName { get; set; }
    }
}