    using Microsoft.AspNetCore.Mvc;
    using OpdHospital.Dtos;
    using OpdHospital.Dtos.Request;
    using OpdHospital.Interfaces;
    using OpdHospital.Models;


    namespace OpdHospital.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class UserController : GenericController<User>
        {
            private readonly IUserService _userService;
            public UserController(IGenericService<User> service, IUserService userService ) : base(service)
            {
                _userService = userService;
            }

            
            [HttpPost("login")]
            public Task<IActionResult> LogIn([FromBody] LoginRequestDto request) =>
                SafeExecute(async () =>
                {
                    return Ok(await _userService.LogIn(request));
                });

            [HttpPost("register")]
            public Task<IActionResult> Register([FromBody] RegisterRequestDto request) =>
                SafeExecute(async () =>
                {
                    return Ok(await _userService.Register(request));
                });

            [HttpPost("forgot-password")]
            public Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto request) =>
                SafeExecute(async () =>
                {
                    return Ok(await _userService.ForgotPassword(request));
                });

            [HttpGet("IsUsernameAvailable/{username}")]
            public Task<IActionResult> IsUsernameAvailable(string username) =>
                SafeExecute(async () =>
                {
                    return Ok(await _userService.IsUsernameAvailable(username));
                });

            [HttpPost("ResetPassword")]
            public Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto request) =>
                SafeExecute(async () =>
                {
                    return Ok(await _userService.ResetPassword(request));
                });

           [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpRequest request)
        {
            return await SafeExecute(async () =>
            {
                var result = await _userService.SendOtpAsync(request.MobileNumber);
                return Ok(result);
            });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpVerifyRequestDto request)
        {
            return await SafeExecute(async () =>
            {
                var result = await _userService.VerifyOtpAsync(request);
                return Ok(result);
            });
        }

        }
    }
