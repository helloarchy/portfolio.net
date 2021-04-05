using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Portfolio.Shared;

namespace Portfolio.Server.Migrations
{
    public partial class UpdateProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BodyMarkdown",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<Category>>(
                name: "Categories",
                table: "Projects",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageDescription",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<Technology>>(
                name: "Technologies",
                table: "Projects",
                type: "integer[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyMarkdown",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ImageDescription",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Technologies",
                table: "Projects");
        }
    }
}
