using OpdHospital.Dtos.LoginsDto;

namespace OpdHospital.Interfaces.IAuthsServices
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
