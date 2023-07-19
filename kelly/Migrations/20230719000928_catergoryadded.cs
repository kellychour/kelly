using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kelly.Migrations
{
    public partial class catergoryadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Catergory",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Catergory",
                table: "Product");
        }
    }
}
