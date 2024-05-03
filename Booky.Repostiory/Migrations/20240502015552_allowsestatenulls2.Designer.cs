﻿// <auto-generated />
using System;
using Booky.Repostiory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booky.Repostiory.Migrations
{
    [DbContext(typeof(OnionBookyDbContext))]
    [Migration("20240502015552_allowsestatenulls2")]
    partial class allowsestatenulls2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Booky.Core.Models.Estate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstateTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("sqft")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstateTypeId");

                    b.ToTable("Estates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Luxurious villa with stunning views.",
                            EstateTypeId = 1,
                            ImageURL = "",
                            Name = "Villa",
                            Rate = 80,
                            sqft = 150
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Classic family home with a spacious backyard.",
                            EstateTypeId = 1,
                            ImageURL = "",
                            Name = "House",
                            Rate = 90,
                            sqft = 90
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Modern apartment in the heart of the city.",
                            EstateTypeId = 2,
                            ImageURL = "",
                            Name = "Apartment",
                            Rate = 75,
                            sqft = 120
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Stylish condo with amenities and city views.",
                            EstateTypeId = 2,
                            ImageURL = "",
                            Name = "Condo",
                            Rate = 85,
                            sqft = 100
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Charming duplex with a cozy atmosphere.",
                            EstateTypeId = 1,
                            ImageURL = "",
                            Name = "Duplex",
                            Rate = 95,
                            sqft = 110
                        },
                        new
                        {
                            Id = 6,
                            CreateDate = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Elegant townhouse with a private garden.",
                            EstateTypeId = 1,
                            ImageURL = "",
                            Name = "Townhouse",
                            Rate = 78,
                            sqft = 130
                        },
                        new
                        {
                            Id = 7,
                            CreateDate = new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Quaint cottage in a peaceful countryside setting.",
                            EstateTypeId = 1,
                            ImageURL = "",
                            Name = "Cottage",
                            Rate = 88,
                            sqft = 95
                        },
                        new
                        {
                            Id = 8,
                            CreateDate = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Grand mansion with opulent interiors and vast grounds.",
                            EstateTypeId = 1,
                            ImageURL = "",
                            Name = "Mansion",
                            Rate = 105,
                            sqft = 180
                        },
                        new
                        {
                            Id = 9,
                            CreateDate = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Compact studio with modern design and city views.",
                            EstateTypeId = 2,
                            ImageURL = "",
                            Name = "Studio",
                            Rate = 70,
                            sqft = 80
                        },
                        new
                        {
                            Id = 10,
                            CreateDate = new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Spacious loft with industrial-chic aesthetics.",
                            EstateTypeId = 2,
                            ImageURL = "",
                            Name = "Loft",
                            Rate = 92,
                            sqft = 160
                        });
                });

            modelBuilder.Entity("Booky.Core.Models.EstateType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EstateType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Details = "Details specific to residential properties",
                            TypeName = "Residential"
                        },
                        new
                        {
                            Id = 2,
                            Details = "Details specific to commercial properties",
                            TypeName = "Commercial"
                        },
                        new
                        {
                            Id = 3,
                            Details = "Details specific to industrial properties",
                            TypeName = "Industrial"
                        });
                });

            modelBuilder.Entity("Booky.Core.Models.Estate", b =>
                {
                    b.HasOne("Booky.Core.Models.EstateType", "EstateType")
                        .WithMany()
                        .HasForeignKey("EstateTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstateType");
                });
#pragma warning restore 612, 618
        }
    }
}
