using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VailaPlace.Migrations
{
    /// <inheritdoc />
    public partial class Makeitnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VailaNumbers",
                keyColumn: "VailaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 9, 22, 18, 605, DateTimeKind.Local).AddTicks(2328), new DateTime(2024, 10, 2, 9, 22, 18, 605, DateTimeKind.Local).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 22, 18, 605, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 22, 18, 605, DateTimeKind.Local).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 22, 18, 605, DateTimeKind.Local).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 22, 18, 605, DateTimeKind.Local).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 9, 22, 18, 605, DateTimeKind.Local).AddTicks(2244));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VailaNumbers",
                keyColumn: "VailaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 1, 14, 41, 28, 934, DateTimeKind.Local).AddTicks(662), new DateTime(2024, 10, 1, 14, 41, 28, 934, DateTimeKind.Local).AddTicks(661) });

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 14, 41, 28, 934, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 14, 41, 28, 934, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 14, 41, 28, 934, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 14, 41, 28, 934, DateTimeKind.Local).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 14, 41, 28, 934, DateTimeKind.Local).AddTicks(583));
        }
    }
}
