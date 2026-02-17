using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class updatedrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Beds_BedId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Patients_PatientId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId1",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bills_BillId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionItems_Medicines_MedicineId",
                table: "PrescriptionItems");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_PatientId1",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Appointments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppointmentDate", "Reason" },
                values: new object[] { new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Routine checkup" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppointmentDate", "Reason" },
                values: new object[] { new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Routine checkup" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppointmentDate", "Reason" },
                values: new object[] { new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Routine checkup" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AppointmentDate", "Reason" },
                values: new object[] { new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Routine checkup" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AppointmentDate", "Reason" },
                values: new object[] { new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Routine checkup" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 19, "86a68204-03f4-4d7e-9f63-fec3f89ccaa4", "First1", "Demo", "0300000001", "0621ca05-caa2-440e-a1b5-33aa974003b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 20, "0ab45c46-7c5c-40a8-83cc-33d759d46e5e", "First2", "Demo", "0300000002", "eb2be4ec-6151-4e11-9a6d-f9a0c243d712" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 21, "0400103d-beaa-4921-bd8f-52ad3ca3a0a1", "First3", "Demo", "0300000003", "91f21fc5-0c97-41b1-b08e-1e3b958706e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 22, "4268ec6d-8501-4228-ba69-5a987c82c5d0", "First4", "Demo", "0300000004", "54937e5d-a557-485d-9b29-d807cb307771" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 23, "d3357f87-6cc0-448d-9b81-2b940afdad23", "First5", "Demo", "0300000005", "dfeddd52-9cff-470d-90fc-24ef93ab180e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 24, "9b099fa5-6b76-4e54-87e1-9a681fb943f8", "First6", "Demo", "0300000006", "8fd59893-56e7-4efb-b6c1-8de902cc4f09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 25, "b91dca52-efc2-4da6-be56-a246a4746d3f", "First7", "Demo", "0300000007", "2866d24c-dceb-4a60-a28f-39dc6d359a8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 26, "be9699fd-e58e-42e2-85aa-d1a5d6bccd42", "First8", "Demo", "0300000008", "721776d1-c874-47c3-a13a-8799b95c54c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 27, "d5327041-8909-43b8-af0a-621dee555988", "First9", "Demo", "0300000009", "9cbd60e3-e8e8-450b-bf79-e70a2472afbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 28, "fd94599d-8575-4a19-b028-284c95867837", "First10", "Demo", "0300000010", "138fb09c-1ee8-4f8a-a44a-12549f1e751b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 29, "0e8f937e-74b9-42fb-ac12-09e1197f7f36", "First11", "Demo", "0300000011", "a5580ec9-de9e-47bf-bd8a-5739b9c306e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 30, "dfb6fd76-a89a-4cb6-a711-d2efe6bbc1c0", "First12", "Demo", "0300000012", "c3a53a6a-3eab-4f3f-96c2-cbb61ac5e229" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 31, "994d3b01-b86c-4b61-8585-081882b3f7cd", "First13", "Demo", "0300000013", "83210488-b33b-41c6-ac41-25b73c0ff462" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 32, "434b42cb-9172-449e-90f1-d86bb73db5fd", "First14", "Demo", "0300000014", "77d98ba7-4063-4a86-8203-85da193adbb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 33, "986a478f-f63e-44c4-a172-87290daf7b8c", "First15", "Demo", "0300000015", "1a408be7-25f3-415b-916d-70b1051a4dff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 34, "d449e204-8044-45e5-91d9-69db18f2bee9", "First16", "Demo", "0300000016", "e1cde4d4-551c-4f88-8588-61313cf64858" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 35, "2e71dfe3-6ca3-463c-bb94-02e0571b29ec", "First17", "Demo", "0300000017", "9baf40cf-8c38-4089-b541-36c01abfde56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 36, "1767fdba-5dc1-418b-9968-9275d64b03bf", "First18", "Demo", "0300000018", "710bb229-b6b7-476c-8efb-f7e4201aad74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 37, "ef974141-67dd-413a-bd56-06509887b85a", "First19", "Demo", "0300000019", "a0801042-b1a0-4f90-bb90-543b1c28b5f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 38, "e4f879f2-f6df-4774-8aab-fbf69c5f992a", "First20", "Demo", "0300000020", "627da467-a367-494c-b9a7-ad09f278a548" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 39, "88535cdb-1bfc-4483-a085-fcfb73b7a6ca", "First21", "Demo", "0300000021", "0e444a8b-fede-4c5b-b930-713b82652fb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 40, "1a1f61d1-880e-4fa5-97d5-2ccca5a30358", "First22", "Demo", "0300000022", "4a212fe5-aaad-4c93-90f2-2dce74702850" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 41, "d5c47986-2654-4a99-8d75-681978c075c2", "First23", "Demo", "0300000023", "44730c32-7294-4113-b011-623fbaa0116d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 42, "2c3c6fe8-6efb-459a-b09b-255054f3e1e3", "First24", "Demo", "0300000024", "1cc938dc-5ae9-42da-bb54-66f0b686baee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 43, "185500dd-7f45-487c-b0c0-09a4cb138570", "First25", "Demo", "0300000025", "050c80d3-c949-4d86-b262-076cebbf00fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 44, "8659fd4b-36e1-4dbc-ba3b-ed8197b39a0c", "First26", "Demo", "0300000026", "efb9d6e2-59fb-4c7f-bfb5-278ee313b86c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 45, "37e6d2c4-b005-442f-a477-e0f28664f760", "First27", "Demo", "0300000027", "fdfdba08-e14a-49fa-814a-b66ee2488874" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 46, "8a39b2f4-aa5e-402d-84fa-0e7a113cfdae", "First28", "Demo", "0300000028", "d2770805-de21-4d9e-ae5b-10b54ebd52c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 47, "b225b486-e56d-4450-9b0d-6990e9d6b0a4", "First29", "Demo", "0300000029", "8a64c356-850e-4383-892f-ffdb495175b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 48, "5776a74f-9b52-4d51-95a0-342b9e713d90", "First30", "Demo", "0300000030", "cd21b591-11ac-4454-8659-4bfd6be6f42f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 31, 0, "Lahore, Pakistan", 40, "2adc1114-2d97-4338-b98d-d180c746e886", "admin@hms.com", true, "System", "Male", "Administrator", false, null, "ADMIN@HMS.COM", "ADMIN@HMS.COM", "AQAAAAIAAYagAAAAEOM2G8P9XkY5TzR7LqV3WpZ9mN1vXc8Q==", "03000000000", false, "d0bfd930-b066-48c6-9e7b-1c6f266d6d24", false, "admin@hms.com" });

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 1,
                column: "BedNumber",
                value: "B-01");

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 2,
                column: "BedNumber",
                value: "B-02");

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 3,
                column: "BedNumber",
                value: "B-03");

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 4,
                column: "BedNumber",
                value: "B-04");

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 5,
                column: "BedNumber",
                value: "B-05");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Department 1");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Department 2");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Department 3");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Department 4");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Department 5");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConsultationFee", "Specialization" },
                values: new object[] { 2000m, "Specialty 1" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConsultationFee", "Specialization" },
                values: new object[] { 2200m, "Specialty 2" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConsultationFee", "Specialization" },
                values: new object[] { 2400m, "Specialty 3" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConsultationFee", "Specialization" },
                values: new object[] { 2600m, "Specialty 4" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConsultationFee", "Specialization" },
                values: new object[] { 2800m, "Specialty 5" });

            migrationBuilder.UpdateData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ResultDetails", "TestDate" },
                values: new object[] { "Within normal limits", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ResultDetails", "TestDate" },
                values: new object[] { "Within normal limits", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ResultDetails", "TestDate" },
                values: new object[] { "Within normal limits", new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ResultDetails", "TestDate" },
                values: new object[] { "Within normal limits", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ResultDetails", "TestDate" },
                values: new object[] { "Within normal limits", new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "TestName" },
                values: new object[] { 950m, "Lab Test 1" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "TestName" },
                values: new object[] { 1100m, "Lab Test 2" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "TestName" },
                values: new object[] { 1250m, "Lab Test 3" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "TestName" },
                values: new object[] { 1400m, "Lab Test 4" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Price", "TestName" },
                values: new object[] { 1550m, "Lab Test 5" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "StockQuantity", "UnitPrice" },
                values: new object[] { 200, 45.50m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "StockQuantity", "UnitPrice" },
                values: new object[] { 200, 91.00m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "StockQuantity", "UnitPrice" },
                values: new object[] { 200, 136.50m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "StockQuantity", "UnitPrice" },
                values: new object[] { 200, 182.00m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "StockQuantity", "UnitPrice" },
                values: new object[] { 200, 227.50m });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "BloodGroup",
                value: "B+");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "BloodGroup",
                value: "O+");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "BloodGroup",
                value: "B+");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Designation", "Salary" },
                values: new object[] { "Technician", 53000m });

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Salary",
                value: 58000m);

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Designation", "Salary" },
                values: new object[] { "Technician", 63000m });

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Salary",
                value: 68000m);

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Designation", "Salary" },
                values: new object[] { "Technician", 73000m });

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TotalBeds", "Type" },
                values: new object[] { 12, "Special" });

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalBeds",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TotalBeds", "Type" },
                values: new object[] { 12, "Special" });

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 4,
                column: "TotalBeds",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "TotalBeds", "Type" },
                values: new object[] { 12, "Special" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 31 });

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Beds_BedId",
                table: "Admissions",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Patients_PatientId",
                table: "Admissions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bills_BillId",
                table: "Payments",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionItems_Medicines_MedicineId",
                table: "PrescriptionItems",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Beds_BedId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Patients_PatientId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bills_BillId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionItems_Medicines_MedicineId",
                table: "PrescriptionItems");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 31 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "MedicalRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppointmentDate", "PatientId1", "Reason" },
                values: new object[] { new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppointmentDate", "PatientId1", "Reason" },
                values: new object[] { new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppointmentDate", "PatientId1", "Reason" },
                values: new object[] { new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AppointmentDate", "PatientId1", "Reason" },
                values: new object[] { new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AppointmentDate", "PatientId1", "Reason" },
                values: new object[] { new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 21, "584bad93-ec55-4ea5-ad8e-0f74d6b20243", "UserFN1", "UserLN", "03001234561", "STATIC_STAMP_1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 22, "433a7c79-fbd4-4343-8a87-f29c7b6c7682", "UserFN2", "UserLN", "03001234562", "STATIC_STAMP_2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 23, "7ed83f90-5212-4ec5-ba60-1546cba5bfc3", "UserFN3", "UserLN", "03001234563", "STATIC_STAMP_3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 24, "c49e80fb-b1ff-46ca-b562-947947e34d65", "UserFN4", "UserLN", "03001234564", "STATIC_STAMP_4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 25, "d4477508-14f1-4c7a-9a97-71a098d25820", "UserFN5", "UserLN", "03001234565", "STATIC_STAMP_5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 26, "75ffedb3-a489-4405-a7e8-13fff719fa7f", "UserFN6", "UserLN", "03001234566", "STATIC_STAMP_6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 27, "549a6f54-3517-4412-9acc-c2626ade2df6", "UserFN7", "UserLN", "03001234567", "STATIC_STAMP_7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 28, "9ae49757-87ce-422e-b8d7-adea9ff957f3", "UserFN8", "UserLN", "03001234568", "STATIC_STAMP_8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 29, "87ce692e-4334-4a7e-b7b0-07d355dd034c", "UserFN9", "UserLN", "03001234569", "STATIC_STAMP_9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 30, "25c65c88-ef6f-424d-b03c-403650dcea6e", "UserFN10", "UserLN", "03001234560", "STATIC_STAMP_10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 31, "fed0cbdb-3826-405b-a606-c57b8644c0ad", "UserFN11", "UserLN", "03001234561", "STATIC_STAMP_11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 32, "a89efef9-a474-4741-80dc-0f2ae95561ac", "UserFN12", "UserLN", "03001234562", "STATIC_STAMP_12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 33, "898ff550-d921-4d4d-9ce2-9fe122e65e87", "UserFN13", "UserLN", "03001234563", "STATIC_STAMP_13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 34, "60462d58-4c0c-4789-9b3b-476b69b9b159", "UserFN14", "UserLN", "03001234564", "STATIC_STAMP_14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 35, "e3e507f6-a7e6-4e6f-896b-39e856f974a3", "UserFN15", "UserLN", "03001234565", "STATIC_STAMP_15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 36, "772fe108-c3b0-478e-94f0-312b6f839415", "UserFN16", "UserLN", "03001234566", "STATIC_STAMP_16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 37, "4b242d78-9709-4e83-ac9a-6ad0e79084a5", "UserFN17", "UserLN", "03001234567", "STATIC_STAMP_17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 38, "b44834d3-2c0f-43c9-a26d-645b5837305b", "UserFN18", "UserLN", "03001234568", "STATIC_STAMP_18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 39, "b6129089-19d3-48fc-bd60-ef8e42b94590", "UserFN19", "UserLN", "03001234569", "STATIC_STAMP_19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 40, "a8fce25b-0c2b-4c36-aefb-a09044a6b0ae", "UserFN20", "UserLN", "03001234560", "STATIC_STAMP_20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 41, "452283ef-2f99-40ef-b40c-14b79ddef4a9", "UserFN21", "UserLN", "03001234561", "STATIC_STAMP_21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 42, "c35fcdcd-6e62-4741-bc6d-f0c53975b379", "UserFN22", "UserLN", "03001234562", "STATIC_STAMP_22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 43, "8e13d927-a02d-4c51-a7a6-0c072aeaea3f", "UserFN23", "UserLN", "03001234563", "STATIC_STAMP_23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 44, "a30d23d4-7be7-4e8a-a5d4-3df663e64a64", "UserFN24", "UserLN", "03001234564", "STATIC_STAMP_24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 45, "8ee664a8-772c-4de8-9842-dacc8ee993d1", "UserFN25", "UserLN", "03001234565", "STATIC_STAMP_25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 46, "5304aaf5-055c-43eb-a77f-c7c48c4fa64a", "UserFN26", "UserLN", "03001234566", "STATIC_STAMP_26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 47, "d92430cb-4bd2-45ac-8b38-2bc9d8d447bc", "UserFN27", "UserLN", "03001234567", "STATIC_STAMP_27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 48, "c0b86a49-84bc-44d9-b734-de8d737ce490", "UserFN28", "UserLN", "03001234568", "STATIC_STAMP_28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 49, "320d3d23-224a-4588-acbf-8cdf04b12f8a", "UserFN29", "UserLN", "03001234569", "STATIC_STAMP_29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Age", "ConcurrencyStamp", "FirstName", "LastName", "PhoneNumber", "SecurityStamp" },
                values: new object[] { 50, "57096c43-da03-4acc-829f-3ae7889af4e3", "UserFN30", "UserLN", "03001234560", "STATIC_STAMP_30" });

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 1,
                column: "BedNumber",
                value: "B-1");

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 2,
                column: "BedNumber",
                value: "B-2");

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 3,
                column: "BedNumber",
                value: "B-3");

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 4,
                column: "BedNumber",
                value: "B-4");

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "Id",
                keyValue: 5,
                column: "BedNumber",
                value: "B-5");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Dept 1");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Dept 2");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Dept 3");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Dept 4");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Dept 5");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 6, null, false, "Dept 6" },
                    { 7, null, false, "Dept 7" },
                    { 8, null, false, "Dept 8" },
                    { 9, null, false, "Dept 9" },
                    { 10, null, false, "Dept 10" }
                });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConsultationFee", "Specialization" },
                values: new object[] { 1500m, "Specialist" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConsultationFee", "Specialization" },
                values: new object[] { 1500m, "Specialist" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConsultationFee", "Specialization" },
                values: new object[] { 1500m, "Specialist" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConsultationFee", "Specialization" },
                values: new object[] { 1500m, "Specialist" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConsultationFee", "Specialization" },
                values: new object[] { 1500m, "Specialist" });

            migrationBuilder.UpdateData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ResultDetails", "TestDate" },
                values: new object[] { "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ResultDetails", "TestDate" },
                values: new object[] { "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ResultDetails", "TestDate" },
                values: new object[] { "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ResultDetails", "TestDate" },
                values: new object[] { "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LabReports",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ResultDetails", "TestDate" },
                values: new object[] { "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "TestName" },
                values: new object[] { 600.00m, "Test 1" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "TestName" },
                values: new object[] { 700.00m, "Test 2" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "TestName" },
                values: new object[] { 800.00m, "Test 3" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "TestName" },
                values: new object[] { 900.00m, "Test 4" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Price", "TestName" },
                values: new object[] { 1000.00m, "Test 5" });

            migrationBuilder.InsertData(
                table: "LabTests",
                columns: new[] { "Id", "Description", "IsDeleted", "Price", "TestName" },
                values: new object[,]
                {
                    { 6, null, false, 1100.00m, "Test 6" },
                    { 7, null, false, 1200.00m, "Test 7" },
                    { 8, null, false, 1300.00m, "Test 8" },
                    { 9, null, false, 1400.00m, "Test 9" },
                    { 10, null, false, 1500.00m, "Test 10" }
                });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "StockQuantity", "UnitPrice" },
                values: new object[] { 100, 10.5m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "StockQuantity", "UnitPrice" },
                values: new object[] { 100, 21.0m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "StockQuantity", "UnitPrice" },
                values: new object[] { 100, 31.5m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "StockQuantity", "UnitPrice" },
                values: new object[] { 100, 42.0m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "StockQuantity", "UnitPrice" },
                values: new object[] { 100, 52.5m });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "ExpiryDate", "IsDeleted", "Name", "StockQuantity", "UnitPrice" },
                values: new object[,]
                {
                    { 6, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 6", 100, 63.0m },
                    { 7, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 7", 100, 73.5m },
                    { 8, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 8", 100, 84.0m },
                    { 9, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 9", 100, 94.5m },
                    { 10, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Medicine 10", 100, 105.0m }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "BloodGroup",
                value: "A+");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "BloodGroup",
                value: "A+");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "BloodGroup",
                value: "A+");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BloodGroup", "EmergencyContact", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { 6, "A+", null, false, 16 },
                    { 7, "A+", null, false, 17 },
                    { 8, "A+", null, false, 18 },
                    { 9, "A+", null, false, 19 },
                    { 10, "A+", null, false, 20 }
                });

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Designation", "Salary" },
                values: new object[] { "Nurse", 45000m });

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Salary",
                value: 45000m);

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Designation", "Salary" },
                values: new object[] { "Nurse", 45000m });

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Salary",
                value: 45000m);

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Designation", "Salary" },
                values: new object[] { "Nurse", 45000m });

            migrationBuilder.InsertData(
                table: "StaffMembers",
                columns: new[] { "Id", "Designation", "IsDeleted", "Salary", "UserId" },
                values: new object[,]
                {
                    { 6, "Nurse", false, 45000m, 26 },
                    { 7, "Nurse", false, 45000m, 27 },
                    { 8, "Nurse", false, 45000m, 28 },
                    { 9, "Nurse", false, 45000m, 29 },
                    { 10, "Nurse", false, 45000m, 30 }
                });

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TotalBeds", "Type" },
                values: new object[] { 10, "General" });

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalBeds",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TotalBeds", "Type" },
                values: new object[] { 10, "General" });

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 4,
                column: "TotalBeds",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "TotalBeds", "Type" },
                values: new object[] { 10, "General" });

            migrationBuilder.InsertData(
                table: "Wards",
                columns: new[] { "Id", "IsDeleted", "Name", "TotalBeds", "Type" },
                values: new object[,]
                {
                    { 6, false, "Ward 6", 10, "General" },
                    { 7, false, "Ward 7", 10, "General" },
                    { 8, false, "Ward 8", 10, "General" },
                    { 9, false, "Ward 9", 10, "General" },
                    { 10, false, "Ward 10", 10, "General" }
                });

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "Id", "BedNumber", "IsDeleted", "IsOccupied", "WardId" },
                values: new object[,]
                {
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
                    { 6, 1500m, 6, null, "Specialist", 6 },
                    { 7, 1500m, 7, null, "Specialist", 7 },
                    { 8, 1500m, 8, null, "Specialist", 8 },
                    { 9, 1500m, 9, null, "Specialist", 9 },
                    { 10, 1500m, 10, null, "Specialist", 10 }
                });

            migrationBuilder.InsertData(
                table: "LabReports",
                columns: new[] { "Id", "IsDeleted", "LabTestId", "PatientId", "ResultDetails", "TestDate" },
                values: new object[,]
                {
                    { 6, false, 6, 6, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, false, 7, 7, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, false, 8, 8, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, false, 9, 9, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, false, 10, 10, "Normal", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "DoctorId", "PatientId", "PatientId1", "Reason", "Status" },
                values: new object[,]
                {
                    { 6, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6, null, null, "Confirmed" },
                    { 7, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7, null, null, "Confirmed" },
                    { 8, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8, null, null, "Confirmed" },
                    { 9, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 9, null, null, "Confirmed" },
                    { 10, new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10, null, null, "Confirmed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId1",
                table: "MedicalRecords",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Beds_BedId",
                table: "Admissions",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Patients_PatientId",
                table: "Admissions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId1",
                table: "Appointments",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId1",
                table: "MedicalRecords",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bills_BillId",
                table: "Payments",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionItems_Medicines_MedicineId",
                table: "PrescriptionItems",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
