using System;
using Microsoft.AspNetCore.Identity;
using OpdHospital.Database;
using OpdHospital.Models;

namespace OpdHospital.Utilities;

public class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
         context.Database.EnsureCreated();

          var users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    UserName = "admin",
                    Email = "admin@example.com",
                    IsUserLocked = false,
                    CreatedAt = DateTime.UtcNow,
                    Password = new PasswordHasher<User>().HashPassword(null, "Admin@123")
                },
            };

            context.Users.AddRange(users);
            context.SaveChanges();
    }
}
