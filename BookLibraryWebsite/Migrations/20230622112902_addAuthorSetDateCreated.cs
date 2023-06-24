﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibraryWebsite.Migrations
{
    /// <inheritdoc />
    public partial class addAuthorSetDateCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Book",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "author",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
