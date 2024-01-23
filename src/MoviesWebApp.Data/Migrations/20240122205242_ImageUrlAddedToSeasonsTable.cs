using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebApp.Data.Migrations
{
    public partial class ImageUrlAddedToSeasonsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Seasons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Seasons");
        }
    }
}
