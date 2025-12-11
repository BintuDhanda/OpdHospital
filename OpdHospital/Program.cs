using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using OpdHospital.Database;
using OpdHospital.Dtos;
using OpdHospital.Interfaces;
using OpdHospital.Models;
using OpdHospital.Repositories;
using OpdHospital.Services;
using System.Text;

namespace OpdHospital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Authentication - JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            //builder.Services.AddHttpClient<IPushSender, FcmPushSenderService>();
            builder.Services.AddScoped<IPushSender,FcmPushSenderService>();
            builder.Services.AddHostedService<NotificationBackgroundService>();

            builder.Services.Configure<OtpSetting>(builder.Configuration.GetSection("Otp"));
            builder.Services.Configure<SmtpSetting>(builder.Configuration.GetSection("Smtp"));
            builder.Services.Configure<TwilioSetting>(builder.Configuration.GetSection("Twilio"));

            builder.Services.AddTransient<IEmailSender, SmtpEmailSenderService>();
            builder.Services.AddTransient<ISmsSender, TwilioSmsSenderService>();  // Correct class name
            builder.Services.AddHttpClient<FcmPushSenderService>();
            builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
            builder.Services.AddScoped<OtpService>();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //app.UseCors("AllowAngularApp");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapPost("/api/notify", async (NotificationRequestDto req, INotificationService svc) =>
            {
                var id = await svc.QueueNotificationAsync(req);
                return Results.Ok($"Notification queued with ID: {id}");
            });

            app.UseStaticFiles();

            app.MapPost("/api/auth/forgot-password", async (
                ForgotPasswordRequestDto req,
                AppDbContext db) =>
            {
                if (string.IsNullOrWhiteSpace(req.Identifier))
                    return Results.BadRequest("Email or mobile is required.");

                var user = await db.Users
                    .SingleOrDefaultAsync(u => u.Email == req.Identifier || u.MobileNumber == req.Identifier);

                if (user == null)
                    return Results.NotFound("User not found");

                // Generate OTP
                string otp = new Random().Next(100000, 999999).ToString();

                var token = new PasswordResetToken
                {
                    UserId = user.Id,
                    Identifier = req.Identifier,
                    Otp = otp,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(10),
                    Used = false
                };

                db.PasswordResetTokens.Add(token);
                await db.SaveChangesAsync();

                // Simulated SMS/Email sending
                if (req.Identifier.Contains("@"))
                    Console.WriteLine($"Sent OTP {otp} to email {req.Identifier}");
                else
                    Console.WriteLine($"Sent OTP {otp} to mobile {req.Identifier}");

                return Results.Ok("OTP sent successfully");
            });


            app.MapPost("/api/auth/reset-password", async (
                       ResetPasswordRequestDto req,
                       AppDbContext db,
               IPasswordHasher<User> hasher) =>
            {
                if (string.IsNullOrWhiteSpace(req.Identifier) ||
                    string.IsNullOrWhiteSpace(req.Otp) ||
                    string.IsNullOrWhiteSpace(req.NewPassword))
                {
                    return Results.BadRequest("All fields are required.");
                }

                var token = await db.PasswordResetTokens
                    .Where(t => t.Identifier == req.Identifier && !t.Used)
                    .OrderByDescending(t => t.Id)
                    .FirstOrDefaultAsync();

                if (token == null || token.Otp != req.Otp)
                    return Results.BadRequest("Invalid OTP");

                if (token.ExpiresAt < DateTime.UtcNow)
                    return Results.BadRequest("OTP expired");

                var user = await db.Users
                    .SingleOrDefaultAsync(u => u.Email == req.Identifier || u.MobileNumber == req.Identifier);

                if (user == null)
                    return Results.NotFound("User not found");

                // set new password
                user.Password = hasher.HashPassword(user, req.NewPassword);

                // mark token used
                token.Used = true;

                await db.SaveChangesAsync();

                return Results.Ok("Password successfully reset.");
            });



            // *********** LOGIN ENDPOINT ***********
            app.MapPost("/api/login", async (
                LoginRequestDto req,
                AppDbContext db,
                IPasswordHasher<User> hasher,
                ITokenService tokenService) =>
            {
                if (string.IsNullOrWhiteSpace(req.Password) || string.IsNullOrWhiteSpace(req.Password))
                    return Results.BadRequest("Identifier and password are required.");
                User? user = null;

                if (req.Identifier.Contains("@"))
                    user = await db.Users.SingleOrDefaultAsync(u => u.Email == req.Identifier);
                else
                    user = await db.Users.SingleOrDefaultAsync(u => u.MobileNumber == req.Identifier);

                if (user == null)
                    return Results.Unauthorized();

                // Verify password
                var verify = hasher.VerifyHashedPassword(user, user.Password, req.Password);
                if (verify == PasswordVerificationResult.Failed)
                    return Results.Unauthorized();

                // Generate JWT
                var token = tokenService.CreateToken(user);

                return Results.Ok(new
                {
                    Token = token,
                    Expires = tokenService.GetExpiry(),
                    User = new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        user.MobileNumber,
                        Roles = user.Roles
                    }
                });
            });

            app.MapPost("/api/auth/verify-otp", async (
                  OtpVerifyRequestDto req,
                  AppDbContext db) =>
            {
                if (string.IsNullOrWhiteSpace(req.Identifier) || string.IsNullOrWhiteSpace(req.Otp))
                    return Results.BadRequest("Identifier and OTP are required.");

                var token = await db.PasswordResetTokens
                    .Where(t => t.Identifier == req.Identifier && !t.Used)
                    .OrderByDescending(t => t.Id)
                    .FirstOrDefaultAsync();

                if (token == null)
                    return Results.BadRequest("OTP not found.");

                if (token.Otp != req.Otp)
                    return Results.BadRequest("Invalid OTP.");

                if (token.ExpiresAt < DateTime.UtcNow)
                    return Results.BadRequest("OTP expired.");

                // Optionally mark it verified (but not used yet)
                // token.Used = true;
                // await db.SaveChangesAsync();

                return Results.Ok(new
                {
                    Message = "OTP verified. You may reset password now.",
                    TokenId = token.Id
                });
            });


            app.MapControllers();

            app.Run();
        }
    }
}
