using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VailaPlace.Migrations
{
    /// <inheritdoc />
    public partial class NewRecored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vailas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    sqft = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vailas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vailas",
                columns: new[] { "Id", "Amenity", "Area", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "UpdatedDate", "sqft" },
                values: new object[,]
                {
                    { 1, "", 23.0, new DateTime(2024, 10, 1, 8, 55, 47, 676, DateTimeKind.Local).AddTicks(1756), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila3.jpg", "Royal Vaila", 4, 200.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 550 },
                    { 2, "", 23.0, new DateTime(2024, 10, 1, 8, 55, 47, 676, DateTimeKind.Local).AddTicks(1767), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila1.jpg", "Premium Pool Vaila", 4, 300.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 550 },
                    { 3, "", 241.0, new DateTime(2024, 10, 1, 8, 55, 47, 676, DateTimeKind.Local).AddTicks(1769), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila4.jpg", "Luxury Pool Vaila", 4, 400.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 750 },
                    { 4, "", 47.0, new DateTime(2024, 10, 1, 8, 55, 47, 676, DateTimeKind.Local).AddTicks(1771), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila5.jpg", "Diamond Vaila", 4, 550.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 900 },
                    { 5, "", 243.0, new DateTime(2024, 10, 1, 8, 55, 47, 676, DateTimeKind.Local).AddTicks(1772), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila2.jpg", "Diamond Pool Vaila", 4, 600.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vailas");
        }
    }
}
