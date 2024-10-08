using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VailaPlace.Migrations
{
    /// <inheritdoc />
    public partial class addforginkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VailaId",
                table: "VailaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VailaNumbers",
                keyColumn: "VailaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate", "VailaId" },
                values: new object[] { new DateTime(2024, 10, 1, 14, 41, 28, 934, DateTimeKind.Local).AddTicks(662), new DateTime(2024, 10, 1, 14, 41, 28, 934, DateTimeKind.Local).AddTicks(661), 0 });

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

            migrationBuilder.CreateIndex(
                name: "IX_VailaNumbers_VailaId",
                table: "VailaNumbers",
                column: "VailaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VailaNumbers_Vailas_VailaId",
                table: "VailaNumbers",
                column: "VailaId",
                principalTable: "Vailas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VailaNumbers_Vailas_VailaId",
                table: "VailaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VailaNumbers_VailaId",
                table: "VailaNumbers");

            migrationBuilder.DropColumn(
                name: "VailaId",
                table: "VailaNumbers");

            migrationBuilder.UpdateData(
                table: "VailaNumbers",
                keyColumn: "VailaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 1, 10, 41, 16, 688, DateTimeKind.Local).AddTicks(4556), new DateTime(2024, 10, 1, 10, 41, 16, 688, DateTimeKind.Local).AddTicks(4556) });

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
    }
}
