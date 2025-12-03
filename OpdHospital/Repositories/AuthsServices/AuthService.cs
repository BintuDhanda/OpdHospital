using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using OpdHospital.Database;
using OpdHospital.Dtos.LoginsDto;
using OpdHospital.Interfaces.IAuthsServices;
using OpdHospital.Interfaces.IUsersRepositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OpdHospital.Repositories.AuthsServices
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

        public Task<string> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
