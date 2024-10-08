﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VailaPlace.Data;

#nullable disable

namespace VailaPlace.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VailaPlace.Models.LocalUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("localUsers");
                });

            modelBuilder.Entity("VailaPlace.Models.Vaila", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("sqft")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vailas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            Area = 23.0,
                            CreatedDate = new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(6930),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila3.jpg",
                            Name = "Royal Vaila",
                            Occupancy = 4,
                            Rate = 200.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            sqft = 550
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            Area = 23.0,
                            CreatedDate = new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(6944),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila1.jpg",
                            Name = "Premium Pool Vaila",
                            Occupancy = 4,
                            Rate = 300.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            sqft = 550
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "",
                            Area = 241.0,
                            CreatedDate = new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(6946),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila4.jpg",
                            Name = "Luxury Pool Vaila",
                            Occupancy = 4,
                            Rate = 400.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            sqft = 750
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "",
                            Area = 47.0,
                            CreatedDate = new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(6947),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila5.jpg",
                            Name = "Diamond Vaila",
                            Occupancy = 4,
                            Rate = 550.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            sqft = 900
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "",
                            Area = 243.0,
                            CreatedDate = new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(6949),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/blueVailaimages/Vaila2.jpg",
                            Name = "Diamond Pool Vaila",
                            Occupancy = 4,
                            Rate = 600.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            sqft = 1100
                        });
                });

            modelBuilder.Entity("VailaPlace.Models.VailaNumber", b =>
                {
                    b.Property<int>("VailaNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VailaId")
                        .HasColumnType("int");

                    b.HasKey("VailaNo");

                    b.HasIndex("VailaId");

                    b.ToTable("VailaNumbers");

                    b.HasData(
                        new
                        {
                            VailaNo = 1,
                            CreatedDate = new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(7050),
                            SpecialDetails = "Ther is no Updated date",
                            UpdatedDate = new DateTime(2024, 10, 2, 14, 35, 30, 647, DateTimeKind.Local).AddTicks(7049),
                            VailaId = 0
                        });
                });

            modelBuilder.Entity("VailaPlace.Models.VailaNumber", b =>
                {
                    b.HasOne("VailaPlace.Models.Vaila", "Vaila")
                        .WithMany()
                        .HasForeignKey("VailaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaila");
                });
#pragma warning restore 612, 618
        }
    }
}
