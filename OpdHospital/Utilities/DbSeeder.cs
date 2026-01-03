using System;
using Microsoft.AspNetCore.Identity;
using OpdHospital.Database;
using OpdHospital.Enums;
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
                    Name = "SalePartner",
                    CreatedAt = DateTime.UtcNow
                },
                new Role
                {
                 RoleId = 4,
                 Name = "Patient"
                },
                new Role
                {
                    RoleId = 5,
                     Name = "Hospital"
                }
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

        var patients = new List<Patient>
            {
                new Patient
                {
                    Id = 1,
                    FirstName = "John",
                    MiddleName = "A.",
                    LastName = "Doe",
                    UserId = 1,
                    Address = "123 Main St",
                    BloodGroup = "O+",
                    DOB = new DateTime(1990, 1, 1),
                    Age = 34,
                    MobileNumber = "9876543210",
                    Email = "john.doe@example.com",
                    CreatedAt = DateTime.UtcNow,
                    Gender = "Male"
                },
                new Patient
                {
                    Id = 2,
                    FirstName = "Jane",
                    MiddleName = "B.",
                    LastName = "Smith",
                    UserId = 1,
                    Address = "456 Elm St",
                    BloodGroup = "A-",
                    DOB = new DateTime(1985, 5, 15),
                    Age = 38,
                    MobileNumber = "8765432109",
                    Email = "jane.smith@example.com",
                    CreatedAt = DateTime.UtcNow,
                    Gender = "Female"
                },
            };

        context.Patients.AddRange(patients);
        context.SaveChanges();

        var appointments = new List<Appointment>
        {
            // 1️⃣ Fixed Time Appointment
            new Appointment
            {
                AppointmentId = 1,
                AppointmentType = AppointmentType.FixedTime,

                DoctorId = 101,
                PatientId = 201,
                HospitalId = 301,

                AppointmentDate = DateTime.Today.AddDays(1),
                AppointmentTime = new TimeSpan(10, 30, 0), // 10:30 AM

                Status = AppointmentStatus.Cancelled,

                AppointmentFee = 500m,
                PlatformFee = 50m,

                Remarks = "First-time consultation",
                CreatedBy = 1
            },

            // 2️⃣ Package Appointment (Visit 2 of Package)
            new Appointment
            {
                AppointmentId = 2,
                AppointmentType = AppointmentType.PackageVisit,

                DoctorId = 102,
                PatientId = 202,
                HospitalId = 301,

                PackageId = 9001,
                PackageVisitNumber = 2,

                Status = AppointmentStatus.Completed,

                AppointmentFee = 0m,      // Included in package
                PlatformFee = 0m,

                Remarks = "Physiotherapy package visit",
                CreatedBy = 1
            }
        };

        context.AddRange(appointments);
        context.SaveChanges();


        var doctors = new List<Doctor>()
        {
             new Doctor()
             {
                  FullName = "Dr. Ajay Nagpal",
                  DoctorId = 1,
                  Qualification = "MBBS (AIIMS), MPT",
                  Department = SpecializationType.Psychiatrist
             },

              new Doctor()
             {
                  FullName = "Dr. Priya Sharma",
                  DoctorId = 2,
                  Qualification = "MBBS (AIIMS), MPT",
                  Department = SpecializationType.Cardiologist
             },

        };

        context.AddRange(doctors);
        context.SaveChanges();

        var hospitals = new List<Hospital>()
        {
             new Hospital()
             {
                  HospitalId =1,
                  HospitalName = "Saryodya Multispeciality Hospital"
             },
             new Hospital()
             {
                 HospitalId =2,
                 HospitalName = "Apollo Medical Center"
             }
        };

        context.AddRange(hospitals);
        context.SaveChanges();

    }
}
