﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebApp.Data.Migrations

{
    public partial class tochangeStringValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "infoAboutApp",
                table: "LogoPageInfo",
                type: "nvarchar(max)",
                maxLength: 12000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LogoPageInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "infoAboutApp",
                table: "LogoPageInfo",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 12000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LogoPageInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
