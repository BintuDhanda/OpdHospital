using Microsoft.AspNetCore.Http.HttpResults;
using OpdHospital.Dtos;
using OpdHospital.Dtos.Request;
using OpdHospital.Dtos.Response;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericService<User> _genericService;
         public UserService(IGenericService<User> genericService)
         {
            _genericService = genericService;
         }

        public async Task<LogInResponseDto> LogIn(LoginRequestDto loginRequest)
        {
            var query = _genericService.GetAllAsync();

            var user = (await query).FirstOrDefault(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password);
            
            var response = new LogInResponseDto
            {
                UserId = 1,
                UserName = loginRequest.UserName,
                Token = "dummy-jwt-token"
            };

            return response;
        }

        public Task Register(RegisterRequestDto registerRequest)
        {
            throw new NotImplementedException();
        }

        public Task ForgotPassword(ForgotPasswordRequestDto forgotPasswordRequest)
        {
            throw new NotImplementedException();
        }
    }
}
