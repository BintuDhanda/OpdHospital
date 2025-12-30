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
using OpdHospital.Utilities;
using System.Text;

namespace OpdHospital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            AppSettings.Load(builder.Configuration);

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

            builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                // Prevent the framework from automatically returning 400 for invalid model state.
                options.SuppressModelStateInvalidFilter = true;
            });

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
                    ValidIssuer = AppSettings.JwtIssuer,
                    ValidAudience = AppSettings.JwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JwtKey))
                };
            });


            if (true || builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("DevInMemoryDb"));
            }
            else
            {
                builder.Services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseMySql(
                        builder.Configuration.GetConnectionString("Default"),
                        ServerVersion.AutoDetect(
                            builder.Configuration.GetConnectionString("Default"))
                    );
                });

            }

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            builder.Services.AddScoped<ISearchService, SearchService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IJwtHelper, JwtHelper>();    
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            
            builder.Services.AddScoped<IPushSender, FcmPushSenderService>();
            //builder.Services.AddHostedService<NotificationBackgroundService>();

            builder.Services.AddTransient<IEmailSender, SmtpEmailSenderService>();
            builder.Services.AddTransient<ISmsSender, TwilioSmsSenderService>();  // Correct class name
            builder.Services.AddHttpClient<FcmPushSenderService>();
            builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
            builder.Services.AddScoped<OtpService>();


            var app = builder.Build();

            if (true || app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    DbSeeder.Seed(dbContext);
                }
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }

    }
}