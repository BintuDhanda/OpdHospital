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
        private readonly IGenericService<Role> _roleService;
        private readonly IGenericService<UserRole> _userRoleService;
        public UserService(IGenericRepository<User> genericRepository, IGenericService<Role> roleService, IGenericService<UserRole> userRoleService, IJwtHelper jwtHelper) : base(genericRepository)
        {
            _jwtHelper = jwtHelper;
            _roleService = roleService;
            _userRoleService = userRoleService;
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

           
        
            var roleIds = await _userRoleService.GetAll()
                            .Where(ur => ur.UserId == user.UserId)
                            .Select(ur => ur.RoleId).ToListAsync();

            var roles = (await _roleService.GetAll()
                            .Where(r => roleIds.Contains(r.RoleId))
                            .Select(s=>s.Name).ToListAsync()).ToArray();

            // Generate JWT token

            var token = _jwtHelper.GenerateToken(user.UserId, user.UserName, roles);

            return Response.Success(
                user.ToLogInResponseDto(token, roles),
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
                message: "Forgot password success. your otp is 1234"
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
        public async Task<ApiResponse?> ResetPassword(ResetPasswordRequestDto request)
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

            var user = await query.FirstOrDefaultAsync();

            if (user == null)
                return Response.Fail("Reset password failed") as ApiResponse;

            // Here we should verify the OTP, but for simplicity, we skip it.

            // Update password
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, request.NewPassword);

            if(request.Otp != "1234")
                return Response.Fail("Invalid OTP") as ApiResponse;
            await base.UpdateAsync(user);

            return Response.Success(
                message: "Password reset successful"
            ) as ApiResponse;
        }
    }
}
