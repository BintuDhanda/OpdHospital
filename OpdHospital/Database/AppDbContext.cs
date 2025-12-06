using Microsoft.EntityFrameworkCore;
using OpdHospital.Models;
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
        public DbSet<OpdVisit> OpdVisits { get; set;}
        public DbSet<SalePartner> SalesPartner { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<CommissionRule> CommissionRules { get; set; }
    }
}
