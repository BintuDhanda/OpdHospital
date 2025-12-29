using Microsoft.AspNetCore.Identity;
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
        private readonly IJwtHelper _jwtHelper;
        public UserService(IGenericRepository<User> genericRepository, IJwtHelper jwtHelper) : base(genericRepository)
        {
            _jwtHelper = jwtHelper;
        }

        public async Task<ApiResponse?> LogIn(LoginRequestDto loginRequest)
        {
            var query = GetAll(); // IQueryable<User>

            // Identify login type
            if (loginRequest.UserName.Contains("@"))
            {
                query = query.Where(u => u.Email == loginRequest.UserName);
            }
            else if (loginRequest.UserName.All(char.IsDigit))
            {
                query = query.Where(u => u.MobileNumber == loginRequest.UserName);
            }
            else
            {
                query = query.Where(u => u.UserName == loginRequest.UserName);
            }

            var user = await query.FirstOrDefaultAsync();

            if (user == null)
                return Response.Fail("Invalid credentials") as ApiResponse;

            // Verify password
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(
                user,
                user.Password,
                loginRequest.Password
            );

            if (result == PasswordVerificationResult.Failed)
                return Response.Fail("Invalid credentials") as ApiResponse;

            // Generate JWT token
            var roles = new string[] { "Admin" };
            var token = _jwtHelper.GenerateToken(user.UserId, user.UserName, roles);

            return Response.Success(
                user.ToLogInResponseDto(token),
                "Login successful"
            ) as ApiResponse;
        }

        public async Task<ApiResponse?> Register(RegisterRequestDto registerRequest)
        {
            var user = UserMapper.ToEntity(registerRequest);
            var result = await AddAsync(user);

            if (result == null) return Response.Fail("Registration failed") as ApiResponse;
            else return Response.Success(UserMapper.ToRegisterResponseDto(result), "Registration successful") as ApiResponse;
        }

        public async Task<ApiResponse?> ForgotPassword(ForgotPasswordRequestDto request)
        {
            var query = GetAll(); // IQueryable<User>

            if (request.UserName.Contains("@"))
            {
                query = query.Where(u => u.Email == request.UserName);
            }
            else if (request.UserName.All(char.IsDigit))
            {
                query = query.Where(u => u.MobileNumber == request.UserName);
            }
            else
            {
                query = query.Where(u => u.UserName == request.UserName);
            }

            var userExists = await query.AnyAsync();

            if (!userExists)
                return Response.Fail("Forgot password failed") as ApiResponse;

            return Response.Success(
                message: "Forgot password success"
            ) as ApiResponse;
        }

        public async Task<ApiResponse?> IsUsernameAvailable(string username)
        {
            var query = GetAll();
            query = query.Where(u => u.UserName == username);
            var user = await query.FirstOrDefaultAsync();
            if (user == null) return Response.Success(true, "Username is available") as ApiResponse;
            else return Response.Success(false, "Username is taken") as ApiResponse;
        }
    }
}
