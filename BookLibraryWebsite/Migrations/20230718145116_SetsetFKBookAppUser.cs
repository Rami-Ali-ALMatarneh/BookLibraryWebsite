using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibraryWebsite.Migrations
{
    /// <inheritdoc />
    public partial class SetsetFKBookAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AppUserId",
                table: "Book",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_AspNetUsers_AppUserId",
                table: "Book",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_AspNetUsers_AppUserId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AppUserId",
                table: "Book");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Book");
        }
    }
}
