using Microsoft.EntityFrameworkCore.Migrations;

namespace GitNode.Persistence.Migrations
{
    public partial class AccountUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "origin_url",
                table: "accounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "origin_url",
                table: "accounts");
        }
    }
}
