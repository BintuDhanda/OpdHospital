using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OpdHospital.Dtos;
using OpdHospital.Dtos.Request;
using OpdHospital.Dtos.Response;
using OpdHospital.Interfaces;
using OpdHospital.Mappers;
using OpdHospital.Models;

namespace OpdHospital.Services
{
    public class UserService : GenericService<User>, IUserService
    {
         public UserService(IGenericRepository<User> genericRepository) : base(genericRepository)
         {
            
         }

      public async Task<LogInResponseDto?> LogIn(LoginRequestDto loginRequest)
        {
            IQueryable<User> query = GetAll();

            if (loginRequest.UserName.Contains("@"))
            {
                query = query.Where(u => u.Email == loginRequest.UserName);
            }
            else
            {
                query = query.Where(u => u.UserName == loginRequest.UserName);
            }

            query = query.Where(u => u.Password == loginRequest.Password);

            var user = await query.FirstOrDefaultAsync();

            if (user == null)
                return null;

            return user.ToLogInResponseDto("DummyToken");
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
