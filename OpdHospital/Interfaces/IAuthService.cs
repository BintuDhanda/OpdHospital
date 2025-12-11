using OpdHospital.Dtos;

namespace OpdHospital.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginRequestDto loginDto);
    }
}
