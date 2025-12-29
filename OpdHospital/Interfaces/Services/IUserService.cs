// generated interface for IUserService
using OpdHospital.Dtos;
using OpdHospital.Dtos.Request;

using OpdHospital.Utilities;


namespace OpdHospital.Interfaces
{
    public interface IUserService
    {
        public Task<ApiResponse?> LogIn(LoginRequestDto loginRequest);
        public Task<ApiResponse?> Register(RegisterRequestDto registerRequest);
        public Task<ApiResponse?> ForgotPassword(ForgotPasswordRequestDto forgotPasswordRequest);
        public Task<ApiResponse?> IsUsernameAvailable(string username);
    }
}  