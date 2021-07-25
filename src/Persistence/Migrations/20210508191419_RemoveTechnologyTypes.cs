using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GitNode.Persistence.Migrations
{
    public partial class RemoveTechnologyTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_technologies_technology_types_technology_type_id",
                table: "technologies");

            migrationBuilder.DropTable(
                name: "technology_types");

            migrationBuilder.DropIndex(
                name: "ix_technologies_technology_type_id",
                table: "technologies");

            migrationBuilder.DropColumn(
                name: "technology_type_id",
                table: "technologies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "technology_type_id",
                table: "technologies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "technology_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    name_plural = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_technology_types", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_technologies_technology_type_id",
                table: "technologies",
                column: "technology_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_technology_types_name",
                table: "technology_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_technology_types_name_plural",
                table: "technology_types",
                column: "name_plural",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_technologies_technology_types_technology_type_id",
                table: "technologies",
                column: "technology_type_id",
                principalTable: "technology_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
