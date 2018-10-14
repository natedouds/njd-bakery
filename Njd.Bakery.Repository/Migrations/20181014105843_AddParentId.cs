using Microsoft.EntityFrameworkCore.Migrations;

namespace Njd.Bakery.Repository.Migrations
{
    public partial class AddParentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDefaultProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ParentProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                newName: "IX_Products_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ParentId",
                table: "Products",
                column: "ParentId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ParentId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                newName: "IX_Products_ProductId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultProduct",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentProductId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
