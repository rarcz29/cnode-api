using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CNode.Persistence.Migrations
{
    public partial class GitToolsTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "git_tools",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_git_tools", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "git_accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    git_user_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    token = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    git_tool_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_git_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_git_accounts_git_tools_git_tool_id",
                        column: x => x.git_tool_id,
                        principalTable: "git_tools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_git_accounts_git_tool_id",
                table: "git_accounts",
                column: "git_tool_id");

            migrationBuilder.CreateIndex(
                name: "ix_git_accounts_git_user_id_git_tool_id",
                table: "git_accounts",
                columns: new[] { "git_user_id", "git_tool_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_git_tools_name",
                table: "git_tools",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "git_accounts");

            migrationBuilder.DropTable(
                name: "git_tools");
        }
    }
}
