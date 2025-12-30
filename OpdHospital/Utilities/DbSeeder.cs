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

            var countries = new List<Country>
            {
                new Country
                {
                    CountryId = 1,
                    Name = "India",
                    CreatedAt = DateTime.UtcNow
                },
            };

            context.Countries.AddRange(countries);
            context.SaveChanges();

            var states = new List<State>
            {
                new State
                {
                    StateId = 1,
                    StateName = "Haryana",
                    CountryId = 1,
                    CreatedAt = DateTime.UtcNow
                },
            };

            context.States.AddRange(states);
            context.SaveChanges();

            var notifications = new List<Notification>
            {
                new Notification
                {
                    NotificationId = 1,
                    UserId = 1,
                    NotificationTitle = "Welcome",
                    NotificationMessage = "Welcome to the OpdHospital system!",
                    IsRead = false,
                },
                new Notification
                {
                    NotificationId = 2,
                    UserId = 1,
                    NotificationTitle = "System Update",
                    NotificationMessage = "The system will undergo maintenance tonight.",
                    IsRead = false,
                },
            };

            context.Notifications.AddRange(notifications);
            context.SaveChanges();

    }
}
