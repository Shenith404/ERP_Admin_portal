﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Admin.Pgsql.Migrations
{
    /// <inheritdoc />
    public partial class adding_imgeUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Users");
        }
    }
}
