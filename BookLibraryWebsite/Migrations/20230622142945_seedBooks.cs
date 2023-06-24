using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibraryWebsite.Migrations
{
    /// <inheritdoc />
    public partial class seedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Title", "Created", "Description", "KindOfBooks", "Price", "author", "discount", "filePath", "photoPath" },
                values: new object[,]
                {
                    { "Book 1", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0f, "Rami Ali", 0f, "", "images.png" },
                    { "Book 2", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0f, "Rami Ali", 0f, "", "images.png" },
                    { "Book 3", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0f, "Rami Ali", 0f, "", "images.png" },
                    { "Book 4", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0f, "Rami Ali", 0f, "", "images.png" },
                    { "Book 5", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0f, "Rami Ali", 0f, "", "images.png" },
                    { "Book 6", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0f, "Rami Ali", 0f, "", "images.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 1");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 2");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 3");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 4");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 5");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 6");
        }
    }
}
