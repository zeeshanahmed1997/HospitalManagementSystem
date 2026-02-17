using HospitalManagementSystem.Data.Enums;
using HospitalManagementSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;
        public DbSet<Bill> Bills { get; set; } = null!;
        public DbSet<Ward> Wards { get; set; } = null!;
        public DbSet<Bed> Beds { get; set; } = null!;
        public DbSet<Medicine> Medicines { get; set; } = null!;
        public DbSet<LabTest> LabTests { get; set; } = null!;
        public DbSet<LabReport> LabReports { get; set; } = null!;
        public DbSet<Staff> StaffMembers { get; set; } = null!;
        public DbSet<Prescription> Prescriptions { get; set; } = null!;
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; } = null!;
        public DbSet<Admission> Admissions { get; set; } = null!;
        public DbSet<BillItem> BillItems { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ───────────────────────────────────────────────
            // Identity & User related (1:1 with profiles)
            // ───────────────────────────────────────────────
            builder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Staff>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Staff>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ───────────────────────────────────────────────
            // Appointment (protect history)
            // ───────────────────────────────────────────────
            builder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)           // ← add navigation if not present
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)           // ← add navigation if not present
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Appointment>()
                .Property(a => a.Status)
                .HasConversion<string>()
                .HasMaxLength(50);

            // ───────────────────────────────────────────────
            // Medical Records & Lab Reports (protect history)
            // ───────────────────────────────────────────────
            builder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Patient)
                .WithMany(p => p.MedicalRecords)
                .HasForeignKey(mr => mr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Doctor)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(mr => mr.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LabReport>()
                .HasOne(lr => lr.Patient)
                .WithMany(p => p.LabReports)
                .HasForeignKey(lr => lr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // ───────────────────────────────────────────────
            // Prescription chain
            // ───────────────────────────────────────────────
            builder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PrescriptionItem>()
                .HasOne(pi => pi.Prescription)
                .WithMany(p => p.Items)
                .HasForeignKey(pi => pi.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PrescriptionItem>()
                .HasOne(pi => pi.Medicine)
                .WithMany()
                .HasForeignKey(pi => pi.MedicineId)
                .OnDelete(DeleteBehavior.Restrict);

            // ───────────────────────────────────────────────
            // Billing & Payments
            // ───────────────────────────────────────────────
            builder.Entity<Bill>()
                .HasMany(b => b.Items)
                .WithOne(bi => bi.Bill)
                .HasForeignKey(bi => bi.BillId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Bill>()
                .HasMany(b => b.Payments)
                .WithOne(p => p.Bill)
                .HasForeignKey(p => p.BillId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Bill>()
                .Property(b => b.TotalAmount)
                .HasPrecision(18, 2);

            builder.Entity<Bill>()
                .Property(b => b.Tax)
                .HasPrecision(18, 2);

            // ───────────────────────────────────────────────
            // Other monetary fields
            // ───────────────────────────────────────────────
            builder.Entity<Doctor>()
                .Property(d => d.ConsultationFee)
                .HasPrecision(18, 2);

            builder.Entity<Staff>()
                .Property(s => s.Salary)
                .HasPrecision(18, 2);

            builder.Entity<Medicine>()
                .Property(m => m.UnitPrice)
                .HasPrecision(18, 2);

            builder.Entity<LabTest>()
                .Property(l => l.Price)
                .HasPrecision(18, 2);

            // ───────────────────────────────────────────────
            // Admission – Bed can be nullable
            // ───────────────────────────────────────────────
            builder.Entity<Admission>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Admissions)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Admission>()
                .HasOne(a => a.Bed)
                .WithMany(b => b.Admissions)
                .HasForeignKey(a => a.BedId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // ───────────────────────────────────────────────
            // Seed Data – Roles
            // ───────────────────────────────────────────────
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int> { Id = 2, Name = "Doctor", NormalizedName = "DOCTOR" },
                new IdentityRole<int> { Id = 3, Name = "Patient", NormalizedName = "PATIENT" },
                new IdentityRole<int> { Id = 4, Name = "Staff", NormalizedName = "STAFF" }
            );

            // ───────────────────────────────────────────────
            // Seed Data – Users & Roles (fixed structure)
            // ───────────────────────────────────────────────
            const string staticHash = "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q=="; // example BCrypt hash

            // Admin
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = 31,
                    UserName = "admin@hms.com",
                    NormalizedUserName = "ADMIN@HMS.COM",
                    Email = "admin@hms.com",
                    NormalizedEmail = "ADMIN@HMS.COM",
                    FirstName = "System",
                    LastName = "Administrator",
                    Gender = "Male",
                    Age = 40,
                    Address = "Lahore, Pakistan",
                    PhoneNumber = "03000000000",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = staticHash
                });

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 31, RoleId = 1 });

            // Demo users (1–30)
            for (int i = 1; i <= 30; i++)
            {
                var user = new ApplicationUser
                {
                    Id = i,
                    UserName = $"user{i}@hms.com",
                    NormalizedUserName = $"USER{i}@HMS.COM",
                    Email = $"user{i}@hms.com",
                    NormalizedEmail = $"USER{i}@HMS.COM",
                    FirstName = $"First{i}",
                    LastName = "Demo",
                    Gender = i % 2 == 0 ? "Male" : "Female",
                    Age = 18 + (i % 50),
                    Address = "Lahore, Pakistan",
                    PhoneNumber = $"0300{i:D6}",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = staticHash
                };

                builder.Entity<ApplicationUser>().HasData(user);

                int roleId = i <= 10 ? 2 : (i <= 20 ? 3 : 4); // Doctors 1-10, Patients 11-20, Staff 21-30
                builder.Entity<IdentityUserRole<int>>().HasData(
                    new IdentityUserRole<int> { UserId = i, RoleId = roleId });
            }

            // ───────────────────────────────────────────────
            // Other seed data (Departments, Doctors, Patients, etc.)
            // Reduced volume – 5 instead of 10 to keep migration fast
            // ───────────────────────────────────────────────
            var seedDate = new DateTime(2025, 1, 1);

            for (int i = 1; i <= 5; i++)
            {
                builder.Entity<Department>().HasData(new Department { Id = i, Name = $"Department {i}" });

                builder.Entity<Ward>().HasData(new Ward
                {
                    Id = i,
                    Name = $"Ward {i}",
                    Type = i % 2 == 0 ? "General" : "Special",
                    TotalBeds = 12
                });

                builder.Entity<Bed>().HasData(new Bed
                {
                    Id = i,
                    BedNumber = $"B-{i:00}",
                    IsOccupied = false,
                    WardId = i
                });

                builder.Entity<Medicine>().HasData(new Medicine
                {
                    Id = i,
                    Name = $"Medicine {i}",
                    UnitPrice = 45.50m * i,
                    StockQuantity = 200,
                    ExpiryDate = seedDate.AddYears(2)
                });

                builder.Entity<LabTest>().HasData(new LabTest
                {
                    Id = i,
                    TestName = $"Lab Test {i}",
                    Price = 800m + (i * 150)
                });

                // Doctor linked to user 1–5
                builder.Entity<Doctor>().HasData(new Doctor
                {
                    Id = i,
                    UserId = i,
                    DepartmentId = i,
                    Specialization = $"Specialty {i}",
                    ConsultationFee = 1800m + (i * 200)
                });

                // Patient linked to user 11–15
                builder.Entity<Patient>().HasData(new Patient
                {
                    Id = i,
                    UserId = i + 10,
                    BloodGroup = i % 3 == 0 ? "O+" : (i % 3 == 1 ? "A+" : "B+")
                });

                // Staff linked to user 21–25
                builder.Entity<Staff>().HasData(new Staff
                {
                    Id = i,
                    UserId = i + 20,
                    Designation = i % 2 == 0 ? "Nurse" : "Technician",
                    Salary = 48000m + (i * 5000)
                });

                // Sample appointment
                builder.Entity<Appointment>().HasData(new Appointment
                {
                    Id = i,
                    PatientId = i,
                    DoctorId = i,
                    AppointmentDate = seedDate.AddDays(i * 3),
                    Status = AppointmentStatus.Confirmed,
                    Reason = "Routine checkup"
                });

                builder.Entity<LabReport>().HasData(new LabReport
                {
                    Id = i,
                    PatientId = i,
                    LabTestId = i,
                    ResultDetails = "Within normal limits",
                    TestDate = seedDate.AddDays(i)
                });
            }
        }
    }
}