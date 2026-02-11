using HospitalManagementSystem.Data.Enums;
using HospitalManagementSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<LabReport> LabReports { get; set; }
        public DbSet<Staff> StaffMembers { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Patient>().HasOne(p => p.User).WithOne().HasForeignKey<Patient>(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Doctor>().HasOne(d => d.User).WithOne().HasForeignKey<Doctor>(d => d.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Staff>().HasOne(s => s.User).WithOne().HasForeignKey<Staff>(s => s.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Appointment>().HasOne(a => a.Patient).WithMany().HasForeignKey(a => a.PatientId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Appointment>().HasOne(a => a.Doctor).WithMany().HasForeignKey(a => a.DoctorId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MedicalRecord>().HasOne(mr => mr.Patient).WithMany().HasForeignKey(mr => mr.PatientId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<MedicalRecord>().HasOne(mr => mr.Doctor).WithMany().HasForeignKey(mr => mr.DoctorId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LabReport>().HasOne(lr => lr.Patient).WithMany().HasForeignKey(lr => lr.PatientId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Bill>().Property(b => b.TotalAmount).HasPrecision(18, 2);
            builder.Entity<Bill>().Property(b => b.Tax).HasPrecision(18, 2);
            builder.Entity<Doctor>().Property(d => d.ConsultationFee).HasPrecision(18, 2);
            builder.Entity<Staff>().Property(s => s.Salary).HasPrecision(18, 2);
            builder.Entity<Medicine>().Property(m => m.UnitPrice).HasPrecision(18, 2);
            builder.Entity<LabTest>().Property(l => l.Price).HasPrecision(18, 2);

            builder.Entity<Appointment>().Property(a => a.Status).HasConversion(v => v.ToString(), v => (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), v));

            builder.Entity<Prescription>().HasOne(p => p.Patient).WithMany().HasForeignKey(p => p.PatientId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Prescription>().HasOne(p => p.Doctor).WithMany().HasForeignKey(p => p.DoctorId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PrescriptionItem>().HasOne(pi => pi.Prescription).WithMany(p => p.Items).HasForeignKey(pi => pi.PrescriptionId);
            builder.Entity<PrescriptionItem>().HasOne(pi => pi.Medicine).WithMany().HasForeignKey(pi => pi.MedicineId);
            builder.Entity<Admission>().HasOne(a => a.Patient).WithMany().HasForeignKey(a => a.PatientId);
            builder.Entity<Admission>().HasOne(a => a.Bed).WithMany().HasForeignKey(a => a.BedId).IsRequired(false);
            builder.Entity<BillItem>().HasOne(bi => bi.Bill).WithMany(b => b.Items).HasForeignKey(bi => bi.BillId);
            builder.Entity<Payment>().HasOne(p => p.Bill).WithMany(b => b.Payments).HasForeignKey(p => p.BillId);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int> { Id = 2, Name = "Doctor", NormalizedName = "DOCTOR" },
                new IdentityRole<int> { Id = 3, Name = "Patient", NormalizedName = "PATIENT" },
                new IdentityRole<int> { Id = 4, Name = "Staff", NormalizedName = "STAFF" }
            );

            var staticHash = "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==";
            var seedDate = new DateTime(2026, 1, 1);

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = 31,
                UserName = "admin@hms.com",
                NormalizedUserName = "ADMIN@HMS.COM",
                Email = "admin@hms.com",
                NormalizedEmail = "ADMIN@HMS.COM",
                FirstName = "Admin",
                LastName = "User",
                Gender = "Male",
                Age = 35,
                Address = "Lahore, Pakistan",
                PhoneNumber = "03000000000",
                EmailConfirmed = true,
                SecurityStamp = "ADMIN_SECURITY_STAMP",
                PasswordHash = staticHash
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> 
            { 
                UserId = 31, 
                RoleId = 1 
            });

            for (int i = 1; i <= 30; i++)
            {
                builder.Entity<ApplicationUser>().HasData(new ApplicationUser
                {
                    Id = i,
                    UserName = $"user{i}@hms.com",
                    NormalizedUserName = $"USER{i}@HMS.COM",
                    Email = $"user{i}@hms.com",
                    NormalizedEmail = $"USER{i}@HMS.COM",
                    FirstName = $"UserFN{i}",
                    LastName = "UserLN",
                    Gender = i % 2 == 0 ? "Male" : "Female",
                    Age = 20 + i,
                    Address = "Lahore, Pakistan",
                    PhoneNumber = $"0300123456{i % 10}",
                    EmailConfirmed = true,
                    SecurityStamp = "STATIC_STAMP_" + i,
                    PasswordHash = staticHash
                });

                int roleId = i <= 10 ? 2 : (i <= 20 ? 3 : 4);
                builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = i, RoleId = roleId });
            }

            for (int i = 1; i <= 10; i++)
            {
                builder.Entity<Department>().HasData(new Department { Id = i, Name = $"Dept {i}" });
                builder.Entity<Ward>().HasData(new Ward { Id = i, Name = $"Ward {i}", Type = "General", TotalBeds = 10 });
                builder.Entity<Bed>().HasData(new Bed { Id = i, BedNumber = $"B-{i}", IsOccupied = false, WardId = i });
                builder.Entity<Medicine>().HasData(new Medicine { Id = i, Name = $"Medicine {i}", UnitPrice = 10.5m * i, StockQuantity = 100, ExpiryDate = seedDate.AddYears(1) });
                builder.Entity<LabTest>().HasData(new LabTest { Id = i, TestName = $"Test {i}", Price = 500.00m + (i * 100) });
                builder.Entity<Doctor>().HasData(new Doctor { Id = i, UserId = i, DepartmentId = i, Specialization = "Specialist", ConsultationFee = 1500 });
                builder.Entity<Patient>().HasData(new Patient { Id = i, UserId = i + 10, BloodGroup = "A+" });
                builder.Entity<Staff>().HasData(new Staff { Id = i, UserId = i + 20, Designation = "Nurse", Salary = 45000 });
                builder.Entity<Appointment>().HasData(new Appointment { Id = i, PatientId = i, DoctorId = i, AppointmentDate = seedDate.AddDays(i), Status = AppointmentStatus.Confirmed });
                builder.Entity<LabReport>().HasData(new LabReport { Id = i, PatientId = i, LabTestId = i, ResultDetails = "Normal", TestDate = seedDate });
            }
        }
    }
}