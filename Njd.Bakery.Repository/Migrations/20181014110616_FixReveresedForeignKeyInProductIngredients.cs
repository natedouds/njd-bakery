using Microsoft.EntityFrameworkCore.Migrations;

namespace Njd.Bakery.Repository.Migrations
{
    public partial class FixReveresedForeignKeyInProductIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredients_Products_IngredientId",
                table: "ProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredients_Ingredients_ProductId",
                table: "ProductIngredients");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredients_Ingredients_IngredientId",
                table: "ProductIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredients_Products_ProductId",
                table: "ProductIngredients",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredients_Ingredients_IngredientId",
                table: "ProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredients_Products_ProductId",
                table: "ProductIngredients");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredients_Products_IngredientId",
                table: "ProductIngredients",
                column: "IngredientId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredients_Ingredients_ProductId",
                table: "ProductIngredients",
                column: "ProductId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
