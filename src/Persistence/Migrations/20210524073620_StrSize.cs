using Microsoft.EntityFrameworkCore.Migrations;

namespace GitNode.Persistence.Migrations
{
    public partial class StrSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "token",
                table: "accounts",
                type: "character varying(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "origin_id",
                table: "accounts",
                type: "character varying(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "token",
                table: "accounts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "origin_id",
                table: "accounts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(400)",
                oldMaxLength: 400);
        }
    }
}
