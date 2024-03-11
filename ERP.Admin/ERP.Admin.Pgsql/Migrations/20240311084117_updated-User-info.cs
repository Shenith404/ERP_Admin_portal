using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Admin.Pgsql.Migrations
{
    /// <inheritdoc />
    public partial class updatedUserinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "UserLoginInfos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Os",
                table: "UserLoginInfos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Browser",
                table: "UserLoginInfos");

            migrationBuilder.DropColumn(
                name: "Os",
                table: "UserLoginInfos");
        }
    }
}
