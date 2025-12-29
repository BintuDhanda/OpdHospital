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
                    MobileNumber = "1234567890",
                    IsUserLocked = false,
                    CreatedAt = DateTime.UtcNow,
                    Password = new PasswordHasher<User>().HashPassword(null, "Admin@123")
                },
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var Roles = new List<Role>
            {
                new Role
                {
                    RoleId = 1,
                    Name = "Administrator",
                    CreatedAt = DateTime.UtcNow
                },
                new Role
                {
                    RoleId = 2,
                    Name = "Doctor",
                    CreatedAt = DateTime.UtcNow
                },
                new Role
                {
                    RoleId = 3,
                    Name = "Nurse",
                    CreatedAt = DateTime.UtcNow
                },
            };

            context.Roles.AddRange(Roles);
            context.SaveChanges();

            var userRoles = new List<UserRole>
            {
                new UserRole
                {
                    UserId = 1,
                    RoleId = 1
                },
            };

            context.UserRoles.AddRange(userRoles);
            context.SaveChanges();

    }
}
