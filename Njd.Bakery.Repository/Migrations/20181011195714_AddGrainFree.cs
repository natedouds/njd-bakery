using Microsoft.EntityFrameworkCore.Migrations;

namespace Njd.Bakery.Repository.Migrations
{
    public partial class AddGrainFree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanBeGrainFree",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GrainFree",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBeGrainFree",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GrainFree",
                table: "Products");
        }
    }
}
