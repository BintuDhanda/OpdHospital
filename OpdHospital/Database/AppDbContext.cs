using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OpdHospital.Models;
using OpdHospital.Models.Audit;
using OpdHospital.Utilities;
using System.Reflection;

namespace OpdHospital.Database
{
    public class AppDbContext : DbContext
    {
        private readonly IJwtHelper _jwtHelper;
        public AppDbContext(DbContextOptions<AppDbContext> options, IJwtHelper jwtHelper)
            : base(options)
        {
            _jwtHelper = jwtHelper;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Notification>().HasKey(n => n.NotificationId);
            modelBuilder.Entity<Appointment>().HasKey(a => a.AppointmentId);
            modelBuilder.Entity<City>().HasKey(c => c.CityId);
            modelBuilder.Entity<Country>().HasKey(c => c.CountryId);
            modelBuilder.Entity<State>().HasKey(s => s.StateId);
            modelBuilder.Entity<Department>().HasKey(d => d.Id);
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Hospital>().HasKey(h => h.HospitalId);
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            modelBuilder.Entity<UserRole>().HasKey(ur => ur.UserRoleId);
            modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);
            modelBuilder.Entity<PaymentMethod>().HasKey(pm => pm.Id);
            modelBuilder.Entity<DoctorAvailability>().HasKey(ts => ts.Id);
            modelBuilder.Entity<Pincode>().HasKey(p => p.Id);
            modelBuilder.Entity<NotificationMessage>().HasKey(nm => nm.Id);
            modelBuilder.Entity<OtpSetting>().HasKey(os => os.Id);
            modelBuilder.Entity<AuditEvent>().HasKey(ae => ae.AuditEventId);
            modelBuilder.Entity<AuditEventDetail>().HasKey(aed => aed.AuditDetailId);
            modelBuilder.Entity<PasswordResetToken>().HasKey(prt => prt.Id);
            modelBuilder.Entity<OpdVisit>().HasKey(ov => ov.Id);
            modelBuilder.Entity<SalePartner>().HasKey(sp => sp.SalePartnerId);
            modelBuilder.Entity<Invoice>().HasKey(i => i.Id);
            modelBuilder.Entity<CommissionRule>().HasKey(cr => cr.Id);
            modelBuilder.Entity<Refunds>().HasKey(rf => rf.RefundId);
            modelBuilder.Entity<TimeSlot>().HasKey(ts => ts.Id);
            modelBuilder.Entity<PasswordResetToken>().HasKey(d => d.Id);
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorAvailability> DoctorsAvailability { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentsMethod { get; set; }
        public DbSet<Pincode> Pincodes { get; set; }
        public DbSet<Refunds> Refunds { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<OpdVisit> OpdVisits { get; set; }
        public DbSet<SalePartner> SalesPartner { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<CommissionRule> CommissionRules { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<NotificationMessage> NotificationMessages { get; set; }
        public DbSet<OtpRequest> OtpRequests {get; set;}
        public DbSet<OtpSetting> OtpSettings { get; set; }

        public DbSet<AuditEvent> AuditEvents => Set<AuditEvent>();
        public DbSet<AuditEventDetail> AuditEventDetails => Set<AuditEventDetail>();

        #endregion

        // ================= SAVE CHANGES OVERRIDE =================

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            var auditEvents = CreateAuditEvents();
            var userId = _jwtHelper.GetUserId();

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = userId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = userId;
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);

            if (auditEvents.Any())
            {
                AuditEvents.AddRange(auditEvents);
                await base.SaveChangesAsync(cancellationToken);
            }

            return result;
        }

        // ================= AUDIT CORE =================

        private List<AuditEvent> CreateAuditEvents()
        {
            ChangeTracker.DetectChanges();

            var auditEvents = new List<AuditEvent>();

            foreach (var entry in ChangeTracker.Entries())
            {
                // Skip audit tables themselves
                if (entry.Entity is AuditEvent ||
                    entry.Entity is AuditEventDetail ||
                    entry.State == EntityState.Unchanged ||
                    entry.State == EntityState.Detached)
                    continue;

                var auditEvent = new AuditEvent
                {
                    EntityName = entry.Entity.GetType().Name,
                    EntityId = GetPrimaryKeyValue(entry),
                    Action = entry.State.ToString().ToUpper(),
                    PerformedByUserId = GetCurrentUserId(),
                    PerformedOn = DateTime.UtcNow,
                    IpAddress = GetIpAddress()
                };

                foreach (var prop in entry.Properties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                        continue;

                    // 🔐 Sensitive fields handling
                    if (IsSensitiveField(prop.Metadata.Name))
                        continue; // OR mask instead

                    if (entry.State == EntityState.Added)
                    {
                        auditEvent.Details.Add(new AuditEventDetail
                        {
                            ColumnName = prop.Metadata.Name,
                            NewValue = prop.CurrentValue?.ToString()
                        });
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        auditEvent.Details.Add(new AuditEventDetail
                        {
                            ColumnName = prop.Metadata.Name,
                            OldValue = prop.OriginalValue?.ToString()
                        });
                    }
                    else if (entry.State == EntityState.Modified && prop.IsModified)
                    {
                        auditEvent.Details.Add(new AuditEventDetail
                        {
                            ColumnName = prop.Metadata.Name,
                            OldValue = prop.OriginalValue?.ToString(),
                            NewValue = prop.CurrentValue?.ToString()
                        });
                    }
                }

                if (auditEvent.Details.Any())
                    auditEvents.Add(auditEvent);
            }

            return auditEvents;
        }

        // ================= HELPERS =================

        private string GetPrimaryKeyValue(EntityEntry entry)
        {
            var key = entry.Metadata.FindPrimaryKey();

            var values = key!.Properties
                .Select(p => entry.Property(p.Name).CurrentValue?.ToString());

            return string.Join(",", values);
        }

        private long GetCurrentUserId()
        {
            return _jwtHelper.GetUserId();
        }

        private string? GetIpAddress()
        {
            return null;
        }

        private bool IsSensitiveField(string columnName)
        {
            return columnName.Contains("Password", StringComparison.OrdinalIgnoreCase)
                || columnName.Contains("AccountNumber", StringComparison.OrdinalIgnoreCase)
                || columnName.Contains("IFSC", StringComparison.OrdinalIgnoreCase);
        }
    }
}
