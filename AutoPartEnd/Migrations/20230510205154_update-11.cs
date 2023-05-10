using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartEnd.Migrations
{
    public partial class update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserProfile_Name",
                schema: "SchemaEnd",
                table: "UserProfile");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_Email",
                schema: "SchemaEnd",
                table: "UserProfile",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserProfile_Email",
                schema: "SchemaEnd",
                table: "UserProfile");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_Name",
                schema: "SchemaEnd",
                table: "UserProfile",
                column: "Name",
                unique: true);
        }
    }
}
