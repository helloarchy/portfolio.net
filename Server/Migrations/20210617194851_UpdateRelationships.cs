using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Server.Migrations
{
    public partial class UpdateRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShortDesc = table.Column<string>(type: "TEXT", nullable: true),
                    BodyMarkdown = table.Column<string>(type: "TEXT", nullable: true),
                    ImageDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsCategories",
                columns: table => new
                {
                    ProjectCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsCategories", x => x.ProjectCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsTechnologies",
                columns: table => new
                {
                    ProjectTechnologyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsTechnologies", x => x.ProjectTechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProjectCategory",
                columns: table => new
                {
                    ProjectCategoriesProjectCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectsProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProjectCategory", x => new { x.ProjectCategoriesProjectCategoryId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectProjectCategory_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProjectCategory_ProjectsCategories_ProjectCategoriesProjectCategoryId",
                        column: x => x.ProjectCategoriesProjectCategoryId,
                        principalTable: "ProjectsCategories",
                        principalColumn: "ProjectCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProjectTechnology",
                columns: table => new
                {
                    ProjectTechnologiesProjectTechnologyId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectsProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProjectTechnology", x => new { x.ProjectTechnologiesProjectTechnologyId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectProjectTechnology_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProjectTechnology_ProjectsTechnologies_ProjectTechnologiesProjectTechnologyId",
                        column: x => x.ProjectTechnologiesProjectTechnologyId,
                        principalTable: "ProjectsTechnologies",
                        principalColumn: "ProjectTechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProjectCategory_ProjectsProjectId",
                table: "ProjectProjectCategory",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProjectTechnology_ProjectsProjectId",
                table: "ProjectProjectTechnology",
                column: "ProjectsProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectProjectCategory");

            migrationBuilder.DropTable(
                name: "ProjectProjectTechnology");

            migrationBuilder.DropTable(
                name: "ProjectsCategories");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectsTechnologies");
        }
    }
}
