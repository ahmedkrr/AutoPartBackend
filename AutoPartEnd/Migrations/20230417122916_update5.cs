using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartEnd.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                schema: "SchemaEnd",
                table: "Category",
                type: "image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                schema: "SchemaEnd",
                table: "Category");
        }
    }
}
