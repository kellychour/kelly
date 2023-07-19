using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kelly.Migrations
{
    public partial class FixedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Catergory",
                table: "Product",
                newName: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Product",
                newName: "Catergory");
        }
    }
}
