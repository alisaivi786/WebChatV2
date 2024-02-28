using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebChat.Infrastructure.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class addUtcLastLoginColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "UtcLastLoginTime",
                table: "UserDetails",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("a4826f73-dd5d-4cd9-b626-fa3ac034d68e"), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("c3d258fa-f2da-43e9-bf2c-d44921cff0d3"), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4745) });

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("630b9739-cbc4-4887-bdef-b9dd64057f86"), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("9f6ebb31-8bdb-432e-8a14-ffe3a441385d"), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4748) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("777b5ec4-ffe7-4ac3-9ab2-4f4d5e3eec60"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4893), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4904) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("11f744c1-6990-452b-ace2-85b2613222c9"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4905), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4906) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("b973a781-c707-443d-9670-b2a2ce61b1f8"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4907), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4912) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("c6368a43-01b0-49fc-b5fe-d2cf98c206e7"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4913), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4914) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("842f0346-8be8-44fa-a6c7-d12d0a69c4f2"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4915), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4915) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("7764e805-44e6-4b7b-8525-cfe0eed397e8"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4916), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4917) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("845c1d5c-b359-49a8-bc96-028bd3136c15"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4918), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4918) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("36cf3d53-da97-42a8-b43e-be05ee658c23"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4919), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("24ee3b2b-a6d8-4fd9-9b8b-a9960642c70a"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4921), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4921) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("1f4cbcef-2c43-44f7-b086-bbd8b22919d7"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4922), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4923) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("620cbd93-5423-4bc2-bc34-decd7b612a07"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4923), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("1e295201-473f-4335-90ae-a2526f97b313"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4926), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4927) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("cb102a02-807c-4ddd-935d-5702eafa9c81"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4928), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4928) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("4658a5fd-1371-4e19-ba75-d610985c18b2"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4929), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4930) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("6d4d0cc2-35b2-4567-b15f-e36e80e930a4"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4931), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4931) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("75636188-042d-482d-bcd7-7d75d7f23e75"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4932), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("114cd239-2625-4cf4-b0d2-7aa0f832e118"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4934), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("5739ab86-93b5-481f-8bf9-75e1e05ff33e"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4935), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("f426212c-c681-4e49-b2f2-7556561ff3ff"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4936), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4938) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("483520f1-634e-4658-9039-9e0bb643aa82"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4939), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("c5d2ae00-a364-4b71-a805-0a39c6a53067"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4941), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("1e2e8253-3626-40d4-a58c-d8eda1823ebf"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4942), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4943) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("a15b111d-6cd1-4bcd-a7bc-9c0eaa4de6d0"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4944), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4944) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("0bed0d9a-402d-4e93-a958-b397df4f1fd0"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4945), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4946) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("33b83453-9187-41d1-abad-2e7accec7543"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4946), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4947) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("a51aa104-112e-43a6-a432-117512a9ba0b"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4948), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4948) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("53ba3c6b-da9b-419a-921d-ba0bdfd2e239"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4949), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4951) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("e72339de-195a-44d1-94f9-f6dea2a3b2f8"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4952), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("78a01675-d0f0-4bad-84b7-ba9e10759c29"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4953), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4954) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("df356c3a-8675-4f9c-aeb3-787bb55bdd9f"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4954), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4955) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("b38bb287-1b4c-456f-8ef8-eb3ce11be068"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4984), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4984) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("2206ed20-bfc8-4c69-801a-7629a36acf27"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4985), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4986) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("39a19fd9-9cce-4aff-ba27-5cf278024a36"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4987), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4987) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("c2b93078-7240-4bd5-9584-85aa4a3a5868"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4988), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4989) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("91c53f28-5832-4e7b-90be-3a4f5ea03847"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4989), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4991) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("2c845c6e-744a-4a23-936e-0e46adc64c65"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4992), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4993) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("ee83f727-883a-40b3-98ed-1df0a0d24d6f"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4994), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4994) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("560d2260-5bf6-4ef8-be6e-f7d65bce9a99"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4995), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4996) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("ff74a0a0-8c76-4bd8-961c-7639f692603f"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4997), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4997) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("5b658d53-e813-45f7-b922-c48182872ee7"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4998), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(4999) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("2577faac-158a-4b0f-9cf8-ee1a753a8263"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(4999), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("408e0c48-6e4f-4a4a-b203-8366791c119e"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5001), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5002) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 43L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("035e1701-7c04-4e5e-8eea-061fe5380914"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5002), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("f5f0d707-ce0c-4d2f-87cd-adc617f2a43a"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5005), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5006) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 45L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("c6a02767-2af0-496b-bd4e-9bad76eecebd"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5007), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5007) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 46L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("b5110d8c-0e86-4795-9b6c-b0d1cc515adf"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5008), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 47L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("62e9e147-22e5-4578-a9e8-4aa07657cb57"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5009), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 48L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("62d516b5-0a18-4f12-9e35-877997d8ca58"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5011), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5012) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 49L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("93169ede-baf0-4e2d-a08c-3775a986b0cd"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5012), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 50L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("79bef1e4-0d93-431c-8616-377b5ae59278"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5014), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5014) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 51L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("0302f7dd-00af-4458-8840-6366260d2fea"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5015), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5017) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 52L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("1e1a236b-d2f0-4366-9eb5-9033c538ee89"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5018), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5018) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 53L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("2db29ef3-2ade-44aa-baea-75b597cda483"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5019), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 54L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("66bdd315-56c4-4acc-a2db-827b3c3f5fff"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5021), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5021) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 55L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("29f2b526-4178-448d-8536-1aeb35761578"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5022), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5023) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 56L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("2dc7150a-3456-43e1-881b-a3389d9c3971"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5023), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5024) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 57L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("08298624-273c-4f12-af43-a58e81354c19"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5025), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5025) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 58L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("5026bd16-2217-4ee5-af93-7d27c0e624d9"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5026), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 59L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("03731c75-1895-40da-adea-efa180abd2ab"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5028), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5029) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 60L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("e8371ee2-e829-4175-a1f1-f15f804ae9e1"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5030), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5031) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 61L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("1cb95006-d805-4d1d-a01b-8c1e6c388481"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5031), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 62L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d0a27fc9-709e-41dc-a94c-135e669a1e65"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5033), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5034) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 63L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("76d30ff2-d5df-4d92-b6b4-797ec1b07147"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5034), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5035) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 64L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("36e39f37-6424-4e48-a700-17c5185298e1"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5036), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5036) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 65L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("11503470-4147-4146-a497-d559ec4e7158"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5037), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5038) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 66L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("fed28d00-2e9a-4863-a10d-3e8d5ea78869"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5038), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5039) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 67L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("47bec2d3-d051-41e9-add9-c185ad5475a6"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5040), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5042) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 68L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("91b3a5c3-d43c-42b1-a00d-3b43256f5abf"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5043), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5043) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 69L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("f36f4d73-8cba-4786-94cc-c91adb7bc4f8"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5044), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5045) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 70L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("04b75328-2aa7-4783-a7f0-6b5ab9ffbd1a"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5045), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 71L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("7352d4c5-2562-441f-8fe8-371eedb7d1b9"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5047), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5047) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 72L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("8dc0e1cf-5212-4261-8eaf-453155312fa1"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5048), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 73L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("1042c243-00bc-4204-91b9-0d9bd82d4308"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5049), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 74L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("53fdca21-9da3-497c-aa97-be81f7aee294"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5051), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5051) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 75L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("ea0c01d8-fd91-4391-a0a4-505fbafaba3f"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5052), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 76L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("cd829f13-73a0-46d7-9b40-d2125090843b"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5055), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5055) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 77L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("cd10e258-ab70-490e-803a-fdc7c0437896"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5056), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 78L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("66192e55-7517-435d-aba7-fe5e2a5842d5"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5058), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5058) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 79L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d47e7cac-cdc7-4617-b793-fa58a52e345a"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5059), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 80L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d49cc126-6d0f-4a5b-9386-c7760f12b44b"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5060), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5061) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 81L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("43fc8212-f724-45da-a08d-e2a22f34ab3a"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5062), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5062) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 82L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("1bcf72cd-4333-41ce-875c-32719e88ed00"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5082), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 83L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("974ff6bf-6522-4da8-85be-a2dbee5f05a3"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5084), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5086) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 84L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("b20018d3-ea19-4ea2-bf47-4fa02712eed5"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5086), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5087) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 85L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("e440c437-6fa9-4f4c-a52b-63a43f1055aa"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5088), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5088) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 86L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("53fb149a-26c1-4f61-88b2-0c0f3f3960a9"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5089), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 87L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("f39e4938-72a9-4722-9857-a6852c2c8e03"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5091), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5091) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 88L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("07612133-0323-4920-9b33-c4ff584a68f1"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5092), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5093) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 89L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("757a1799-8e48-4fe6-971b-ce3259030840"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5094), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5094) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 90L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("7a1168c1-4491-441c-97df-b0cad3565126"), new DateTime(2024, 2, 27, 17, 25, 30, 741, DateTimeKind.Local).AddTicks(5095), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5096) });

            migrationBuilder.UpdateData(
                table: "SubGroup",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("3622bd64-5afa-4183-8cd0-2fd1f8bc09ac"), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5189) });

            migrationBuilder.UpdateData(
                table: "SubGroup",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("eb15ef6c-aa6a-4ac5-ba8b-f6d10b1e1368"), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5191) });

            migrationBuilder.UpdateData(
                table: "SubGroup",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("f8a99d90-1fc0-4769-9d21-f8baacff8fbb"), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5193) });

            migrationBuilder.UpdateData(
                table: "SubGroup",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("be4c92f9-3517-4bf6-8846-26ad8ef4842c"), new DateTime(2024, 2, 27, 13, 25, 30, 741, DateTimeKind.Utc).AddTicks(5194) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UtcLastLoginTime",
                table: "UserDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("d8a523e8-8161-4c0a-ba1e-af3fad824870"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8498) });

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("0fad54b4-cc04-40d4-a936-cdfe5690eb2c"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("5de3e552-080a-45c7-97f0-381968cd0c91"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8505) });

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("4024040a-753d-42d5-ab49-9771def77c52"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8506) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("0790aeff-efbb-4b0c-ae33-b4f21549cb92"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8618), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8635) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("aa82b09b-f3e3-401b-9be4-d95ac9f2bc66"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8637), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8638) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("c47fa05d-d053-4a6b-8abc-415027824b94"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8639), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8640) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("20f31d9a-00d7-4e84-99dc-15079cc1644f"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8640), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8641) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("dcc5adfb-8af3-49e5-b5ea-a00408523b81"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8642), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8642) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("94bb8d82-7b24-40ab-97c6-598ec2d882e0"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8643), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8644) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("61d411da-c483-4131-b513-177be9479c76"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8644), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8645) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("1fe24a15-fea6-47c6-965b-9fa93ce749b8"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8646), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8646) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("4a46d8ae-a6e8-424a-ba7b-babfe2c13322"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8647), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8649) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("3c582416-d577-4586-8027-46ca041f0b77"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8650), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("a59ec23a-1493-4a21-815c-21758b62ecde"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8651), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8652) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("225d1ecc-e177-41da-8b9c-0a2d4735bc66"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8653), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8653) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("6420c2ef-faeb-496f-b943-5e80d9f51cc7"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8654), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8655) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("dd337ddc-d497-4bcf-9635-74814f550e1f"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8656), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8656) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("4309fa89-a1d2-48a6-babb-5c7de7086668"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8657), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8658) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("4063318d-4e4c-46a4-b7d9-00a49dd68c71"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8658), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8659) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("a9df9fb9-77a8-4ab2-a8b7-9063f7ab6a91"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8660), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8662) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("5cac8b46-2598-4ca3-b61c-b911f1cf4560"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8662), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8663) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("76d7bcae-9cad-4174-b5fd-d7568c1532ef"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8664), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8664) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("bc167d2a-487f-439b-8d25-b14d24980130"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8665), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8665) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("57e04f9f-b4a8-4c4a-896a-929bc21ec4c8"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8666), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8667) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d265b175-79d7-410a-9b2f-4f134dc4f085"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8668), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("60e2769f-77cd-4840-99ca-58e7a5bb96f0"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8669), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8669) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("e33dcc66-03e2-45b9-aa69-585f0b591bdc"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8670), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8671) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("4d23f3d6-55dc-4e91-80c8-95515eef5e59"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8671), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8673) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("3118ddd6-6018-4b53-860d-b1966eea07b0"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8674), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8675) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("80b91ea7-0290-4cf2-bf5c-2b439fafe33d"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8676), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8676) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("762e57a1-0c11-4841-8c30-07a3c51b724b"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8677), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8678) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("0dc1e2f7-3451-41ae-a60d-d61caf417296"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8678), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8679) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d72a8c05-4a66-46a7-b418-661eafccc8cc"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8680), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("bf9d141c-f1f4-4b5a-bf89-b8e6d4a4ab17"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8681), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8682) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("68ba6cad-5bdb-45da-a9e9-b35e7ca3bf73"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8682), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8683) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("9ac6eece-5510-4283-803a-98e3132d0256"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8684), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8686) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("26618f96-514b-4e42-aad1-90e91f598ee4"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8686), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8687) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d5b2fb7a-da0f-493f-8aa3-75f76bd496b8"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8688), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8688) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("0df5e2d0-5c8a-4b8b-9487-37facf8e2c65"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8689), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8690) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("7f428405-9cea-4882-8652-7206fd09dd28"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8690), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8691) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("4f225900-bcb2-4a74-b915-8c16374b0aa3"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8692), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8692) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("c5e6d29a-4391-4889-9dd2-7bd4186ee4fd"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8712), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8713) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("c23969cf-b756-4e26-bbc2-7e6575abc960"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8714), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8714) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("fd325630-8ff6-4be0-b697-7c76bce4c02e"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8715), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8717) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("2c84f4a7-981b-4027-a711-311bcdfbf6ea"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8718), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8718) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 43L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("aba0fece-8a4e-4df1-a030-c0584af832e5"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8719), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("f179c2cc-d606-4493-a673-d025a12c82ff"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8721), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8721) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 45L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("86b534bc-6bf6-4f91-925c-d460611849d9"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8722), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8723) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 46L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("7d644dc1-4759-40f5-adad-e7ee020eedac"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8723), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8724) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 47L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("7bcadb7b-05de-42f4-9aa3-49ef39988c43"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8725), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8726) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 48L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("9bf1b33c-b852-4d6c-8b5c-97a99fba534f"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8726), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8727) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 49L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("00da277f-1cda-4f8b-9a1f-6c0f64051344"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8728), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8729) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 50L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d60c595a-8596-45bc-b123-cfd66a1cc0d6"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8730), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8731) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 51L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("cf0f43ee-6500-43aa-b5fe-14931baaf60d"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8731), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8732) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 52L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("282a29c3-2c71-48e2-978b-fadb55b8d299"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8733), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8733) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 53L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("12185111-9683-4431-a026-ce3e487384b0"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8734), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8735) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 54L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("1a40c278-1215-412f-a6c6-974ee3b72c2e"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8736), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8737) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 55L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("6889fe03-c794-413d-9633-d4b5f09e65fa"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8738), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8738) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 56L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("ef5fef7e-d4cc-4d1f-9d37-452de6cb54ce"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8739), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 57L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("ba074136-f4ad-4862-ba89-52cc999800ea"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8740), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8742) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 58L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("21ac5c98-ce6d-4248-8bb6-a344172b4ecd"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8743), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8744) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 59L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("e156dd9e-785e-49a6-bccc-f2ae5c6fec85"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8744), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8745) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 60L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("916b12e2-ef0f-4127-a523-e4123e86b3ab"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8746), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8746) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 61L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("53e892f2-a93d-47e8-852f-30b5cdc1b476"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8747), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8748) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 62L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("b25a3fc7-82bd-4552-9673-24570559d8d9"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8748), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8749) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 63L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("f722109e-16c5-48f3-9be0-42418a6b4f00"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8750), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 64L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("30a81e4d-69f3-4712-ba6b-aab6d8143b1d"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8751), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8752) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 65L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d26a3b1e-fddc-4fcc-bfaa-9a58603204f2"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8752), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8754) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 66L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("57fc0048-3c91-4c67-844f-fb9197d4595f"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8755), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 67L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("99ab3f00-5bc8-4e65-b4fd-31806414e295"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8756), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8757) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 68L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("74afec30-68c9-4db8-a020-caa992afbb7a"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8758), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8758) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 69L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("66979b11-f8a3-45c9-8014-2c5725770f63"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8759), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 70L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("b8d6960a-47e6-49f5-b161-a31efea718c8"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8760), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 71L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("a77a0717-9064-4857-8e91-a8b9fbd78321"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8762), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8762) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 72L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("3c110884-1f65-4a79-a997-063a082325c9"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8763), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8764) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 73L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d6efd2fc-9d97-401a-b25f-8a432e16ffdd"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8765), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8766) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 74L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d6b49a41-976c-482a-8914-5def480df4da"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8767), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8768) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 75L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("d686b511-7504-4713-b68e-4ac600fff87c"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8768), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8769) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 76L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("05490d53-9653-46f4-9720-91ddcb1e3a81"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8770), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 77L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("5dec091f-74c2-464f-b15d-398117406576"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8771), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8772) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 78L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("4693cf7e-f8ce-4e7f-b2d0-3ccf18bb50e5"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8772), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8773) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 79L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("123f1f41-deaa-4f9d-999d-695725c78876"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8774), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8774) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 80L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("806195c9-80f7-4d00-8fb1-135e167c4808"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8775), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 81L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("0404ff56-8e9e-4ecd-8958-c5f1b97c8134"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8776), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8778) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 82L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("20655b6b-ea82-461d-bbf5-c1c170fddf73"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8779), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8779) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 83L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("4f31bbcc-fbed-4fd3-8fb8-09864f9c3904"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8780), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8781) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 84L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("bd7d1708-09e9-45e3-877c-94cf1d170326"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8781), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8782) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 85L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("aa095ed4-760d-4a97-9446-57a70c5541c9"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8783), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 86L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("969473a8-66ee-4a31-ac62-1f141a6eb159"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8784), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 87L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("76caeccd-4ac8-4a47-a23f-525bdcc953bd"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8786), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8786) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 88L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("2b16a656-d2d8-48dc-8b61-8a622da177db"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8787), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 89L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("018ca5fb-bfa4-4e16-bd09-7a8bb095f63e"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8788), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 90L,
                columns: new[] { "RowId", "SentTime", "UtcDateCreated" },
                values: new object[] { new Guid("44f20183-761a-4570-bf77-22e8e8624980"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8791), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8791) });

            migrationBuilder.UpdateData(
                table: "SubGroup",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("6eec2292-b40d-4347-b5bb-e41ac9d0c35d"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8891) });

            migrationBuilder.UpdateData(
                table: "SubGroup",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("4aa404c8-736e-451c-823f-c6710bfe56b9"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8893) });

            migrationBuilder.UpdateData(
                table: "SubGroup",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("c664928b-0c53-4952-990f-4efef5c12a2c"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8895) });

            migrationBuilder.UpdateData(
                table: "SubGroup",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "RowId", "UtcDateCreated" },
                values: new object[] { new Guid("c01900c4-803c-45a6-a1b6-87d364894a8a"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8896) });
        }
    }
}
