using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebChat.Infrastructure.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 20, 8, 38, 46, DateTimeKind.Utc).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 20, 8, 38, 46, DateTimeKind.Utc).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 20, 8, 38, 46, DateTimeKind.Utc).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 20, 8, 38, 46, DateTimeKind.Utc).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 20, 8, 38, 46, DateTimeKind.Utc).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 20, 8, 38, 46, DateTimeKind.Utc).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 20, 8, 38, 46, DateTimeKind.Utc).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 20, 8, 38, 46, DateTimeKind.Utc).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 20, 8, 38, 46, DateTimeKind.Utc).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2024, 2, 5, 20, 8, 38, 46, DateTimeKind.Utc).AddTicks(3825));
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
        }
    }
}
