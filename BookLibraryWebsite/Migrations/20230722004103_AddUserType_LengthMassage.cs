using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibraryWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddUserType_LengthMassage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descrption",
                table: "ContactUs",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "userType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userType",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Descrption",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);
        }
    }
}
