using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebApp.Data.Migrations
{
    public partial class SomeMistakesCorrectedInEpisodeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Episodes_EpisodeId",
                table: "MovieGenres");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_EpisodeId",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "MovieGenres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EpisodeId",
                table: "MovieGenres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_EpisodeId",
                table: "MovieGenres",
                column: "EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Episodes_EpisodeId",
                table: "MovieGenres",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id");
        }
    }
}
