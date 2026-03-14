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
                    Id = 1,
                    Email = "admin@example.com",
                    MobileNumber = "1234567890",
                    IsUserLocked = false,
                    CreatedAt = DateTime.UtcNow,
                    Password = new PasswordHasher<User>().HashPassword(null, "Admin@123")
                },
                new User
                {
                    Id = 2,
                    Email = "doctor@example.com",
                    MobileNumber = "0987654321",
                    IsUserLocked = false,
                    CreatedAt = DateTime.UtcNow,
                    Password = new PasswordHasher<User>().HashPassword(null, "Doctor@123"),
                },
                new User
                {
                    Id = 3,
                    Email = "sales@example.com",
                    MobileNumber = "1122334455",
                    IsUserLocked = false,
                    CreatedAt = DateTime.UtcNow,
                    Password = new PasswordHasher<User>().HashPassword(null, "Sales@123"),
                },
                new User
                {
                    Id = 4,
                    Email = "hospital@example.com",
                    MobileNumber = "5566778899",
                    IsUserLocked = false,
                    CreatedAt = DateTime.UtcNow,
                    Password = new PasswordHasher<User>().HashPassword(null, "Hospital@123"),
                },
                new User
                {
                    Id = 5,
                    Email = "patient@example.com",
                    MobileNumber = "9988776655",
                    IsUserLocked = false,
                    CreatedAt = DateTime.UtcNow,
                    Password = new PasswordHasher<User>().HashPassword(null, "Patient@123"),
                },
                new User
                {
                    Id = 6,
                    Email = "patientanddoctor@example.com",
                    MobileNumber = "1234567891",
                    IsUserLocked = false,
                    CreatedAt = DateTime.UtcNow,
                    Password = new PasswordHasher<User>().HashPassword(null, "PatientAndDoctor@123"),
                }
            };

        context.Users.AddRange(users);
        context.SaveChanges();

        var Roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Administrator",
                    CreatedAt = DateTime.UtcNow
                },
                new Role
                {
                    Id = 2,
                    Name = "Doctor",
                    CreatedAt = DateTime.UtcNow
                },
                new Role
                {
                    Id = 3,
                    Name = "SalePartner",
                    CreatedAt = DateTime.UtcNow
                },
                new Role
                {
                 Id = 4,
                 Name = "Patient"
                },
                new Role
                {
                    Id = 5,
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
                new UserRole
                {
                    UserId = 2,
                    RoleId = 2
                },
                new UserRole
                {
                    UserId = 3,
                    RoleId = 3
                },
                new UserRole
                {
                    UserId = 4,
                    RoleId = 5
                },
                new UserRole
                {   UserId = 5,
                    RoleId = 4
                },
                new UserRole
                {
                    UserId = 6,
                    RoleId = 2
                },
                new UserRole
                {   
                    UserId = 6,
                    RoleId = 4
                }
                
            };

        context.UserRoles.AddRange(userRoles);
        context.SaveChanges();

        var patientBook = new List<Patient>
        {
            new Patient
            {
                FirstName = "father",
                CreatedAt = DateTime.UtcNow,
                Address = "123 Main St",
                BloodGroup = "O+",
                DOB = new DateTime(1960, 1, 1),
                Age = 64,
                MobileNumber = "9876543210",
                Email = "father@example.com",
                Gender = "Male",
                LastName = "Doe",
                CreatedBy = 1,
                UpdatedBy = 1
            },
            new Patient
            {
                FirstName = "mother",
                CreatedAt = DateTime.UtcNow,
                Address = "123 Main St",
                BloodGroup = "A+",
                DOB = new DateTime(1965, 5, 15),
                Age = 59,
                MobileNumber = "8765432109",
                Email = "mother@example.com",
                Gender = "Female",
                LastName = "Smith",
                CreatedBy = 1,
                UpdatedBy = 1
            },
             new Patient
            {
                FirstName = "sister",           
                CreatedAt = DateTime.UtcNow,
                Address = "123 Main St",
                BloodGroup = "B+",
                DOB = new DateTime(1995, 3, 20),        
                Age = 28,
                MobileNumber = "7654321098",
                Email = "sister@example.com",
                Gender = "Female",
                LastName = "Johnson",
                CreatedBy = 1,
                UpdatedBy = 1
            },
             new Patient
                {
                    FirstName = "John",
                    MiddleName = "A.",
                    LastName = "Doe",
                    Address = "123 Main St",
                    BloodGroup = "O+",
                    DOB = new DateTime(1990, 1, 1),
                    Age = 34,
                    MobileNumber = "9876543210",
                    Email = "john.doe@example.com",
                    CreatedAt = DateTime.UtcNow,
                    Gender = "Male",
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
                new Patient
                {
                    FirstName = "Jane",
                    MiddleName = "B.",
                    LastName = "Smith",
                    Address = "456 Elm St",
                    BloodGroup = "A-",
                    DOB = new DateTime(1985, 5, 15),
                    Age = 38,
                    MobileNumber = "8765432109",
                    Email = "jane.smith@example.com",
                    CreatedAt = DateTime.UtcNow,
                    Gender = "Female",
                    CreatedBy = 1,
                    UpdatedBy = 1
                },
           
        };

        context.Patients.AddRange(patientBook);
        context.SaveChanges();

        var countries = new List<Country>
            {
                new Country
                {
                    Id = 1,
                    Name = "India",
                },
            };

        context.Countries.AddRange(countries);
        context.SaveChanges();

        var states = new List<State>
            {
                new State
                {
                    Id = 1,
                    StateName = "Haryana",
                    CountryId = 1,
                },
            };

        context.States.AddRange(states);
        context.SaveChanges();

        var cities = new List<City>
            {
                new City
                {
                    Id = 1,
                    CityName = "Gurgaon",
                    StateId = 1,
                },
            };

        context.Cities.AddRange(cities);
        context.SaveChanges();

        var notifications = new List<Notification>
            {
                new Notification
                {
                    Id = 1,
                    UserId = 1,
                    NotificationTitle = "Welcome",
                    NotificationMessage = "Welcome to the OpdHospital system!",
                    IsRead = false,
                },
                new Notification
                {
                    Id = 2,
                    UserId = 1,
                    NotificationTitle = "System Update",
                    NotificationMessage = "The system will undergo maintenance tonight.",
                    IsRead = false,
                },
            };

        context.Notifications.AddRange(notifications);
        context.SaveChanges();

        var appointments = new List<Appointment>
        {
            // 1️⃣ Fixed Time Appointment
            new Appointment
            {
                Id = 1,
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
                Id = 2,
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
                  Id = 1,
                  Qualification = "MBBS (AIIMS), MPT",
                  Department = SpecializationType.Psychiatrist
             },

              new Doctor()
             {
                  FullName = "Dr. Priya Sharma",
                  Id = 2,
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
                  Id =1,
                  HospitalName = "Saryodya Multispeciality Hospital"
             },
             new Hospital()
             {
                 Id =2,
                 HospitalName = "Apollo Medical Center"
             }
        };

        context.AddRange(hospitals);
        context.SaveChanges();

    }
}
