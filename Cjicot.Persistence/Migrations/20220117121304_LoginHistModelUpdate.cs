using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cjicot.Persistence.Migrations
{
    public partial class LoginHistModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "LoginHistories",
                newName: "IsSuccessful");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSuccessful",
                table: "LoginHistories",
                newName: "Status");
        }
    }
}
