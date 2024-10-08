using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VailaPlace.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "localUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "VailaNumbers",
                keyColumn: "VailaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(7050), new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(7049) });

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Vailas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(6949));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "localUsers");

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
    }
}
