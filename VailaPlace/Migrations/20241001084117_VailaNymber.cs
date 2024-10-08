using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VailaPlace.Migrations
{
    /// <inheritdoc />
    public partial class VailaNymber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VailaNumbers",
                columns: table => new
                {
                    VailaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VailaNumbers", x => x.VailaNo);
                });

            migrationBuilder.InsertData(
                table: "VailaNumbers",
                columns: new[] { "VailaNo", "CreatedDate", "SpecialDetails", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 10, 1, 10, 41, 16, 688, DateTimeKind.Local).AddTicks(4556), "Ther is no Updated date", new DateTime(2024, 10, 1, 10, 41, 16, 688, DateTimeKind.Local).AddTicks(4556) });

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 10, 41, 16, 688, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 10, 41, 16, 688, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 10, 41, 16, 688, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 10, 41, 16, 688, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 10, 41, 16, 688, DateTimeKind.Local).AddTicks(4436));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VailaNumbers");

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 8, 55, 47, 676, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 8, 55, 47, 676, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 8, 55, 47, 676, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 8, 55, 47, 676, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 1, 8, 55, 47, 676, DateTimeKind.Local).AddTicks(1772));
        }
    }
}
