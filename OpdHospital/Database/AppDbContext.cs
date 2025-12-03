using Microsoft.EntityFrameworkCore;
using OpdHospital.Models.Appointments;
using OpdHospital.Models.AppointmentsStatus;
using OpdHospital.Models.Cities;
using OpdHospital.Models.Countries;
using OpdHospital.Models.Departments;
using OpdHospital.Models.DoctorHospitals;
using OpdHospital.Models.Doctors;
using OpdHospital.Models.DoctorsAvailabilities;
using OpdHospital.Models.DoctorsSpecializations;
using OpdHospital.Models.Hospitals;
using OpdHospital.Models.Patients;
using OpdHospital.Models.Payments;
using OpdHospital.Models.PaymentsStatus;
using OpdHospital.Models.PaymnetsMethods;
using OpdHospital.Models.Pincodes;
using OpdHospital.Models.Refunds;
using OpdHospital.Models.Roles;
using OpdHospital.Models.Specializations;
using OpdHospital.Models.States;
using OpdHospital.Models.TimesSlots;
using OpdHospital.Models.Users;
using OpdHospital.Models.UsersRoles;
using System.Reflection;

namespace OpdHospital.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStatus> AppointmentsStatus { get; set;}
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DoctorHospital> DoctorHospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorAvailability> DoctorsAvailability { get; set; }
        public DbSet<DoctorSpecialization> DoctorsSpecialization { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentsStatus { get; set; }
        public DbSet<PaymentMethod> PaymentsMethod { get; set; }
        public DbSet<Pincode> Pincodes { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
