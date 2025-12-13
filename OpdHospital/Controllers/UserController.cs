using Microsoft.AspNetCore.Mvc;
using OpdHospital.Dtos;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Services;

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
                var result  = await _userService.LogIn(request);

                if (result == null)
                {
                    return Ok(Utilities.Response.Fail( "Invalid credentials"));
                }

                return Ok(Utilities.Response.Success(result, "Login successful"));
            });
    }
}
