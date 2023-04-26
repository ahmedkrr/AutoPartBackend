using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartEnd.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CarModel_Name",
                schema: "SchemaEnd",
                table: "CarModel",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarModel_Name",
                schema: "SchemaEnd",
                table: "CarModel");
        }
    }
}
