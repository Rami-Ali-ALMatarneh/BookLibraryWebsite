using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibraryWebsite.Migrations
{
    /// <inheritdoc />
    public partial class setFK_Schedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_AppUserId",
                table: "Schedule",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_AspNetUsers_AppUserId",
                table: "Schedule",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_AspNetUsers_AppUserId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_AppUserId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Schedule");
        }
    }
}
