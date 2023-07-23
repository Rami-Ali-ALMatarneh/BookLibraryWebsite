using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibraryWebsite.Migrations
{
    /// <inheritdoc />
    public partial class oldPricebook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "oldPrice",
                table: "Book",
                type: "real",
                nullable: true,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oldPrice",
                table: "Book");
        }
    }
}
