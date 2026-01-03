using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpdHospital.Dtos;
using OpdHospital.Dtos.Request;
using OpdHospital.Dtos.Response;
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
        private readonly IGenericService<SalePartner> _salesPartnerService;
        private readonly IGenericService<Hospital> _hospitalService;
        private readonly IGenericService<Doctor> _doctorService;
        private readonly IGenericService<OtpRequest> _otpRequestService;
        public UserService(IGenericRepository<User> genericRepository,
        IGenericService<Role> roleService,
        IGenericService<UserRole> userRoleService,
        IJwtHelper jwtHelper,
        IGenericService<SalePartner> salesPartnerService,
        IGenericService<Hospital> hospitalService,
        IGenericService<Doctor> doctorService,
        IGenericService<OtpRequest> otpRequestService)
        : base(genericRepository)
        {
            _jwtHelper = jwtHelper;
            _roleService = roleService;
            _userRoleService = userRoleService;
            _salesPartnerService = salesPartnerService;
            _hospitalService = hospitalService;
            _doctorService = doctorService;
            _otpRequestService = otpRequestService;
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
                            .Select(s => s.Name).ToListAsync()).ToArray();

            // Generate JWT token

            var token = _jwtHelper.GenerateToken(user.UserId, user.UserName, roles);

            return Response.Success(
                user.ToLogInResponseDto(token, roles),
                "Login successful"
            ) as ApiResponse;
        }

        public async Task<ApiResponse?> Register(RegisterRequestDto registerRequest)
        {
            if (string.IsNullOrWhiteSpace(registerRequest.RoleName))
                return Response.Fail("Role is required") as ApiResponse;

            // geneate User Name based on the role 
            registerRequest.Username = await UsernameHelper.GenerateUniqueUsernameAsync(registerRequest.RoleName, async username => await GetAll().AnyAsync(u => u.UserName == username));
            // 1. Map User
            var user = UserMapper.ToEntity(registerRequest);

            // user name exists 

            if (await base.GetAll().AnyAsync(a => a.UserName == registerRequest.Username))
                return Response.Fail("User name already Exists") as ApiResponse;

            // 2. Fetch Role
            var role = await _roleService.GetAll()
                .FirstOrDefaultAsync(r => r.Name == registerRequest.RoleName);

            if (role == null)
                return Response.Fail("Invalid role") as ApiResponse;

            // 3. Save User
            var savedUser = await AddAsync(user);

            if (savedUser == null)
                return Response.Fail("Registration failed") as ApiResponse;

            // 4. Map User-Role
            await _userRoleService.AddAsync(new UserRole
            {
                UserId = savedUser.UserId,
                RoleId = role.RoleId
            });


            // Return Record Id & Role
            int salesPartnerId = 0;
            int hospitalId = 0;
            int doctorId = 0;
            long createdBy = _jwtHelper.GetUserId();

            // 5. Role-specific entity creation
            switch (role.Name.ToLower())
            {
                case "patient":
                    break;

                case "doctor":
                    var resultDoctor = await _doctorService.AddAsync(new Doctor
                    {
                        UserId = user.UserId,
                        FullName = "NEW_ADDED",
                        CreatedAt = DateTime.Now,
                        CreatedBy = createdBy
                    });
                    doctorId = resultDoctor.DoctorId;
                    break;

                case "hospital":
                    var resultHospital = await _hospitalService.AddAsync(new Hospital
                    {
                        UserId = savedUser.UserId,
                        HospitalName = "NEW_ADDED",
                        CreatedAt = DateTime.Now,
                        CreatedBy = createdBy
                    });
                    hospitalId = resultHospital.HospitalId;
                    break;

                case "salepartner":
                    var resultSalesPartner = await _salesPartnerService.AddAsync(new SalePartner
                    {
                        UserId = savedUser.UserId,
                        Name = "NEW_ADDED",
                        CreatedAt = DateTime.Now,
                        CreatedBy = createdBy
                    });
                    salesPartnerId = resultSalesPartner.SalePartnerId;
                    break;

                default:
                    return Response.Fail("Role handling not implemented") as ApiResponse;
            }

            return Response.Success(
                UserMapper.ToRegisterResponseDto(savedUser, registerRequest.RoleName, salesPartnerId, hospitalId, doctorId),
                "Registration successful"
            ) as ApiResponse;
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

            if (request.Otp != "1234")
                return Response.Fail("Invalid OTP") as ApiResponse;
            await base.UpdateAsync(user);

            return Response.Success(
                message: "Password reset successful"
            ) as ApiResponse;
        }
        public async Task<ApiResponse?> SendOtpAsync(string mobileNumber)
        {
            // 1. Generate OTP
            //var otp = Random.Shared.Next(100000, 999999).ToString();
            var otp = "12345";
            // 2. Hash OTP

            var otpHash = GetHash(otp);

            // 3. Save OTP record
            var otpEntry = new OtpRequest
            {
                MobileNumber = mobileNumber,
                OtpHash = otpHash,
                ExpiryAt = DateTime.UtcNow.AddMinutes(5),
                AttemptCount = 0
            };

            await _otpRequestService.AddAsync(otpEntry);

            // 4. Send SMS (mock for now)
            // _smsService.Send(mobileNumber, $"Your OTP is {otp}");

            var response = new SendOtpResponse()
            {
                OtpReference = otpEntry.Id.ToString(),
                ExpiryAt = otpEntry.ExpiryAt

            };

            return Response.Success(response, "otp sent successfully") as ApiResponse;
        }
        public async Task<ApiResponse?> VerifyOtpAsync(OtpVerifyRequestDto request)
        {
            var otpHash = GetHash(request.Otp);

            var otpEntry = await _otpRequestService.GetAll().FirstOrDefaultAsync(f => f.MobileNumber == request.MobileNumber && f.OtpHash == otpHash);

            if (otpEntry == null)
                return Response.Fail("Invalid OTP request") as ApiResponse;

            // 1. Check expiry
            if (otpEntry.ExpiryAt < DateTime.UtcNow)
                return Response.Fail("OTP expired") as ApiResponse;

            // 2. Check attempts
            if (otpEntry.AttemptCount >= 3)
                return Response.Fail("Too many invalid attempts") as ApiResponse;

            // 3. Hash incoming OTP
           

            // 4. Compare hash
            if (otpHash != otpEntry.OtpHash)
            {
                otpEntry.AttemptCount++;
                await _otpRequestService.UpdateAsync(otpEntry);
                return Response.Fail("Invalid OTP") as ApiResponse;
            }

            // 5. OTP valid → login or auto-register user
            var user = await base.GetAll().FirstOrDefaultAsync(f=>f.MobileNumber == otpEntry.MobileNumber);

            if (user == null)
            {
                user = new User
                {
                    MobileNumber = otpEntry.MobileNumber,
                    IsUserLocked = false
                };
               user =  await base.AddAsync(user);
            }

            var roles = new string[]{"Patient"};

            // 6. Generate JWT
            var token = _jwtHelper.GenerateToken(user.UserId, user.MobileNumber, roles);
    
            // 7. Cleanup OTP
            await _otpRequestService.DeleteAsync(otpEntry.Id);

            var verifyOtpResponse = new VerifyOtpResponse()
            {
                 Token = token,
                Roles = roles,
                 UserId = user.UserId
            };

            return Response.Success(verifyOtpResponse, "Login successful") as ApiResponse;
        }

        private string GetHash(string data)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes("secretKey"));
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(data)));
        }
    }
}
