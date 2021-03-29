using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateDatabaseV12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Colors",
                newName: "ColorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brands",
                newName: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Colors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Brands",
                newName: "Id");
        }
    }
}
