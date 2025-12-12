using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using OpdHospital.Database;
using OpdHospital.Dtos;
using OpdHospital.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OpdHospital.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;

        public AuthService(IUserRepository userRepository, IConfiguration configuration, AppDbContext appDbContext)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _appDbContext = appDbContext;
        }

        public Task<string> LoginAsync(LoginRequestDto loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
