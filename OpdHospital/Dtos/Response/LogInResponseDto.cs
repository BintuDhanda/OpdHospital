// generate login response dto
using OpdHospital.Models;
namespace OpdHospital.Dtos.Response
{
    public class LogInResponseDto
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}