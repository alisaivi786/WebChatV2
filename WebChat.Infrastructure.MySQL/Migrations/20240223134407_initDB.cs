using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebChat.Infrastructure.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    RowId = table.Column<Guid>(type: "char(36)", nullable: true),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UtcDateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoginInUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UtcLastLoginTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RowId = table.Column<Guid>(type: "char(36)", nullable: true),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UtcDateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInUser", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: true),
                    NickName = table.Column<string>(type: "longtext", nullable: true),
                    UserPhoto = table.Column<string>(type: "longtext", nullable: true),
                    RowId = table.Column<Guid>(type: "char(36)", nullable: true),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UtcDateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    RowId = table.Column<Guid>(type: "char(36)", nullable: true),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UtcDateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    SubGroupId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RowId = table.Column<Guid>(type: "char(36)", nullable: true),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UtcDateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUsers_SubGroup_SubGroupId",
                        column: x => x.SubGroupId,
                        principalTable: "SubGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: true),
                    SentTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SubGroupId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UUID = table.Column<string>(type: "longtext", nullable: true),
                    RowId = table.Column<Guid>(type: "char(36)", nullable: true),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UtcDateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_SubGroup_SubGroupId",
                        column: x => x.SubGroupId,
                        principalTable: "SubGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "CreatedBy", "IsActive", "ModifiedBy", "Name", "RowId", "UtcDateCreated", "UtcDateModified" },
                values: new object[,]
                {
                    { 1L, 1L, true, null, "Win", new Guid("d8a523e8-8161-4c0a-ba1e-af3fad824870"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8498), null },
                    { 2L, 1L, true, null, "5D", new Guid("0fad54b4-cc04-40d4-a936-cdfe5690eb2c"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8504), null },
                    { 3L, 1L, true, null, "K3", new Guid("5de3e552-080a-45c7-97f0-381968cd0c91"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8505), null },
                    { 4L, 1L, true, null, "TrxWin", new Guid("4024040a-753d-42d5-ab49-9771def77c52"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8506), null }
                });

            migrationBuilder.InsertData(
                table: "SubGroup",
                columns: new[] { "Id", "CreatedBy", "GroupId", "IsActive", "ModifiedBy", "Name", "RowId", "UtcDateCreated", "UtcDateModified" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, true, null, "10 Minute", new Guid("6eec2292-b40d-4347-b5bb-e41ac9d0c35d"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8891), null },
                    { 2L, 1L, 2L, true, null, "10 Minute", new Guid("4aa404c8-736e-451c-823f-c6710bfe56b9"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8893), null },
                    { 3L, 1L, 3L, true, null, "10 Minute", new Guid("c664928b-0c53-4952-990f-4efef5c12a2c"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8895), null },
                    { 4L, 1L, 4L, true, null, "10 Minute", new Guid("c01900c4-803c-45a6-a1b6-87d364894a8a"), new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8896), null }
                });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "Content", "CreatedBy", "IsActive", "ModifiedBy", "RowId", "SentTime", "SubGroupId", "UUID", "UserId", "UtcDateCreated", "UtcDateModified" },
                values: new object[,]
                {
                    { 1L, "Hello Team!", null, true, null, new Guid("0790aeff-efbb-4b0c-ae33-b4f21549cb92"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8618), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8635), null },
                    { 2L, "Did you watch the recent cricket match?", null, true, null, new Guid("aa82b09b-f3e3-401b-9be4-d95ac9f2bc66"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8637), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8638), null },
                    { 3L, "Yes, it was an exciting game!", null, true, null, new Guid("c47fa05d-d053-4a6b-8abc-415027824b94"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8639), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8640), null },
                    { 4L, "Who do you think will win the upcoming elections?", null, true, null, new Guid("20f31d9a-00d7-4e84-99dc-15079cc1644f"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8640), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8641), null },
                    { 5L, "I'm not sure, it's hard to predict.", null, true, null, new Guid("dcc5adfb-8af3-49e5-b5ea-a00408523b81"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8642), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8642), null },
                    { 6L, "I think the cricket team needs better bowling.", null, true, null, new Guid("94bb8d82-7b24-40ab-97c6-598ec2d882e0"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8643), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8644), null },
                    { 7L, "What's your favorite cricket team?", null, true, null, new Guid("61d411da-c483-4131-b513-177be9479c76"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8644), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8645), null },
                    { 8L, "I support the national team!", null, true, null, new Guid("1fe24a15-fea6-47c6-965b-9fa93ce749b8"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8646), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8646), null },
                    { 9L, "Cricket is so popular, isn't it?", null, true, null, new Guid("4a46d8ae-a6e8-424a-ba7b-babfe2c13322"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8647), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8649), null },
                    { 10L, "I heard there's a new political party forming.", null, true, null, new Guid("3c582416-d577-4586-8027-46ca041f0b77"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8650), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8651), null },
                    { 11L, "Really? What's their agenda?", null, true, null, new Guid("a59ec23a-1493-4a21-815c-21758b62ecde"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8651), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8652), null },
                    { 12L, "I hope they focus on education and healthcare.", null, true, null, new Guid("225d1ecc-e177-41da-8b9c-0a2d4735bc66"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8653), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8653), null },
                    { 13L, "Have you ever been to a live cricket match?", null, true, null, new Guid("6420c2ef-faeb-496f-b943-5e80d9f51cc7"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8654), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8655), null },
                    { 14L, "Yes, the atmosphere is incredible!", null, true, null, new Guid("dd337ddc-d497-4bcf-9635-74814f550e1f"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8656), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8656), null },
                    { 15L, "Let's plan a movie night this weekend.", null, true, null, new Guid("4309fa89-a1d2-48a6-babb-5c7de7086668"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8657), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8658), null },
                    { 16L, "Sure, I'm up for it!", null, true, null, new Guid("4063318d-4e4c-46a4-b7d9-00a49dd68c71"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8658), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8659), null },
                    { 17L, "I'll bring the popcorn!", null, true, null, new Guid("a9df9fb9-77a8-4ab2-a8b7-9063f7ab6a91"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8660), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8662), null },
                    { 18L, "What's your take on the current economic situation?", null, true, null, new Guid("5cac8b46-2598-4ca3-b61c-b911f1cf4560"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8662), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8663), null },
                    { 19L, "It's quite challenging, especially for small businesses.", null, true, null, new Guid("76d7bcae-9cad-4174-b5fd-d7568c1532ef"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8664), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8664), null },
                    { 20L, "We should stay positive and support local businesses.", null, true, null, new Guid("bc167d2a-487f-439b-8d25-b14d24980130"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8665), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8665), null },
                    { 21L, "What's your favorite cuisine?", null, true, null, new Guid("57e04f9f-b4a8-4c4a-896a-929bc21ec4c8"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8666), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8667), null },
                    { 22L, "I love Italian food!", null, true, null, new Guid("d265b175-79d7-410a-9b2f-4f134dc4f085"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8668), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8668), null },
                    { 23L, "Mexican cuisine is my go-to choice.", null, true, null, new Guid("60e2769f-77cd-4840-99ca-58e7a5bb96f0"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8669), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8669), null },
                    { 24L, "Let's plan a potluck dinner!", null, true, null, new Guid("e33dcc66-03e2-45b9-aa69-585f0b591bdc"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8670), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8671), null },
                    { 25L, "I'm in! I'll bring my famous lasagna.", null, true, null, new Guid("4d23f3d6-55dc-4e91-80c8-95515eef5e59"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8671), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8673), null },
                    { 26L, "Sounds delicious! I'll make guacamole.", null, true, null, new Guid("3118ddd6-6018-4b53-860d-b1966eea07b0"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8674), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8675), null },
                    { 27L, "Count me in too! I'll bring dessert.", null, true, null, new Guid("80b91ea7-0290-4cf2-bf5c-2b439fafe33d"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8676), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8676), null },
                    { 28L, "Have you read any good books lately?", null, true, null, new Guid("762e57a1-0c11-4841-8c30-07a3c51b724b"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8677), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8678), null },
                    { 29L, "I just finished a fantastic mystery novel.", null, true, null, new Guid("0dc1e2f7-3451-41ae-a60d-d61caf417296"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8678), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8679), null },
                    { 30L, "I'm into science fiction. Any recommendations?", null, true, null, new Guid("d72a8c05-4a66-46a7-b418-661eafccc8cc"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8680), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8680), null },
                    { 31L, "Let's organize a hiking trip next month.", null, true, null, new Guid("bf9d141c-f1f4-4b5a-bf89-b8e6d4a4ab17"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8681), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8682), null },
                    { 32L, "That sounds like a great idea! I'm in!", null, true, null, new Guid("68ba6cad-5bdb-45da-a9e9-b35e7ca3bf73"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8682), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8683), null },
                    { 33L, "Count me in too! I love nature hikes.", null, true, null, new Guid("9ac6eece-5510-4283-803a-98e3132d0256"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8684), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8686), null },
                    { 34L, "What's your favorite hiking trail?", null, true, null, new Guid("26618f96-514b-4e42-aad1-90e91f598ee4"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8686), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8687), null },
                    { 35L, "I enjoy trails with scenic views and waterfalls.", null, true, null, new Guid("d5b2fb7a-da0f-493f-8aa3-75f76bd496b8"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8688), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8688), null },
                    { 36L, "I prefer challenging mountain trails. The more difficult, the better!", null, true, null, new Guid("0df5e2d0-5c8a-4b8b-9487-37facf8e2c65"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8689), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8690), null },
                    { 37L, "Have you tried rock climbing before?", null, true, null, new Guid("7f428405-9cea-4882-8652-7206fd09dd28"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8690), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8691), null },
                    { 38L, "Yes, it's an adrenaline rush! Highly recommend it.", null, true, null, new Guid("4f225900-bcb2-4a74-b915-8c16374b0aa3"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8692), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8692), null },
                    { 39L, "Rock climbing sounds exciting. I'll give it a try!", null, true, null, new Guid("c5e6d29a-4391-4889-9dd2-7bd4186ee4fd"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8712), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8713), null },
                    { 40L, "What's your favorite season for outdoor activities?", null, true, null, new Guid("c23969cf-b756-4e26-bbc2-7e6575abc960"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8714), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8714), null },
                    { 41L, "I love the fall season. The weather is perfect for hiking.", null, true, null, new Guid("fd325630-8ff6-4be0-b697-7c76bce4c02e"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8715), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8717), null },
                    { 42L, "Summer is my favorite. Beach days and outdoor events!", null, true, null, new Guid("2c84f4a7-981b-4027-a711-311bcdfbf6ea"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8718), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8718), null },
                    { 43L, "Let's plan a beach day soon.", null, true, null, new Guid("aba0fece-8a4e-4df1-a030-c0584af832e5"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8719), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8720), null },
                    { 44L, "I'm in! I miss the sound of ocean waves.", null, true, null, new Guid("f179c2cc-d606-4493-a673-d025a12c82ff"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8721), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8721), null },
                    { 45L, "Count me in too! I'll bring the beach games.", null, true, null, new Guid("86b534bc-6bf6-4f91-925c-d460611849d9"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8722), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8723), null },
                    { 46L, "Have you ever tried scuba diving?", null, true, null, new Guid("7d644dc1-4759-40f5-adad-e7ee020eedac"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8723), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8724), null },
                    { 47L, "Not yet, but it's on my bucket list!", null, true, null, new Guid("7bcadb7b-05de-42f4-9aa3-49ef39988c43"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8725), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8726), null },
                    { 48L, "I've been scuba diving in some amazing locations.", null, true, null, new Guid("9bf1b33c-b852-4d6c-8b5c-97a99fba534f"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8726), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8727), null },
                    { 49L, "Let's plan a game night with board games and snacks.", null, true, null, new Guid("00da277f-1cda-4f8b-9a1f-6c0f64051344"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8728), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8729), null },
                    { 50L, "I'm in! I have a collection of board games at home.", null, true, null, new Guid("d60c595a-8596-45bc-b123-cfd66a1cc0d6"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8730), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8731), null },
                    { 51L, "Count me in too! I'll bring some homemade snacks.", null, true, null, new Guid("cf0f43ee-6500-43aa-b5fe-14931baaf60d"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8731), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8732), null },
                    { 52L, "Do you have any favorite board games?", null, true, null, new Guid("282a29c3-2c71-48e2-978b-fadb55b8d299"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8733), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8733), null },
                    { 53L, "I enjoy strategy games like Settlers of Catan.", null, true, null, new Guid("12185111-9683-4431-a026-ce3e487384b0"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8734), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8735), null },
                    { 54L, "I love party games like Codenames. Always so much fun!", null, true, null, new Guid("1a40c278-1215-412f-a6c6-974ee3b72c2e"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8736), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8737), null },
                    { 55L, "Let's share our favorite music playlists.", null, true, null, new Guid("6889fe03-c794-413d-9633-d4b5f09e65fa"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8738), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8738), null },
                    { 56L, "I'm into indie rock. What about you?", null, true, null, new Guid("ef5fef7e-d4cc-4d1f-9d37-452de6cb54ce"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8739), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8740), null },
                    { 57L, "I enjoy a mix of genres, but electronic music is my favorite.", null, true, null, new Guid("ba074136-f4ad-4862-ba89-52cc999800ea"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8740), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8742), null },
                    { 58L, "Have you ever attended a music festival?", null, true, null, new Guid("21ac5c98-ce6d-4248-8bb6-a344172b4ecd"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8743), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8744), null },
                    { 59L, "Yes, the energy and live performances are unforgettable!", null, true, null, new Guid("e156dd9e-785e-49a6-bccc-f2ae5c6fec85"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8744), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8745), null },
                    { 60L, "I've been to a few. It's a unique experience every time.", null, true, null, new Guid("916b12e2-ef0f-4127-a523-e4123e86b3ab"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8746), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8746), null },
                    { 61L, "Let's plan a weekend getaway to the mountains.", null, true, null, new Guid("53e892f2-a93d-47e8-852f-30b5cdc1b476"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8747), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8748), null },
                    { 62L, "I'm in! A cabin in the woods sounds perfect.", null, true, null, new Guid("b25a3fc7-82bd-4552-9673-24570559d8d9"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8748), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8749), null },
                    { 63L, "Count me in too! I love the serenity of the mountains.", null, true, null, new Guid("f722109e-16c5-48f3-9be0-42418a6b4f00"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8750), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8750), null },
                    { 64L, "What's your favorite travel destination?", null, true, null, new Guid("30a81e4d-69f3-4712-ba6b-aab6d8143b1d"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8751), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8752), null },
                    { 65L, "I love exploring European cities and their rich history.", null, true, null, new Guid("d26a3b1e-fddc-4fcc-bfaa-9a58603204f2"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8752), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8754), null },
                    { 66L, "Beach destinations are my favorite. I love the sun and sand.", null, true, null, new Guid("57fc0048-3c91-4c67-844f-fb9197d4595f"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8755), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8756), null },
                    { 67L, "Let's plan a photography day and capture the beauty around us.", null, true, null, new Guid("99ab3f00-5bc8-4e65-b4fd-31806414e295"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8756), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8757), null },
                    { 68L, "Great idea! I'll bring my camera and some lenses.", null, true, null, new Guid("74afec30-68c9-4db8-a020-caa992afbb7a"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8758), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8758), null },
                    { 69L, "Count me in too! I love photography.", null, true, null, new Guid("66979b11-f8a3-45c9-8014-2c5725770f63"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8759), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8760), null },
                    { 70L, "Do you prefer digital or film photography?", null, true, null, new Guid("b8d6960a-47e6-49f5-b161-a31efea718c8"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8760), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8761), null },
                    { 71L, "I love the convenience of digital photography.", null, true, null, new Guid("a77a0717-9064-4857-8e91-a8b9fbd78321"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8762), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8762), null },
                    { 72L, "Film photography has a unique charm. I enjoy both.", null, true, null, new Guid("3c110884-1f65-4a79-a997-063a082325c9"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8763), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8764), null },
                    { 73L, "Let's try a new restaurant together. Any cuisine preferences?", null, true, null, new Guid("d6efd2fc-9d97-401a-b25f-8a432e16ffdd"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8765), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8766), null },
                    { 74L, "I'm a fan of Italian cuisine. Pasta and pizza are my weaknesses.", null, true, null, new Guid("d6b49a41-976c-482a-8914-5def480df4da"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8767), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8768), null },
                    { 75L, "I love exploring different cuisines. Surprise me!", null, true, null, new Guid("d686b511-7504-4713-b68e-4ac600fff87c"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8768), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8769), null },
                    { 76L, "Have you ever participated in a charity run or walk?", null, true, null, new Guid("05490d53-9653-46f4-9720-91ddcb1e3a81"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8770), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8770), null },
                    { 77L, "Yes, it's a great way to stay active and contribute to a cause.", null, true, null, new Guid("5dec091f-74c2-464f-b15d-398117406576"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8771), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8772), null },
                    { 78L, "I've been part of a few. It's fulfilling to make a difference.", null, true, null, new Guid("4693cf7e-f8ce-4e7f-b2d0-3ccf18bb50e5"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8772), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8773), null },
                    { 79L, "Let's plan a weekend brunch. Any favorite brunch spots?", null, true, null, new Guid("123f1f41-deaa-4f9d-999d-695725c78876"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8774), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8774), null },
                    { 80L, "I know a cozy café with the best brunch menu!", null, true, null, new Guid("806195c9-80f7-4d00-8fb1-135e167c4808"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8775), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8776), null },
                    { 81L, "I'm up for brunch! Let's try something new and exciting.", null, true, null, new Guid("0404ff56-8e9e-4ecd-8958-c5f1b97c8134"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8776), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8778), null },
                    { 82L, "What's your go-to workout routine?", null, true, null, new Guid("20655b6b-ea82-461d-bbf5-c1c170fddf73"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8779), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8779), null },
                    { 83L, "I enjoy a mix of cardio and strength training.", null, true, null, new Guid("4f31bbcc-fbed-4fd3-8fb8-09864f9c3904"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8780), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8781), null },
                    { 84L, "Yoga is my go-to. It keeps me balanced and relaxed.", null, true, null, new Guid("bd7d1708-09e9-45e3-877c-94cf1d170326"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8781), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8782), null },
                    { 85L, "Let's plan a movie night. Any genre preferences?", null, true, null, new Guid("aa095ed4-760d-4a97-9446-57a70c5541c9"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8783), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8783), null },
                    { 86L, "I love sci-fi movies. The more futuristic, the better!", null, true, null, new Guid("969473a8-66ee-4a31-ac62-1f141a6eb159"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8784), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8785), null },
                    { 87L, "I enjoy a good comedy. Laughter is the best medicine.", null, true, null, new Guid("76caeccd-4ac8-4a47-a23f-525bdcc953bd"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8786), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8786), null },
                    { 88L, "Have you ever tried bungee jumping or skydiving?", null, true, null, new Guid("2b16a656-d2d8-48dc-8b61-8a622da177db"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8787), 1L, null, 1L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8787), null },
                    { 89L, "Not yet, but it's on my adventure bucket list!", null, true, null, new Guid("018ca5fb-bfa4-4e16-bd09-7a8bb095f63e"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8788), 1L, null, 2L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8790), null },
                    { 90L, "I've tried both. The adrenaline rush is indescribable!", null, true, null, new Guid("44f20183-761a-4570-bf77-22e8e8624980"), new DateTime(2024, 2, 23, 17, 44, 6, 909, DateTimeKind.Local).AddTicks(8791), 1L, null, 3L, new DateTime(2024, 2, 23, 13, 44, 6, 909, DateTimeKind.Utc).AddTicks(8791), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_SubGroupId",
                table: "GroupUsers",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SubGroupId",
                table: "Message",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGroup_GroupId",
                table: "SubGroup",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "LoginInUser");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "SubGroup");

            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
