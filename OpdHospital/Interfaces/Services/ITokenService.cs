using OpdHospital.Models;

namespace OpdHospital.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken (User user);
        public DateTime GetExpiry();
    }
}
