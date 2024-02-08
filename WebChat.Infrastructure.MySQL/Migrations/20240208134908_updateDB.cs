using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebChat.Infrastructure.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_User_UserId",
                table: "GroupUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupUsers_UserId",
                table: "GroupUsers");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 8, 13, 49, 6, 956, DateTimeKind.Utc).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 8, 13, 49, 6, 956, DateTimeKind.Utc).AddTicks(7308));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 8, 13, 49, 6, 956, DateTimeKind.Utc).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 8, 13, 49, 6, 956, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 8, 13, 49, 6, 956, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 8, 13, 49, 6, 956, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 8, 13, 49, 6, 956, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 8, 13, 49, 6, 956, DateTimeKind.Utc).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 8, 13, 49, 6, 956, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 8, 13, 49, 6, 956, DateTimeKind.Utc).AddTicks(7087));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7042));

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_UserId",
                table: "GroupUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_User_UserId",
                table: "GroupUsers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
