using Microsoft.IdentityModel.Tokens;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OpdHospital.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expiresMinutes;

        public TokenService(IConfiguration config)
        {
            _config = config;

            var keyString = _config["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(keyString))
                throw new ArgumentNullException("Jwt:Key is missing in configuration");

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));

            _issuer = _config["Jwt:Issuer"] ?? "MyApp";
            _audience = _config["Jwt:Audience"] ?? "MyAppUsers";

            if (!int.TryParse(_config["Jwt:ExpiresMinutes"], out _expiresMinutes))
                _expiresMinutes = 60;
        }

        public string CreateToken(User user)
        {
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim("Name", user.UserName ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            if (!string.IsNullOrEmpty(user.Email))
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            if (!string.IsNullOrEmpty(user.MobileNumber))
                claims.Add(new Claim("mobile", user.MobileNumber));

            if (user.Roles != null)
            {
                foreach (var role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expiresMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public DateTime GetExpiry() => DateTime.UtcNow.AddMinutes(_expiresMinutes);
    }
}
