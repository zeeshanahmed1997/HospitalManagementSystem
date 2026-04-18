using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMedicine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Medicines",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Medicines",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenericName",
                table: "Medicines",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e1add0de-ca7b-4c7f-90a1-b7cce6c16966", "05b17673-73eb-452f-8c3f-fdf27ca1f21a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "418336c9-a381-4c54-bc69-dd6096e7937f", "ff0b8fd0-c65d-405b-8b5b-ab83112d4e6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "80625b54-6cd0-40f5-bae4-9e7dfae6a03b", "a05b7f2a-39d9-4124-8d51-40608962a6f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "509ab5fb-4dd0-4c08-afa6-9dce1addd8f3", "2f2d2463-c95c-4761-9cf7-1ed61bca508a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "22741d77-f7db-4c4c-a9cb-a5141e43a0c1", "db27f575-1227-496e-a95a-af0e8536294b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3625e6d1-4213-46c4-bb42-358761a83a8f", "940dd3b2-3d68-4a9a-a2f9-45c68d6a15aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "63037dbd-4079-4e1f-b855-8b51710d8d32", "cd13bf2e-5ea3-4cf6-8c4b-48d3372e3a83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f297ac90-93eb-4033-ba69-4bb22d3c8832", "a5fac504-7cf7-49f2-b76c-88f4080fecbf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a597efe5-7294-471b-b965-bcd6eb180806", "91742137-6a82-4fbb-818c-cae7e2e35720" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c65f154d-841a-4a82-92f7-1bbd6e718304", "a6bc6506-3e5b-472d-9932-09fa9ee6c43b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aa36a2dd-0345-4ebb-8b7f-8ae1dc6a6456", "e9f92cb1-a304-43ae-9c61-387e40d5bcc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d41940aa-6475-4976-ae6a-bc3f41ddd9e1", "ac41e052-8dee-4eb5-a115-407ecdb56669" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eaeefb48-80fe-4722-b2bd-4ac5c6e8dfef", "092cecc7-2298-4b2f-b8c9-5f2f6e462d63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8efc9e2c-2663-4146-b6c3-b92a7f913454", "d7a25c89-4625-4db8-8ec7-028cceb61738" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1081ea2e-10e5-4f2c-8228-d3d15144fdbf", "5162c1e9-752a-49fb-95d1-321361b14eb5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ba6eb79d-15f1-473e-8850-74fa4c2d7f63", "2810720d-696d-487f-a0ac-be1b5a926949" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f779a78c-4526-4713-b9d1-ec2ee9e609f3", "d1437382-483e-483a-8b4b-ec02348fc0a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ea2b0894-a879-4051-9e76-f7499c2bde90", "32f1b4ed-70a2-4102-be83-95e54230ffb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e84fe170-0f03-43e9-a758-505bd58c11e7", "6ddf8303-f31a-47c1-a74c-383e6e310672" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b308cf85-ad98-4884-b14c-4977ad911de8", "358e5cce-bf94-46f8-a765-ddb0a4d8d508" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "019368a2-13bd-4683-9d2a-c2a5bbf6d8c8", "ee42c43e-ac38-4dc7-97ec-0293b3ee1a2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "36c08403-c2f9-4515-9149-1d0770f2d107", "28fce6a1-4f5d-4e23-b9eb-adecd3a9865f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6a945bf5-75b9-48d8-ba17-93ecd2e2fa5c", "9a20a6b8-b03a-41db-9532-d0b30f564511" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5a81916b-80dc-408d-815f-807ebe159d2e", "262fe749-b5d3-4e5e-91ab-aef2a83a3b44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aa153d7b-b69c-45e2-a940-8d2e1e42167d", "b1495efb-5163-45f3-9319-226ad8613955" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41a3dc85-28e4-4047-9190-3ede29ee7b0c", "93a1424e-ae10-492c-b363-09cedee26881" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5b4a8427-a80c-45a0-8399-b43f3ff12445", "7baacc67-28b9-4c32-8691-b37d7db033c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "704da909-6d35-4e04-806c-a002daf658dc", "e5fbf173-dab8-4ab7-ad34-85783d5daedc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9bdfd7f2-f898-439f-9f99-4ec990679585", "77cfe148-cca7-4c0c-b962-01e5fec3971b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62a51c38-809a-4b28-bf6d-b6fd0197ebb0", "c92d6e53-a504-454a-8525-969ec3716fb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cd293438-5e0f-4d45-8890-1107ffec2086", "38ba4edc-74d7-44ee-8f09-8d4f3e362552" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "GenericName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "GenericName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "GenericName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "GenericName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "GenericName" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "GenericName",
                table: "Medicines");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "72b2010b-6eaa-4151-a0be-556758455b2c", "16326205-020b-4b31-907a-1f16f949ac0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "801df791-08c2-4c1e-8641-b51fc3c10957", "4ab3646d-541c-43c6-9b61-d40e65dc289d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7a5a2acb-3962-4dcb-a830-798f2a63c08d", "7dd56f20-3eb2-46f1-8ea5-8023abf4890c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cda848cc-3104-4abf-8366-af58275e07dc", "8c69ee06-d7fe-413b-8d40-547aeb7dfdf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "915db7f3-d956-489d-a8ae-29f140d24284", "ce18786c-cf9d-4f77-bfaf-1395953cc5fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3dda1c82-bdb6-43c5-80ba-37c1c59012c0", "1e30e8fc-967b-4000-a93d-8784b809879b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff703cf7-ce3f-4ab7-a500-bc218f32ba0c", "fbae6e92-9693-4e81-8996-993baa68d37f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "775101e2-fb77-4675-97f8-c84a60dca76a", "d6790c43-b4e3-496a-bcfe-2e5230315e05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e07bb901-58b8-441f-82e9-c027b4615eee", "78b012f5-9488-468a-a08e-5563c10cc5d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "316fc778-1784-4f84-85ef-d29fda412d23", "138d831a-04f2-4b81-b6a0-38aa9e852319" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "033434a2-8495-448b-880a-9943c9ac3298", "15530ddd-93d3-4877-89c0-00fee8ab6df9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "55e3595e-6166-4034-9b98-8dee7dea2065", "16f6203e-cb21-4811-ad7b-c176fb3e7692" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4fdf9b1c-5000-4ba4-a9ea-6d3d1355122e", "a6e3b502-6d33-4138-a4d3-f73a4889601b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "536c90e8-aafa-42cb-9da4-ff26d95acce7", "fa3b8db8-50b8-4465-9bfb-1ce4dfcaf6c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "490c0d0f-5c56-4850-a0e5-b19d506562ee", "350d0f39-cf58-4c22-babc-6bd801cd5df9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2b282516-fa0e-4741-a783-e76bddd18d80", "b5f1a579-5646-4e5a-96ff-5b1b4ba03f62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8d02131b-a68a-4736-a8f5-5422386e70f3", "ef75e8f6-35f2-4333-ab7f-c585ff4e6d0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "481b3b96-fe79-4127-947c-4e6cac909128", "b8b1c5be-9b70-4abf-b95b-19d371ae7812" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8bb3ad7d-3c85-4211-ad6e-b89cfbc1c47c", "8f16a52a-f152-4657-900f-60cfd03acbe5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "14680209-cd58-4c50-b3db-f65b15ed71ba", "fa4472ab-86c4-4c33-ae7c-05fe8c9fd741" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5d5d9670-274b-4ef4-b8c8-5e6172249b64", "fe4d420d-14e1-40b2-bba8-3da5f0a84bfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "73b7843d-1fea-42ca-8cc4-08a49d1217fd", "a0b6f26a-a5bc-4202-856b-f92e9ca1d306" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "910d843d-f318-41f4-aab5-aeead0bdd9d9", "31931461-049b-4c83-8840-e88c6d9bf55a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "26f75d7a-1cce-4c85-8586-e92f490217b0", "a3e4ffa8-3f11-43b6-bfb3-19d442f1fd85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1770f15b-1280-41cf-8823-97a694071040", "47c19b76-fb24-40bb-ae49-3e693f225e4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "781dd2bd-6fcd-4181-8339-48c298039c26", "75cecf60-316d-4ae2-83df-54bdaa7d8eb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5d8bedb-b4ff-4816-b5b9-9cc9117f46d0", "61bc70db-1db8-4314-8870-dc8ebf0744f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e4fe4414-a660-4345-bd3b-f51d79302ef1", "c8a0bcb1-f204-43e5-beb6-0d7f306b8f13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7fa1fa1-6421-4b98-8d2f-d1616bfdb325", "d32edbf7-949a-48d7-884b-c7b2929e8e64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d1f1fec7-9f79-4d55-bdb3-ab8de4c616f8", "b62f2474-25c4-4382-9024-14e39cced1f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78f308b0-84a2-431b-94bc-9c3a40092050", "78bb1230-e7bd-4995-94cc-11e2494fa7da" });
        }
    }
}
