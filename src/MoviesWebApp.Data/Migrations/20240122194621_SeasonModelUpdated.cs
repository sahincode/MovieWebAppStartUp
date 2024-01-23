using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebApp.Data.Migrations
{
    public partial class SeasonModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeasonNumber",
                table: "Seasons");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Seasons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Seasons");

            migrationBuilder.AddColumn<int>(
                name: "SeasonNumber",
                table: "Seasons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
