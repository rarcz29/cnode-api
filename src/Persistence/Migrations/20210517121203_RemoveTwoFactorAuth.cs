using Microsoft.EntityFrameworkCore.Migrations;

namespace CNode.Persistence.Migrations
{
    public partial class RemoveTwoFactorAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "two_factor_enabled",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "two_factor_enabled",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
