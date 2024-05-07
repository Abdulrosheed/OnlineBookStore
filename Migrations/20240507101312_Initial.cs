using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineBookstore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Deshaun Murazik", 46.90m, "Incredible Plastic Tuna" },
                    { 2, "Cedrick Kuphal", 58.08m, "Refined Fresh Bacon" },
                    { 3, "Marilou Hartmann", 57.46m, "Awesome Steel Bacon" },
                    { 4, "Myles Berge", 46.43m, "Unbranded Cotton Mouse" },
                    { 5, "Cleveland Abernathy", 50.29m, "Practical Frozen Towels" },
                    { 6, "Beau Dach", 28.87m, "Sleek Wooden Shirt" },
                    { 7, "Ayden Jast", 72.78m, "Small Metal Cheese" },
                    { 8, "Jessyca Mosciski", 88.75m, "Incredible Granite Sausages" },
                    { 9, "Hattie Streich", 11.43m, "Refined Plastic Pants" },
                    { 10, "Eugenia Oberbrunner", 36.51m, "Generic Wooden Shirt" },
                    { 11, "Linwood Effertz", 92.41m, "Handmade Rubber Towels" },
                    { 12, "Kaylin Hansen", 69.92m, "Licensed Fresh Towels" },
                    { 13, "Burdette Williamson", 75.41m, "Practical Plastic Chair" },
                    { 14, "Esperanza Altenwerth", 25.42m, "Awesome Concrete Shirt" },
                    { 15, "Jaida Hartmann", 44.72m, "Incredible Concrete Chair" },
                    { 16, "Reed Dickens", 42.63m, "Tasty Granite Tuna" },
                    { 17, "Ciara Ratke", 96.32m, "Sleek Fresh Cheese" },
                    { 18, "Chanel Dietrich", 18.61m, "Rustic Steel Keyboard" },
                    { 19, "Marilyne Monahan", 35.35m, "Small Frozen Car" },
                    { 20, "Sonny Reynolds", 81.71m, "Sleek Steel Soap" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Amount", "BookId", "SaleDate" },
                values: new object[,]
                {
                    { 1, 25.15m, 12, new DateTime(2024, 4, 19, 21, 15, 50, 535, DateTimeKind.Utc).AddTicks(8654) },
                    { 2, 39.81m, 4, new DateTime(2023, 8, 22, 8, 11, 53, 182, DateTimeKind.Utc).AddTicks(3720) },
                    { 3, 90.05m, 12, new DateTime(2023, 12, 19, 6, 52, 54, 583, DateTimeKind.Utc).AddTicks(3147) },
                    { 4, 39.52m, 20, new DateTime(2024, 3, 1, 10, 10, 0, 600, DateTimeKind.Utc).AddTicks(6904) },
                    { 5, 45.98m, 10, new DateTime(2024, 3, 26, 16, 23, 56, 276, DateTimeKind.Utc).AddTicks(4058) },
                    { 6, 76.89m, 3, new DateTime(2024, 3, 27, 3, 29, 22, 46, DateTimeKind.Utc).AddTicks(8473) },
                    { 7, 71.01m, 9, new DateTime(2024, 1, 23, 1, 17, 20, 508, DateTimeKind.Utc).AddTicks(2690) },
                    { 8, 65.35m, 18, new DateTime(2024, 3, 13, 16, 12, 22, 276, DateTimeKind.Utc).AddTicks(3084) },
                    { 9, 24.76m, 20, new DateTime(2023, 7, 28, 7, 49, 13, 428, DateTimeKind.Utc).AddTicks(6594) },
                    { 10, 25.09m, 19, new DateTime(2023, 7, 2, 14, 24, 33, 654, DateTimeKind.Utc).AddTicks(8912) },
                    { 11, 25.12m, 20, new DateTime(2024, 2, 25, 2, 49, 46, 487, DateTimeKind.Utc).AddTicks(7931) },
                    { 12, 73.80m, 20, new DateTime(2024, 5, 2, 0, 52, 43, 223, DateTimeKind.Utc).AddTicks(3727) },
                    { 13, 24.55m, 10, new DateTime(2024, 3, 6, 16, 24, 45, 731, DateTimeKind.Utc).AddTicks(825) },
                    { 14, 25.48m, 7, new DateTime(2024, 1, 2, 5, 44, 52, 421, DateTimeKind.Utc).AddTicks(5119) },
                    { 15, 44.18m, 13, new DateTime(2023, 8, 22, 8, 45, 17, 191, DateTimeKind.Utc).AddTicks(6742) },
                    { 16, 46.80m, 14, new DateTime(2023, 8, 29, 6, 24, 49, 754, DateTimeKind.Utc).AddTicks(7133) },
                    { 17, 28.09m, 3, new DateTime(2023, 8, 17, 13, 38, 8, 66, DateTimeKind.Utc).AddTicks(1948) },
                    { 18, 38.66m, 9, new DateTime(2023, 7, 2, 10, 24, 0, 641, DateTimeKind.Utc).AddTicks(6425) },
                    { 19, 85.91m, 17, new DateTime(2023, 11, 27, 6, 48, 29, 613, DateTimeKind.Utc).AddTicks(538) },
                    { 20, 39.10m, 16, new DateTime(2024, 4, 27, 18, 33, 14, 739, DateTimeKind.Utc).AddTicks(4718) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BookId",
                table: "Sales",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
