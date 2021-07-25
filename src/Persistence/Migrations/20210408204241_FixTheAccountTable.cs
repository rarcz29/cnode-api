using Microsoft.EntityFrameworkCore.Migrations;

namespace GitNode.Persistence.Migrations
{
    public partial class FixTheAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_accounts_accounts_account_id",
                table: "accounts");

            migrationBuilder.DropIndex(
                name: "ix_accounts_account_id",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "account_id",
                table: "accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "account_id",
                table: "accounts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_accounts_account_id",
                table: "accounts",
                column: "account_id");

            migrationBuilder.AddForeignKey(
                name: "fk_accounts_accounts_account_id",
                table: "accounts",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
