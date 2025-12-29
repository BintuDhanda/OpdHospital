// Generate UserMapper class for DTo 
using Microsoft.AspNetCore.Identity;
using OpdHospital.Dtos.Request;
using OpdHospital.Dtos.Response;
using OpdHospital.Models;  

namespace OpdHospital.Mappers
{
    public static class UserMapper
    {
        public static User ToEntity(this RegisterRequestDto dto)
        {
            return new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                Password = new PasswordHasher<User>().HashPassword(null, dto.Password)
            };
        }

        public static LogInResponseDto ToLogInResponseDto(this User user, string token)
        {
            return new LogInResponseDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Token = token
            };
        }

        public static RegisterResponseDto ToRegisterResponseDto(this User user)
        {
            return new RegisterResponseDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email
            };
        }
    }
}