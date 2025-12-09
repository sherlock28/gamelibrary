using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameLibrary.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedAt", "Description", "Price", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), "An epic adventure in the kingdom of Hyrule", 69.99m, "The Legend of Zelda: Tears of the Kingdom", new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), "A challenging action role-playing game", 59.99m, "Elden Ring", new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), "A mind-flaying adventure of epic proportions", 59.99m, "Baldur's Gate 3", new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), "An open-world action role-playing game set in the future", 49.99m, "Cyberpunk 2077", new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Bethesda's ambitious space exploration RPG", 69.99m, "Starfield", new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
