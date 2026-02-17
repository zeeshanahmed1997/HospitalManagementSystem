using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class updatedrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "86a68204-03f4-4d7e-9f63-fec3f89ccaa4", "0621ca05-caa2-440e-a1b5-33aa974003b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0ab45c46-7c5c-40a8-83cc-33d759d46e5e", "eb2be4ec-6151-4e11-9a6d-f9a0c243d712" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0400103d-beaa-4921-bd8f-52ad3ca3a0a1", "91f21fc5-0c97-41b1-b08e-1e3b958706e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4268ec6d-8501-4228-ba69-5a987c82c5d0", "54937e5d-a557-485d-9b29-d807cb307771" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d3357f87-6cc0-448d-9b81-2b940afdad23", "dfeddd52-9cff-470d-90fc-24ef93ab180e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9b099fa5-6b76-4e54-87e1-9a681fb943f8", "8fd59893-56e7-4efb-b6c1-8de902cc4f09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b91dca52-efc2-4da6-be56-a246a4746d3f", "2866d24c-dceb-4a60-a28f-39dc6d359a8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "be9699fd-e58e-42e2-85aa-d1a5d6bccd42", "721776d1-c874-47c3-a13a-8799b95c54c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d5327041-8909-43b8-af0a-621dee555988", "9cbd60e3-e8e8-450b-bf79-e70a2472afbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fd94599d-8575-4a19-b028-284c95867837", "138fb09c-1ee8-4f8a-a44a-12549f1e751b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0e8f937e-74b9-42fb-ac12-09e1197f7f36", "a5580ec9-de9e-47bf-bd8a-5739b9c306e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dfb6fd76-a89a-4cb6-a711-d2efe6bbc1c0", "c3a53a6a-3eab-4f3f-96c2-cbb61ac5e229" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "994d3b01-b86c-4b61-8585-081882b3f7cd", "83210488-b33b-41c6-ac41-25b73c0ff462" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "434b42cb-9172-449e-90f1-d86bb73db5fd", "77d98ba7-4063-4a86-8203-85da193adbb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "986a478f-f63e-44c4-a172-87290daf7b8c", "1a408be7-25f3-415b-916d-70b1051a4dff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d449e204-8044-45e5-91d9-69db18f2bee9", "e1cde4d4-551c-4f88-8588-61313cf64858" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2e71dfe3-6ca3-463c-bb94-02e0571b29ec", "9baf40cf-8c38-4089-b541-36c01abfde56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1767fdba-5dc1-418b-9968-9275d64b03bf", "710bb229-b6b7-476c-8efb-f7e4201aad74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ef974141-67dd-413a-bd56-06509887b85a", "a0801042-b1a0-4f90-bb90-543b1c28b5f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e4f879f2-f6df-4774-8aab-fbf69c5f992a", "627da467-a367-494c-b9a7-ad09f278a548" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "88535cdb-1bfc-4483-a085-fcfb73b7a6ca", "0e444a8b-fede-4c5b-b930-713b82652fb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a1f61d1-880e-4fa5-97d5-2ccca5a30358", "4a212fe5-aaad-4c93-90f2-2dce74702850" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d5c47986-2654-4a99-8d75-681978c075c2", "44730c32-7294-4113-b011-623fbaa0116d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2c3c6fe8-6efb-459a-b09b-255054f3e1e3", "1cc938dc-5ae9-42da-bb54-66f0b686baee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "185500dd-7f45-487c-b0c0-09a4cb138570", "050c80d3-c949-4d86-b262-076cebbf00fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8659fd4b-36e1-4dbc-ba3b-ed8197b39a0c", "efb9d6e2-59fb-4c7f-bfb5-278ee313b86c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "37e6d2c4-b005-442f-a477-e0f28664f760", "fdfdba08-e14a-49fa-814a-b66ee2488874" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8a39b2f4-aa5e-402d-84fa-0e7a113cfdae", "d2770805-de21-4d9e-ae5b-10b54ebd52c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b225b486-e56d-4450-9b0d-6990e9d6b0a4", "8a64c356-850e-4383-892f-ffdb495175b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5776a74f-9b52-4d51-95a0-342b9e713d90", "cd21b591-11ac-4454-8659-4bfd6be6f42f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2adc1114-2d97-4338-b98d-d180c746e886", "d0bfd930-b066-48c6-9e7b-1c6f266d6d24" });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
