using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibraryWebsite.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 1",
                column: "photoPath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 2",
                column: "photoPath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 3",
                column: "photoPath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 4",
                column: "photoPath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 5",
                column: "photoPath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 6",
                column: "photoPath",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 1",
                column: "photoPath",
                value: "images.png");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 2",
                column: "photoPath",
                value: "images.png");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 3",
                column: "photoPath",
                value: "images.png");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 4",
                column: "photoPath",
                value: "images.png");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 5",
                column: "photoPath",
                value: "images.png");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Title",
                keyValue: "Book 6",
                column: "photoPath",
                value: "images.png");
        }
    }
}
