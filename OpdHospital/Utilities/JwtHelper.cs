using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OpdHospital.Utilities
{
    public interface IJwtHelper
    {
        string GenerateToken(long userId, string email, string mobileNumber, string[] role);
        long GetUserId();
    }

    public class JwtHelper : IJwtHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<JwtHelper> _logger;

        public JwtHelper()
        {
        }

        public JwtHelper(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            ILogger<JwtHelper> logger)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        // ===================== GENERATE JWT =====================

        public string GenerateToken(long userId, string email, string mobileNumber, string[] role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.MobilePhone, mobileNumber),
                new Claim(ClaimTypes.Role, string.Join(",", role))
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(AppSettings.JwtKey));

            var creds = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: AppSettings.JwtIssuer,
                audience: AppSettings.JwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // ===================== GET USER ID =====================

        public long GetUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                _logger?.LogWarning("HttpContext is null in GetUserId");
                return 0;
            }

            if (httpContext.User.Identity?.IsAuthenticated != true)
            {
                _logger?.LogWarning("User is not authenticated in GetUserId");
                return 0;
            }

            var userIdClaim = httpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                _logger?.LogWarning("NameIdentifier claim not found in GetUserId");
                return 0;
            }

            if (!long.TryParse(userIdClaim.Value, out var userId))
            {
                _logger?.LogWarning("Failed to parse userId claim value: {Value}", userIdClaim.Value);
                return 0;
            }

            return userId;
        }
    }
}
