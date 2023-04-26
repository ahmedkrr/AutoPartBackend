using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartEnd.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "SchemaEnd",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "SchemaEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    CompanyProfileId = table.Column<int>(type: "int", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: true),
                    CarTypeId = table.Column<int>(type: "int", nullable: true),
                    ManufactureYearId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_CarModel_CarModelId",
                        column: x => x.CarModelId,
                        principalSchema: "SchemaEnd",
                        principalTable: "CarModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_CarType_CarTypeId",
                        column: x => x.CarTypeId,
                        principalSchema: "SchemaEnd",
                        principalTable: "CarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_CompanyProfile_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalSchema: "SchemaEnd",
                        principalTable: "CompanyProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_ManufactureYear_ManufactureYearId",
                        column: x => x.ManufactureYearId,
                        principalSchema: "SchemaEnd",
                        principalTable: "ManufactureYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalSchema: "SchemaEnd",
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalSchema: "SchemaEnd",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryName",
                schema: "SchemaEnd",
                table: "Category",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_CarModelId",
                schema: "SchemaEnd",
                table: "Item",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CarTypeId",
                schema: "SchemaEnd",
                table: "Item",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CompanyProfileId",
                schema: "SchemaEnd",
                table: "Item",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ManufactureYearId",
                schema: "SchemaEnd",
                table: "Item",
                column: "ManufactureYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SubCategoryId",
                schema: "SchemaEnd",
                table: "Item",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserProfileId",
                schema: "SchemaEnd",
                table: "Item",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                schema: "SchemaEnd",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_SubCategoryName",
                schema: "SchemaEnd",
                table: "SubCategory",
                column: "SubCategoryName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item",
                schema: "SchemaEnd");

            migrationBuilder.DropTable(
                name: "SubCategory",
                schema: "SchemaEnd");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "SchemaEnd");
        }
    }
}
