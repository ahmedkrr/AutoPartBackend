using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartEnd.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                schema: "SchemaEnd",
                table: "CompanyProfile",
                type: "image",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "BackgroundImage",
                schema: "SchemaEnd",
                table: "CompanyProfile",
                type: "image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                schema: "SchemaEnd",
                table: "CompanyProfile");

            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                schema: "SchemaEnd",
                table: "CompanyProfile");
        }
    }
}
