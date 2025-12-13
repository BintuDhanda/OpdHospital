// generated interface for IUserService
using OpdHospital.Dtos;
using OpdHospital.Dtos.Request;
using OpdHospital.Dtos.Response;


namespace OpdHospital.Interfaces
{
    public interface IUserService
    {
        public Task<LogInResponseDto?> LogIn(LoginRequestDto loginRequest);
        public Task Register(RegisterRequestDto registerRequest);
        public Task ForgotPassword(ForgotPasswordRequestDto forgotPasswordRequest);
    }
}  