using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Admin.Pgsql.Migrations
{
    /// <inheritdoc />
    public partial class infor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserLoginInfos",
                newName: "UserEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "UserLoginInfos",
                newName: "UserId");
        }
    }
}
