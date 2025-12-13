using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OpdHospital.Dtos;
using OpdHospital.Dtos.Request;
using OpdHospital.Dtos.Response;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class UserService : GenericService<User>, IUserService
    {
         public UserService(IGenericRepository<User> genericRepository) : base(genericRepository)
         {
            
         }

        public async Task<LogInResponseDto> LogIn(LoginRequestDto loginRequest)
        {
            var query = await GetAllAsync();

            var user = query.FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password);
            
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
