using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBeds = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMembers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultationFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beds_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResultDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    LabTestId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabReports_LabTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabReports_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patients_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Doctor", "DOCTOR" },
                    { 3, null, "Patient", "PATIENT" },
                    { 4, null, "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Lahore, Pakistan", 21, "35bd565c-2909-476d-b5dd-d5a502b360e2", "user1@hms.com", true, "UserFN1", "Female", "UserLN", false, null, "USER1@HMS.COM", "USER1@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234561", false, "STATIC_STAMP_1", false, "user1@hms.com" },
                    { 2, 0, "Lahore, Pakistan", 22, "48b68732-746f-4e83-b59c-9740cd581187", "user2@hms.com", true, "UserFN2", "Male", "UserLN", false, null, "USER2@HMS.COM", "USER2@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234562", false, "STATIC_STAMP_2", false, "user2@hms.com" },
                    { 3, 0, "Lahore, Pakistan", 23, "5b382282-abfe-467f-8e5f-1218bd13ad4c", "user3@hms.com", true, "UserFN3", "Female", "UserLN", false, null, "USER3@HMS.COM", "USER3@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234563", false, "STATIC_STAMP_3", false, "user3@hms.com" },
                    { 4, 0, "Lahore, Pakistan", 24, "c26c9715-74c7-467e-a39a-f393c03f101e", "user4@hms.com", true, "UserFN4", "Male", "UserLN", false, null, "USER4@HMS.COM", "USER4@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234564", false, "STATIC_STAMP_4", false, "user4@hms.com" },
                    { 5, 0, "Lahore, Pakistan", 25, "4d7073f7-5597-4cc7-89b4-7e9ddb1390f6", "user5@hms.com", true, "UserFN5", "Female", "UserLN", false, null, "USER5@HMS.COM", "USER5@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234565", false, "STATIC_STAMP_5", false, "user5@hms.com" },
                    { 6, 0, "Lahore, Pakistan", 26, "f1aa7aaa-793a-4f57-8e13-7c9163c05a67", "user6@hms.com", true, "UserFN6", "Male", "UserLN", false, null, "USER6@HMS.COM", "USER6@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234566", false, "STATIC_STAMP_6", false, "user6@hms.com" },
                    { 7, 0, "Lahore, Pakistan", 27, "88f89faa-635b-4a09-b9ce-4e93a3dc5ad1", "user7@hms.com", true, "UserFN7", "Female", "UserLN", false, null, "USER7@HMS.COM", "USER7@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234567", false, "STATIC_STAMP_7", false, "user7@hms.com" },
                    { 8, 0, "Lahore, Pakistan", 28, "12b7319f-a80a-4d2d-bf8a-b569abac1e59", "user8@hms.com", true, "UserFN8", "Male", "UserLN", false, null, "USER8@HMS.COM", "USER8@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234568", false, "STATIC_STAMP_8", false, "user8@hms.com" },
                    { 9, 0, "Lahore, Pakistan", 29, "d24ff95a-2392-44a5-a3cb-64640fd4ec8f", "user9@hms.com", true, "UserFN9", "Female", "UserLN", false, null, "USER9@HMS.COM", "USER9@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234569", false, "STATIC_STAMP_9", false, "user9@hms.com" },
                    { 10, 0, "Lahore, Pakistan", 30, "896262df-980f-4828-b6c8-f4209688f11f", "user10@hms.com", true, "UserFN10", "Male", "UserLN", false, null, "USER10@HMS.COM", "USER10@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234560", false, "STATIC_STAMP_10", false, "user10@hms.com" },
                    { 11, 0, "Lahore, Pakistan", 31, "d2d74b14-e58f-42ea-a6ef-9b7f3a0e0528", "user11@hms.com", true, "UserFN11", "Female", "UserLN", false, null, "USER11@HMS.COM", "USER11@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234561", false, "STATIC_STAMP_11", false, "user11@hms.com" },
                    { 12, 0, "Lahore, Pakistan", 32, "2cf31958-b83e-4e99-b18c-c4175e216784", "user12@hms.com", true, "UserFN12", "Male", "UserLN", false, null, "USER12@HMS.COM", "USER12@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234562", false, "STATIC_STAMP_12", false, "user12@hms.com" },
                    { 13, 0, "Lahore, Pakistan", 33, "3c12b067-53b8-450f-a8d7-36dd4308e041", "user13@hms.com", true, "UserFN13", "Female", "UserLN", false, null, "USER13@HMS.COM", "USER13@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234563", false, "STATIC_STAMP_13", false, "user13@hms.com" },
                    { 14, 0, "Lahore, Pakistan", 34, "0da00383-86bd-4e69-a60c-8a002cb559c8", "user14@hms.com", true, "UserFN14", "Male", "UserLN", false, null, "USER14@HMS.COM", "USER14@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234564", false, "STATIC_STAMP_14", false, "user14@hms.com" },
                    { 15, 0, "Lahore, Pakistan", 35, "69adaa23-0dd0-44c9-a0c6-31f756df195b", "user15@hms.com", true, "UserFN15", "Female", "UserLN", false, null, "USER15@HMS.COM", "USER15@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234565", false, "STATIC_STAMP_15", false, "user15@hms.com" },
                    { 16, 0, "Lahore, Pakistan", 36, "944d9caf-aca1-4b96-9622-fb56ceec5a09", "user16@hms.com", true, "UserFN16", "Male", "UserLN", false, null, "USER16@HMS.COM", "USER16@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234566", false, "STATIC_STAMP_16", false, "user16@hms.com" },
                    { 17, 0, "Lahore, Pakistan", 37, "7894c644-55e8-429c-bf4b-8386e4b2e540", "user17@hms.com", true, "UserFN17", "Female", "UserLN", false, null, "USER17@HMS.COM", "USER17@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234567", false, "STATIC_STAMP_17", false, "user17@hms.com" },
                    { 18, 0, "Lahore, Pakistan", 38, "5919b063-1e4c-4ef5-b875-e2c6b4e000a6", "user18@hms.com", true, "UserFN18", "Male", "UserLN", false, null, "USER18@HMS.COM", "USER18@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234568", false, "STATIC_STAMP_18", false, "user18@hms.com" },
                    { 19, 0, "Lahore, Pakistan", 39, "d7bafafd-4bd8-4837-94f3-d49bad783716", "user19@hms.com", true, "UserFN19", "Female", "UserLN", false, null, "USER19@HMS.COM", "USER19@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234569", false, "STATIC_STAMP_19", false, "user19@hms.com" },
                    { 20, 0, "Lahore, Pakistan", 40, "7707b204-1c3d-4c55-99c4-83115c1059bc", "user20@hms.com", true, "UserFN20", "Male", "UserLN", false, null, "USER20@HMS.COM", "USER20@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234560", false, "STATIC_STAMP_20", false, "user20@hms.com" },
                    { 21, 0, "Lahore, Pakistan", 41, "ee3ef933-b56f-4301-92d8-895c73d6c7c0", "user21@hms.com", true, "UserFN21", "Female", "UserLN", false, null, "USER21@HMS.COM", "USER21@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234561", false, "STATIC_STAMP_21", false, "user21@hms.com" },
                    { 22, 0, "Lahore, Pakistan", 42, "9e70890c-5754-431c-b502-eacb5c6fe2ba", "user22@hms.com", true, "UserFN22", "Male", "UserLN", false, null, "USER22@HMS.COM", "USER22@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234562", false, "STATIC_STAMP_22", false, "user22@hms.com" },
                    { 23, 0, "Lahore, Pakistan", 43, "7c3eac5f-d602-44c4-92c3-302017b99ae6", "user23@hms.com", true, "UserFN23", "Female", "UserLN", false, null, "USER23@HMS.COM", "USER23@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234563", false, "STATIC_STAMP_23", false, "user23@hms.com" },
                    { 24, 0, "Lahore, Pakistan", 44, "3d20992a-ed50-4cfb-8c03-f9fccc32947e", "user24@hms.com", true, "UserFN24", "Male", "UserLN", false, null, "USER24@HMS.COM", "USER24@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234564", false, "STATIC_STAMP_24", false, "user24@hms.com" },
                    { 25, 0, "Lahore, Pakistan", 45, "818bb0c4-cec4-412f-9f32-ba3f366d126c", "user25@hms.com", true, "UserFN25", "Female", "UserLN", false, null, "USER25@HMS.COM", "USER25@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234565", false, "STATIC_STAMP_25", false, "user25@hms.com" },
                    { 26, 0, "Lahore, Pakistan", 46, "d14b7d14-8784-4da5-8931-5d4cdc7d73a9", "user26@hms.com", true, "UserFN26", "Male", "UserLN", false, null, "USER26@HMS.COM", "USER26@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234566", false, "STATIC_STAMP_26", false, "user26@hms.com" },
                    { 27, 0, "Lahore, Pakistan", 47, "6bec69c4-787d-4187-b343-ad9ca4220196", "user27@hms.com", true, "UserFN27", "Female", "UserLN", false, null, "USER27@HMS.COM", "USER27@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234567", false, "STATIC_STAMP_27", false, "user27@hms.com" },
                    { 28, 0, "Lahore, Pakistan", 48, "e5b7f4da-b58e-4ae0-805f-15dcff4e29b5", "user28@hms.com", true, "UserFN28", "Male", "UserLN", false, null, "USER28@HMS.COM", "USER28@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234568", false, "STATIC_STAMP_28", false, "user28@hms.com" },
                    { 29, 0, "Lahore, Pakistan", 49, "1b9c767f-301a-4d24-8fe4-602c15f03601", "user29@hms.com", true, "UserFN29", "Female", "UserLN", false, null, "USER29@HMS.COM", "USER29@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234569", false, "STATIC_STAMP_29", false, "user29@hms.com" },
                    { 30, 0, "Lahore, Pakistan", 50, "694bf975-88c9-40ac-a703-3cdebf73cdb4", "user30@hms.com", true, "UserFN30", "Male", "UserLN", false, null, "USER30@HMS.COM", "USER30@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03001234560", false, "STATIC_STAMP_30", false, "user30@hms.com" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Dept 1" },
                    { 2, null, false, "Dept 2" },
                    { 3, null, false, "Dept 3" },
                    { 4, null, false, "Dept 4" },
                    { 5, null, false, "Dept 5" },
                    { 6, null, false, "Dept 6" },
                    { 7, null, false, "Dept 7" },
                    { 8, null, false, "Dept 8" },
                    { 9, null, false, "Dept 9" },
                    { 10, null, false, "Dept 10" }
                });

            migrationBuilder.InsertData(
                table: "LabTests",
                columns: new[] { "Id", "Description", "IsDeleted", "Price", "TestName" },
                values: new object[,]
                {
                    { 1, null, false, 600.00m, "Test 1" },
                    { 2, null, false, 700.00m, "Test 2" },
                    { 3, null, false, 800.00m, "Test 3" },
                    { 4, null, false, 900.00m, "Test 4" },
                    { 5, null, false, 1000.00m, "Test 5" },
                    { 6, null, false, 1100.00m, "Test 6" },
                    { 7, null, false, 1200.00m, "Test 7" },
                    { 8, null, false, 1300.00m, "Test 8" },
                    { 9, null, false, 1400.00m, "Test 9" },
                    { 10, null, false, 1500.00m, "Test 10" }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "ExpiryDate", "IsDeleted", "Name", "StockQuantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 1", 100, 10.5m },
                    { 2, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 2", 100, 21.0m },
                    { 3, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 3", 100, 31.5m },
                    { 4, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 4", 100, 42.0m },
                    { 5, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 5", 100, 52.5m },
                    { 6, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 6", 100, 63.0m },
                    { 7, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 7", 100, 73.5m },
                    { 8, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 8", 100, 84.0m },
                    { 9, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 9", 100, 94.5m },
                    { 10, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 10", 100, 105.0m }
                });

            migrationBuilder.InsertData(
                table: "Wards",
                columns: new[] { "Id", "IsDeleted", "Name", "TotalBeds", "Type" },
                values: new object[,]
                {
                    { 1, false, "Ward 1", 10, "General" },
                    { 2, false, "Ward 2", 10, "General" },
                    { 3, false, "Ward 3", 10, "General" },
                    { 4, false, "Ward 4", 10, "General" },
                    { 5, false, "Ward 5", 10, "General" },
                    { 6, false, "Ward 6", 10, "General" },
                    { 7, false, "Ward 7", 10, "General" },
                    { 8, false, "Ward 8", 10, "General" },
                    { 9, false, "Ward 9", 10, "General" },
                    { 10, false, "Ward 10", 10, "General" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 3, 16 },
                    { 3, 17 },
                    { 3, 18 },
                    { 3, 19 },
                    { 3, 20 },
                    { 4, 21 },
                    { 4, 22 },
                    { 4, 23 },
                    { 4, 24 },
                    { 4, 25 },
                    { 4, 26 },
                    { 4, 27 },
                    { 4, 28 },
                    { 4, 29 },
                    { 4, 30 }
                });

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "Id", "BedNumber", "IsDeleted", "IsOccupied", "WardId" },
                values: new object[,]
                {
                    { 1, "B-1", false, false, 1 },
                    { 2, "B-2", false, false, 2 },
                    { 3, "B-3", false, false, 3 },
                    { 4, "B-4", false, false, 4 },
                    { 5, "B-5", false, false, 5 },
                    { 6, "B-6", false, false, 6 },
                    { 7, "B-7", false, false, 7 },
                    { 8, "B-8", false, false, 8 },
                    { 9, "B-9", false, false, 9 },
                    { 10, "B-10", false, false, 10 }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "ConsultationFee", "DepartmentId", "Qualification", "Specialization", "UserId" },
                values: new object[,]
                {
                    { 1, 1500m, 1, null, "Specialist", 1 },
                    { 2, 1500m, 2, null, "Specialist", 2 },
                    { 3, 1500m, 3, null, "Specialist", 3 },
                    { 4, 1500m, 4, null, "Specialist", 4 },
                    { 5, 1500m, 5, null, "Specialist", 5 },
                    { 6, 1500m, 6, null, "Specialist", 6 },
                    { 7, 1500m, 7, null, "Specialist", 7 },
                    { 8, 1500m, 8, null, "Specialist", 8 },
                    { 9, 1500m, 9, null, "Specialist", 9 },
                    { 10, 1500m, 10, null, "Specialist", 10 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BloodGroup", "EmergencyContact", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { 1, "A+", null, false, 11 },
                    { 2, "A+", null, false, 12 },
                    { 3, "A+", null, false, 13 },
                    { 4, "A+", null, false, 14 },
                    { 5, "A+", null, false, 15 },
                    { 6, "A+", null, false, 16 },
                    { 7, "A+", null, false, 17 },
                    { 8, "A+", null, false, 18 },
                    { 9, "A+", null, false, 19 },
                    { 10, "A+", null, false, 20 }
                });

            migrationBuilder.InsertData(
                table: "StaffMembers",
                columns: new[] { "Id", "Designation", "IsDeleted", "Salary", "UserId" },
                values: new object[,]
                {
                    { 1, "Nurse", false, 45000m, 21 },
                    { 2, "Nurse", false, 45000m, 22 },
                    { 3, "Nurse", false, 45000m, 23 },
                    { 4, "Nurse", false, 45000m, 24 },
                    { 5, "Nurse", false, 45000m, 25 },
                    { 6, "Nurse", false, 45000m, 26 },
                    { 7, "Nurse", false, 45000m, 27 },
                    { 8, "Nurse", false, 45000m, 28 },
                    { 9, "Nurse", false, 45000m, 29 },
                    { 10, "Nurse", false, 45000m, 30 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "DoctorId", "PatientId", "PatientId1", "Reason", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, null, "Confirmed" },
                    { 2, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, null, null, "Confirmed" },
                    { 3, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, null, null, "Confirmed" },
                    { 4, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, null, null, "Confirmed" },
                    { 5, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, null, null, "Confirmed" },
                    { 6, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6, null, null, "Confirmed" },
                    { 7, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7, null, null, "Confirmed" },
                    { 8, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8, null, null, "Confirmed" },
                    { 9, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 9, null, null, "Confirmed" },
                    { 10, new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10, null, null, "Confirmed" }
                });

            migrationBuilder.InsertData(
                table: "LabReports",
                columns: new[] { "Id", "IsDeleted", "LabTestId", "PatientId", "ResultDetails", "TestDate" },
                values: new object[,]
                {
                    { 1, false, 1, 1, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, false, 2, 2, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, false, 3, 3, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, false, 4, 4, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, false, 5, 5, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, false, 6, 6, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, false, 7, 7, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, false, 8, 8, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, false, 9, 9, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, false, 10, 10, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_WardId",
                table: "Beds",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_AppointmentId",
                table: "Bills",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabReports_LabTestId",
                table: "LabReports",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_LabReports_PatientId",
                table: "LabReports",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DoctorId",
                table: "MedicalRecords",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId1",
                table: "MedicalRecords",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_UserId",
                table: "StaffMembers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "LabReports");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
