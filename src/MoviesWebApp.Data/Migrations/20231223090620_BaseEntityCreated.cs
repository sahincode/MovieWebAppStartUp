using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebApp.Data.Migrations
{
    public partial class BaseEntityCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Movies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LogoPageInfo",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "LogoPageInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LogoPageInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "LogoPageInfo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "LogoPageInfo");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LogoPageInfo");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "LogoPageInfo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LogoPageInfo",
                newName: "ID");
        }
    }
}
