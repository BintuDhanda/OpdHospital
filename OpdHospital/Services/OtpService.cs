using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using OpdHospital.Database;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using System.Security.Cryptography;

namespace OpdHospital.Services
{
    public class OtpService
    {
        private readonly AppDbContext _db;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly IMemoryCache _cache;
        private readonly OtpSetting _otp;
        private readonly ILogger<OtpService> _log;

        public OtpService(AppDbContext db, IEmailSender emailSender, ISmsSender smsSender,
            IMemoryCache cache, IOptions<OtpSetting> otp, ILogger<OtpService> log)
        {
            _db = db;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _cache = cache;
            _otp = otp.Value;
            _log = log;

        }

        private string GenerateNumericOtp()
        {
            var bytes = RandomNumberGenerator.GetBytes(8);
            var num = BitConverter.ToUInt64(bytes, 0) % (ulong)BigIntegerPow(10, _otp.Length);
            return num.ToString($"D{_otp.Length}");
        }

        private static ulong BigIntegerPow(int b, int exp)
        {
            ulong result = 1;
            for (int i = 0; i < exp; i++) result *= (ulong)b;
            return result;
        }

        public async Task<(bool Ok, string Message)> SendOtpAsync(string identifier, CancellationToken ct = default)
        {
            identifier = identifier.Trim();

            var cooldownKey = $"otp-cooldown:{identifier}";
            if (_cache.TryGetValue(cooldownKey, out _))
            {
                return (false, $"Please wait {_otp.CooldownSeconds} seconds before requesting another OTP.");
            }

            var today = DateTime.UtcNow.Date;
            var sentToday = await _db.PasswordResetTokens
                .CountAsync(t => t.Identifier == identifier && t.CreatedAt >= today, ct);

            if (sentToday >= _otp.DailyLimitPerIdentifier)
                return (false, "You have reached today's OTP request limit.");

            var otp = GenerateNumericOtp();

            var token = new PasswordResetToken
            {
                Identifier = identifier,
                Otp = otp,
                ExpiresAt = DateTime.UtcNow.AddMinutes(_otp.ExpiryMinutes),
                CreatedAt = DateTime.UtcNow,
                Used = false
            };

            _db.PasswordResetTokens.Add(token);
            await _db.SaveChangesAsync(ct);

            _cache.Set(cooldownKey, true, TimeSpan.FromSeconds(_otp.CooldownSeconds));

            try
            {
                if (identifier.Contains("@"))
                {
                    await _emailSender.SendEmailAsync(
                        identifier,
                        "Your OTP",
                        $"<p>Your OTP is <b>{otp}</b>.</p>",
                        ct
                    );
                }
                else
                {
                    await _smsSender.SendSmsAsync(
                        identifier,
                        $"Your OTP is {otp}.",
                        ct
                    );
                }

                return (true, "OTP sent");
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "OTP send failed for {id}", identifier);
                token.ExpiresAt = DateTime.UtcNow;
                await _db.SaveChangesAsync(ct);

                return (false, "Failed to send OTP.");
            }
        }

        public async Task<(bool Ok, string Message, int? UserId)> VerifyOtpAsync(string identifier, string otp, CancellationToken ct = default)
        {
            var token = await _db.PasswordResetTokens
                .Where(t => t.Identifier == identifier && !t.Used)
                .OrderByDescending(t => t.Id)
                .FirstOrDefaultAsync(ct);

            if (token == null) return (false, "No OTP found.", null);
            if (token.ExpiresAt < DateTime.UtcNow) return (false, "OTP expired.", null);
            if (token.Otp != otp) return (false, "Invalid OTP.", null);

            token.Used = true;
            await _db.SaveChangesAsync(ct);

            return (true, "OTP Verified", token.UserId);
        }
    }
}
