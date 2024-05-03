using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Booky.Repostiory.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstateType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    sqft = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstateTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estates_EstateType_EstateTypeId",
                        column: x => x.EstateTypeId,
                        principalTable: "EstateType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstateType",
                columns: new[] { "Id", "Details", "TypeName" },
                values: new object[,]
                {
                    { 1, "Details specific to residential properties", "Residential" },
                    { 2, "Details specific to commercial properties", "Commercial" },
                    { 3, "Details specific to industrial properties", "Industrial" }
                });

            migrationBuilder.InsertData(
                table: "Estates",
                columns: new[] { "Id", "CreateDate", "Details", "EstateTypeId", "ImageURL", "Name", "Rate", "sqft" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luxurious villa with stunning views.", 1, "", "Villa", 80, 150 },
                    { 2, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic family home with a spacious backyard.", 1, "", "House", 90, 90 },
                    { 3, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modern apartment in the heart of the city.", 2, "", "Apartment", 75, 120 },
                    { 4, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stylish condo with amenities and city views.", 2, "", "Condo", 85, 100 },
                    { 5, new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charming duplex with a cozy atmosphere.", 1, "", "Duplex", 95, 110 },
                    { 6, new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elegant townhouse with a private garden.", 1, "", "Townhouse", 78, 130 },
                    { 7, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quaint cottage in a peaceful countryside setting.", 1, "", "Cottage", 88, 95 },
                    { 8, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand mansion with opulent interiors and vast grounds.", 1, "", "Mansion", 105, 180 },
                    { 9, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compact studio with modern design and city views.", 2, "", "Studio", 70, 80 },
                    { 10, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spacious loft with industrial-chic aesthetics.", 2, "", "Loft", 92, 160 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estates_EstateTypeId",
                table: "Estates",
                column: "EstateTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estates");

            migrationBuilder.DropTable(
                name: "EstateType");
        }
    }
}
