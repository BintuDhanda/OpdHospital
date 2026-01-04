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
                Email = dto.Email,
                MobileNumber = dto.MobileNumber,
                Password = new PasswordHasher<User>().HashPassword(null, dto.Password)
            };
        }

        public static LogInResponseDto ToLogInResponseDto(this User user, string token, string[] roles)
        {
            return new LogInResponseDto
            {
                UserId = user.UserId,
                Token = token,
                Roles = roles
            };
        }

        public static RegisterResponseDto ToRegisterResponseDto(this User user, string roleName, int salesPartnerId, int hospitalId, int doctorId)
        {
            return new RegisterResponseDto
            {
                UserId = user.UserId,
                Email = user.Email,
                DoctorId = doctorId,
                HospitalId = hospitalId,
                SalePartnerId = salesPartnerId,
                RoleName =  roleName
            };
        }
    }
}