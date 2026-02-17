using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class updatedrelatio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Prescriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PrescriptionItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MedicalRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BillItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Admissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "72b2010b-6eaa-4151-a0be-556758455b2c", false, "16326205-020b-4b31-907a-1f16f949ac0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "801df791-08c2-4c1e-8641-b51fc3c10957", false, "4ab3646d-541c-43c6-9b61-d40e65dc289d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "7a5a2acb-3962-4dcb-a830-798f2a63c08d", false, "7dd56f20-3eb2-46f1-8ea5-8023abf4890c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "cda848cc-3104-4abf-8366-af58275e07dc", false, "8c69ee06-d7fe-413b-8d40-547aeb7dfdf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "915db7f3-d956-489d-a8ae-29f140d24284", false, "ce18786c-cf9d-4f77-bfaf-1395953cc5fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "3dda1c82-bdb6-43c5-80ba-37c1c59012c0", false, "1e30e8fc-967b-4000-a93d-8784b809879b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "ff703cf7-ce3f-4ab7-a500-bc218f32ba0c", false, "fbae6e92-9693-4e81-8996-993baa68d37f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "775101e2-fb77-4675-97f8-c84a60dca76a", false, "d6790c43-b4e3-496a-bcfe-2e5230315e05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "e07bb901-58b8-441f-82e9-c027b4615eee", false, "78b012f5-9488-468a-a08e-5563c10cc5d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "316fc778-1784-4f84-85ef-d29fda412d23", false, "138d831a-04f2-4b81-b6a0-38aa9e852319" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "033434a2-8495-448b-880a-9943c9ac3298", false, "15530ddd-93d3-4877-89c0-00fee8ab6df9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "55e3595e-6166-4034-9b98-8dee7dea2065", false, "16f6203e-cb21-4811-ad7b-c176fb3e7692" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "4fdf9b1c-5000-4ba4-a9ea-6d3d1355122e", false, "a6e3b502-6d33-4138-a4d3-f73a4889601b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "536c90e8-aafa-42cb-9da4-ff26d95acce7", false, "fa3b8db8-50b8-4465-9bfb-1ce4dfcaf6c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "490c0d0f-5c56-4850-a0e5-b19d506562ee", false, "350d0f39-cf58-4c22-babc-6bd801cd5df9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "2b282516-fa0e-4741-a783-e76bddd18d80", false, "b5f1a579-5646-4e5a-96ff-5b1b4ba03f62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "8d02131b-a68a-4736-a8f5-5422386e70f3", false, "ef75e8f6-35f2-4333-ab7f-c585ff4e6d0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "481b3b96-fe79-4127-947c-4e6cac909128", false, "b8b1c5be-9b70-4abf-b95b-19d371ae7812" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "8bb3ad7d-3c85-4211-ad6e-b89cfbc1c47c", false, "8f16a52a-f152-4657-900f-60cfd03acbe5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "14680209-cd58-4c50-b3db-f65b15ed71ba", false, "fa4472ab-86c4-4c33-ae7c-05fe8c9fd741" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "5d5d9670-274b-4ef4-b8c8-5e6172249b64", false, "fe4d420d-14e1-40b2-bba8-3da5f0a84bfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "73b7843d-1fea-42ca-8cc4-08a49d1217fd", false, "a0b6f26a-a5bc-4202-856b-f92e9ca1d306" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "910d843d-f318-41f4-aab5-aeead0bdd9d9", false, "31931461-049b-4c83-8840-e88c6d9bf55a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "26f75d7a-1cce-4c85-8586-e92f490217b0", false, "a3e4ffa8-3f11-43b6-bfb3-19d442f1fd85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "1770f15b-1280-41cf-8823-97a694071040", false, "47c19b76-fb24-40bb-ae49-3e693f225e4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "781dd2bd-6fcd-4181-8339-48c298039c26", false, "75cecf60-316d-4ae2-83df-54bdaa7d8eb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "c5d8bedb-b4ff-4816-b5b9-9cc9117f46d0", false, "61bc70db-1db8-4314-8870-dc8ebf0744f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "e4fe4414-a660-4345-bd3b-f51d79302ef1", false, "c8a0bcb1-f204-43e5-beb6-0d7f306b8f13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "c7fa1fa1-6421-4b98-8d2f-d1616bfdb325", false, "d32edbf7-949a-48d7-884b-c7b2929e8e64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "d1f1fec7-9f79-4d55-bdb3-ab8de4c616f8", false, "b62f2474-25c4-4382-9024-14e39cced1f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "IsDeleted", "SecurityStamp" },
                values: new object[] { "78f308b0-84a2-431b-94bc-9c3a40092050", false, "78bb1230-e7bd-4995-94cc-11e2494fa7da" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PrescriptionItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BillItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Admissions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "07b7b54d-7205-4634-8504-41029b91b224", "92456c50-de71-44f3-833e-7ecd9fc073f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "00a24130-18ee-4794-9412-1cf8c4c1f459", "c8a41ef9-a1ec-4840-8d07-d5f735226771" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "220cdea8-5fd8-4f44-b4b0-8aa6d3183408", "35cb0aed-2165-48ae-8a15-84ef8fcbb62c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1afc0807-bdb9-46d0-91b0-0222fbe44aa1", "0693200f-6e9a-4468-9852-0f445269b551" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ad3646b-2eed-48d5-8a93-acad5e662b3b", "cf81ded2-75f4-4434-ad69-2b3cfa0ceede" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f08cb824-cb7a-4d32-ba48-6080993c15f3", "9ce9e799-3227-4b63-97bd-9f7ac24ea658" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d6d91cc7-4d17-490a-be28-fc51b788bc31", "3707963c-1e72-46c0-9369-a370a2cd5ba8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5766fcf0-19d2-4516-96c3-722690a5b86d", "b86823ed-7e55-4f96-af2c-d8ad8cc82eab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d09d9225-7df2-4e40-9c14-55307e55412c", "e020d48c-1616-4b44-ad0c-9da714df3750" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "28df0c04-90e6-465c-9a7f-6e460d6b17e8", "4f51e266-3698-42dc-84a8-7854f3ce0672" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "22d345be-91bf-4156-999f-1734253f053f", "7f53eaa1-40cb-41da-ac94-377486026a1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6ce96c3f-fcf3-40d0-bb49-f3dca3c84329", "40c7b769-3a01-43d7-9349-9f99aa804fa3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ccf39d44-87f9-4f02-aad2-1a0692728df1", "764042bb-ad1c-49ee-bb56-25cc8f8b6b69" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "708d8397-f8c0-474a-8252-ce1a786b064d", "b1407244-3e73-4699-bedb-ea49470f8c20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "76bd42fc-2b4b-47f6-802c-5812d615879d", "042035e1-c3f2-4ece-8514-c5175b545f05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1d9cd68-b0b7-46cc-b1de-4badba786c31", "e72baef2-e0c2-4db3-bcc6-6bece0fa99dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1c723412-9a3f-4e54-8a08-b176bd66527a", "f1a2cd59-63a2-4e44-b981-6e43429d9ffd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bb73c36c-b585-41c6-9c0f-837801c7b1a1", "1c6f9cda-efe5-4a88-804c-bd19df372ca8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f6f8ba54-52d9-40d1-81b0-efc47b8ce4cd", "18d3369c-4699-45d8-90e5-df6009a7ba4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0e468a7c-a1ee-4917-b73f-2b3b5b075300", "bd2f6def-bf51-4e5b-8fc3-7621ba5625f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ea44d7db-ba9a-4dae-bb4e-3aa0cb80c5f9", "31314fcc-10e9-40a0-b26a-d96e79ee07cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f5644d30-4e04-47f5-bb40-d83b10015179", "285d0ec0-4092-4057-a8b7-13bec59a22fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f90a5fb1-0bd2-4e0a-aa88-8e72879f5b3c", "fda34994-bc1f-4a69-a945-b09e06e84c9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7a9171e9-f2b7-4ca2-8700-2b8326d1bb2e", "0476afc0-efe0-434b-b7eb-166c40a351bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ebf9d4b8-3f2e-4655-a72a-cda5c8608725", "e917b5f4-f879-42fe-ac26-86d6bf168ae2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c4137a8d-266e-4844-a5f1-718036af942e", "72772777-f459-4ccd-bff9-978edf13c83d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c369d577-ab37-4856-a18c-5df545d2f394", "6a1fdce0-8fb2-4e74-b09a-85586272c79e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a71bdcb0-44ae-43c7-af62-c30b17c9a4dc", "6b58ed16-3281-489e-be96-f586d5c83085" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0a6668d6-1f50-4a54-b06c-1696e657fc8c", "224bd4d6-5dcf-4834-a768-e1f445af3ced" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "608de6f5-647e-4d44-9acf-2a1a0f587bc9", "78c75147-8f8b-4435-b868-1912ad56207b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "019f52cc-80b5-494f-9db9-8bcf210f3234", "a3cfa07a-4ba9-48e9-9c0a-b7edc4987f49" });
        }
    }
}
