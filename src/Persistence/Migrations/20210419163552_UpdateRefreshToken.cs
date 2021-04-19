using Microsoft.EntityFrameworkCore.Migrations;

namespace CNode.Persistence.Migrations
{
    public partial class UpdateRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_used",
                table: "refresh_tokens",
                newName: "used");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "used",
                table: "refresh_tokens",
                newName: "is_used");
        }
    }
}
