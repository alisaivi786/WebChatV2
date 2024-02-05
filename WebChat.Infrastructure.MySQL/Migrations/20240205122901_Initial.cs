using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebChat.Infrastructure.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
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
                        name: "FK_GroupUsers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "IsActive", "ModifiedBy", "Name" },
                values: new object[] { 1L, 1L, new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7175), null, true, null, "TB-Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "IsActive", "ModifiedBy", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7033), null, true, null, "971505679899", "Ali" },
                    { 2L, 2L, new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7041), null, true, null, "971505679800", "Poonam" },
                    { 3L, 3L, new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7042), null, true, null, "971505679888", "Aymen" }
                });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "Content", "CreatedBy", "DateCreated", "DateModified", "GroupId", "IsActive", "ModifiedBy", "SentTime", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hello Team", 1L, new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7234), null, 1L, true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 2L, "Hey Ali!", 2L, new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7236), null, 1L, true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 3L, "I am Fine Poonam what about you?", 1L, new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7268), null, 1L, true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 4L, "Good to hear you are good, thanks for asking i am also fine!.", 2L, new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7269), null, 1L, true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 5L, "hey Guys whats the update of our chat v1 Project???.", 3L, new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7271), null, 1L, true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L },
                    { 6L, "Architecture of Project is done just doing some final tweaks and then update you here in group.", 1L, new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7272), null, 1L, true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_UserId",
                table: "GroupUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_GroupId",
                table: "Message",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
