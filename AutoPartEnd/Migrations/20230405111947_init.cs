using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartEnd.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SchemaEnd");

            migrationBuilder.CreateTable(
                name: "CarModel",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProfile",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CompanyPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarType",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 500, nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarType_CarModel_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "SchemaEnd",
                        principalTable: "CarModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsCompanyOwner = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsDeactive = table.Column<bool>(type: "bit", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_CompanyProfile_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalSchema: "SchemaEnd",
                        principalTable: "CompanyProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufactureYear",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufactureYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufactureYear_CarType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "SchemaEnd",
                        principalTable: "CarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarType_ModelId",
                schema: "SchemaEnd",
                table: "CarType",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufactureYear_TypeId",
                schema: "SchemaEnd",
                table: "ManufactureYear",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CompanyProfileId",
                schema: "SchemaEnd",
                table: "UserProfile",
                column: "CompanyProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufactureYear",
                schema: "SchemaEnd");

            migrationBuilder.DropTable(
                name: "UserProfile",
                schema: "SchemaEnd");

            migrationBuilder.DropTable(
                name: "CarType",
                schema: "SchemaEnd");

            migrationBuilder.DropTable(
                name: "CompanyProfile",
                schema: "SchemaEnd");

            migrationBuilder.DropTable(
                name: "CarModel",
                schema: "SchemaEnd");
        }
    }
}
