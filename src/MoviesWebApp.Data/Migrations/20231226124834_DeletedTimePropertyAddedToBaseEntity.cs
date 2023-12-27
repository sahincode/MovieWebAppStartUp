using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebApp.Data.Migrations
{
    public partial class DeletedTimePropertyAddedToBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "LogoPageInfo");

            migrationBuilder.RenameColumn(
                name: "infoAboutApp",
                table: "LogoPageInfo",
                newName: "InfoAboutApp");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "InfoAboutApp",
                table: "LogoPageInfo",
                type: "nvarchar(max)",
                maxLength: 12000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 12000,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "LogoPageInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "LogoPageInfo");

            migrationBuilder.RenameColumn(
                name: "InfoAboutApp",
                table: "LogoPageInfo",
                newName: "infoAboutApp");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "infoAboutApp",
                table: "LogoPageInfo",
                type: "nvarchar(max)",
                maxLength: 12000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 12000);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "LogoPageInfo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
