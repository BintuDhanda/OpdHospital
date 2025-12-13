using Microsoft.EntityFrameworkCore;
using OpdHospital.Dtos;
using OpdHospital.Dtos.Request;
using OpdHospital.Interfaces;
using OpdHospital.Mappers;
using OpdHospital.Models;
using OpdHospital.Utilities;

namespace OpdHospital.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(IGenericRepository<User> genericRepository) : base(genericRepository)
        {

        }

        public async Task<ApiResponse?> LogIn(LoginRequestDto loginRequest)
        {

            IQueryable<User> query = GetAll();

            var response = new ApiResponse();

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
            {
                response = Response.Fail("Invalid credentials") as ApiResponse;
            }
            else
            {
                response = Response.Success(user.ToLogInResponseDto("DummyToken"), "Login successful") as Utilities.ApiResponse;
            }
             
             return response;

        }


        public async Task<ApiResponse?> Register(RegisterRequestDto registerRequest)
        {
            var user = UserMapper.ToEntity(registerRequest);
            var response = new ApiResponse(); 

            var result = await AddAsync(user);

            if (result == null)
            {
                response = Response.Fail("Registration failed") as ApiResponse;
            }
            else
            {
                response = Response.Success(UserMapper.ToRegisterResponseDto(result), "Registration successful") as ApiResponse;
            }

            return response;

        }

        public async Task<ApiResponse?> ForgotPassword(ForgotPasswordRequestDto forgotPasswordRequest)
        {
            var query = GetAll();

            var response = new ApiResponse();
            
            if (forgotPasswordRequest.UserName.Contains("@"))
            {
                query = query.Where(u => u.Email == forgotPasswordRequest.UserName);
            }
            else
            {
                query = query.Where(u => u.UserName == forgotPasswordRequest.UserName);
            }

            var user = query.FirstOrDefault();


            if (user == null)
            {
                response = Response.Fail("User not found") as ApiResponse;
            }
            else
            {
                response = Response.Success(message: "Password reset instructions sent") as ApiResponse;
            }

            return response;
        }
    }
}
