using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PiecesOfArt_App.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoyaltyCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    loyaltyCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_LoyaltyCards_loyaltyCardId",
                        column: x => x.loyaltyCardId,
                        principalTable: "LoyaltyCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublicationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    categoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arts_Categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arts_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Art depicting natural scenery", "Landscapes" },
                    { 2, "Art depicting cityscapes", "Urban" },
                    { 3, "Art depicting the sea", "Seascapes" }
                });

            migrationBuilder.InsertData(
                table: "LoyaltyCards",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Top-tier membership with exclusive benefits", "Gold Membership" },
                    { 2, "Mid-tier membership with many benefits", "Silver Membership" },
                    { 3, "Basic membership with standard benefits", "Bronze Membership" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "loyaltyCardId" },
                values: new object[,]
                {
                    { 1, 28, "alex.johnson@example.com", "Alex Johnson", 1 },
                    { 2, 32, "bethany.green@example.com", "Bethany Green", 2 },
                    { 3, 24, "charlie.brown@example.com", "Charlie Brown", 1 },
                    { 4, 30, "diana.prince@example.com", "Diana Prince", 3 },
                    { 5, 35, "ethan.hunt@example.com", "Ethan Hunt", 2 }
                });

            migrationBuilder.InsertData(
                table: "Arts",
                columns: new[] { "Id", "Description", "PublicationDate", "Title", "categoryID", "userID" },
                values: new object[,]
                {
                    { 1, "A beautiful sunset painting.", new DateOnly(2022, 10, 5), "Sunset Bliss", 1, 1 },
                    { 2, "An awe-inspiring mountain landscape.", new DateOnly(2021, 7, 15), "Mountain Majesty", 2, 2 },
                    { 3, "A vibrant city at night.", new DateOnly(2023, 3, 22), "City Lights", 1, 3 },
                    { 4, "The calming waves of the ocean.", new DateOnly(2020, 6, 8), "Ocean Waves", 3, 4 },
                    { 5, "A serene path through the forest.", new DateOnly(2019, 11, 2), "Forest Path", 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arts_categoryID",
                table: "Arts",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Arts_Title",
                table: "Arts",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Arts_userID",
                table: "Arts",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_loyaltyCardId",
                table: "Users",
                column: "loyaltyCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LoyaltyCards");
        }
    }
}
