
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebApp.Data.Migrations
{
    public partial class EpisodeGenresTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EpisodeId",
                table: "MovieGenres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EpisodeGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EpisodeGenres_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_EpisodeId",
                table: "MovieGenres",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeGenres_EpisodeId",
                table: "EpisodeGenres",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeGenres_GenreId",
                table: "EpisodeGenres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Episodes_EpisodeId",
                table: "MovieGenres",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Episodes_EpisodeId",
                table: "MovieGenres");

            migrationBuilder.DropTable(
                name: "EpisodeGenres");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_EpisodeId",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "MovieGenres");
        }
    }
}
