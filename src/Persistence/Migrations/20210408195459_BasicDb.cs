using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GitNode.Persistence.Migrations
{
    public partial class BasicDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "git_accounts");

            migrationBuilder.DropTable(
                name: "git_tools");

            migrationBuilder.CreateTable(
                name: "platforms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_platforms", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(65)", maxLength: 65, nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "technologies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    technology_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_technologies", x => x.id);
                    table.ForeignKey(
                        name: "fk_technologies_technology_types_technology_type_id",
                        column: x => x.technology_type_id,
                        principalTable: "technology_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    origin_id = table.Column<int>(type: "integer", nullable: false),
                    username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    token = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    platform_id = table.Column<int>(type: "integer", nullable: false),
                    account_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_accounts_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_accounts_platforms_platform_id",
                        column: x => x.platform_id,
                        principalTable: "platforms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_accounts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "repositories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    @private = table.Column<bool>(name: "private", type: "boolean", nullable: false),
                    share = table.Column<bool>(type: "boolean", nullable: false),
                    origin_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    origin_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    origin_url = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    account_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_repositories", x => x.id);
                    table.ForeignKey(
                        name: "fk_repositories_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "repository_technology",
                columns: table => new
                {
                    repositories_id = table.Column<int>(type: "integer", nullable: false),
                    technologies_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_repository_technology", x => new { x.repositories_id, x.technologies_id });
                    table.ForeignKey(
                        name: "fk_repository_technology_repositories_repositories_id",
                        column: x => x.repositories_id,
                        principalTable: "repositories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_repository_technology_technologies_technologies_id",
                        column: x => x.technologies_id,
                        principalTable: "technologies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_accounts_account_id",
                table: "accounts",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_accounts_origin_id_platform_id",
                table: "accounts",
                columns: new[] { "origin_id", "platform_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_accounts_platform_id",
                table: "accounts",
                column: "platform_id");

            migrationBuilder.CreateIndex(
                name: "ix_accounts_token_platform_id",
                table: "accounts",
                columns: new[] { "token", "platform_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_accounts_user_id",
                table: "accounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_accounts_username_platform_id",
                table: "accounts",
                columns: new[] { "username", "platform_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_platforms_name",
                table: "platforms",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_repositories_account_id",
                table: "repositories",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_repositories_name_account_id",
                table: "repositories",
                columns: new[] { "name", "account_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_repository_technology_technologies_id",
                table: "repository_technology",
                column: "technologies_id");

            migrationBuilder.CreateIndex(
                name: "ix_technologies_name",
                table: "technologies",
                column: "name",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "repository_technology");

            migrationBuilder.DropTable(
                name: "repositories");

            migrationBuilder.DropTable(
                name: "technologies");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "technology_types");

            migrationBuilder.DropTable(
                name: "platforms");

            migrationBuilder.DropTable(
                name: "users");

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
                    git_tool_id = table.Column<int>(type: "integer", nullable: false),
                    git_user_id = table.Column<int>(type: "integer", nullable: false),
                    token = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
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
    }
}
