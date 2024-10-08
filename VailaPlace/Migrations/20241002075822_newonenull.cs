using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VailaPlace.Migrations
{
    /// <inheritdoc />
    public partial class newonenull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vailas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "VailaNumbers",
                keyColumn: "VailaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 9, 58, 21, 248, DateTimeKind.Local).AddTicks(3970), new DateTime(2024, 10, 2, 9, 58, 21, 248, DateTimeKind.Local).AddTicks(3969) });

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 58, 21, 248, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 58, 21, 248, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 58, 21, 248, DateTimeKind.Local).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 58, 21, 248, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 58, 21, 248, DateTimeKind.Local).AddTicks(3879));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vailas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "VailaNumbers",
                keyColumn: "VailaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 9, 23, 45, 880, DateTimeKind.Local).AddTicks(1694), new DateTime(2024, 10, 2, 9, 23, 45, 880, DateTimeKind.Local).AddTicks(1694) });

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 23, 45, 880, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 23, 45, 880, DateTimeKind.Local).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 23, 45, 880, DateTimeKind.Local).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 23, 45, 880, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 23, 45, 880, DateTimeKind.Local).AddTicks(1570));
        }
    }
}
