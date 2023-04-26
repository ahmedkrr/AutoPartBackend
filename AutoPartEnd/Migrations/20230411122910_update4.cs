using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartEnd.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                schema: "SchemaEnd",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                schema: "SchemaEnd",
                table: "Item",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                schema: "SchemaEnd",
                table: "Item",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                schema: "SchemaEnd",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "SchemaEnd",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "SchemaEnd",
                table: "Item");
        }
    }
}
