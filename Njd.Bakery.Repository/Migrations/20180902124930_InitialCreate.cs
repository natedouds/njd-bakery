using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Njd.Bakery.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductClassifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentProductId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    IsDefaultProduct = table.Column<bool>(nullable: false),
                    GlutenFree = table.Column<bool>(nullable: false),
                    CanBeGlutenFree = table.Column<bool>(nullable: false),
                    DairyFree = table.Column<bool>(nullable: false),
                    CanBeDairyFree = table.Column<bool>(nullable: false),
                    EggFree = table.Column<bool>(nullable: false),
                    CanBeEggFree = table.Column<bool>(nullable: false),
                    RefinedSugarFree = table.Column<bool>(nullable: false),
                    CanBeRefinedSugarFree = table.Column<bool>(nullable: false),
                    NutFree = table.Column<bool>(nullable: false),
                    CanBeNutFree = table.Column<bool>(nullable: false),
                    Vegan = table.Column<bool>(nullable: false),
                    CanBeVegan = table.Column<bool>(nullable: false),
                    DefaultNumberOfServings = table.Column<int>(nullable: false),
                    TotalBatchCalories = table.Column<decimal>(type: "decimal(9, 4)", nullable: false),
                    TotalBatchFat = table.Column<decimal>(type: "decimal(9, 4)", nullable: false),
                    TotalBatchCarbs = table.Column<decimal>(type: "decimal(9, 4)", nullable: false),
                    TotalBatchFiber = table.Column<decimal>(type: "decimal(9, 4)", nullable: false),
                    TotalBatchSugar = table.Column<decimal>(type: "decimal(9, 4)", nullable: false),
                    TotalBatchProtein = table.Column<decimal>(type: "decimal(9, 4)", nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    ClassificationId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductClassifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "ProductClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductIngredients",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductIngredients", x => new { x.ProductId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_ProductIngredients_Products_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductIngredients_Ingredients_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Snack Bars" },
                    { 2, "Cakes" },
                    { 3, "Breads" },
                    { 4, "Cookies" },
                    { 5, "Dessert Bars" },
                    { 6, "Misc" },
                    { 7, "Muffins" }
                });

            migrationBuilder.InsertData(
                table: "ProductClassifications",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Simple Dessert" },
                    { 2, "Involved Dessert" },
                    { 3, "Snack" },
                    { 4, "Bread" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductIngredients_IngredientId",
                table: "ProductIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ClassificationId",
                table: "Products",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductIngredients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductClassifications");
        }
    }
}
