using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Server.Migrations
{
    public partial class AddProjectPageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PageName",
                table: "Projects",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageName",
                table: "Projects");
        }
    }
}
