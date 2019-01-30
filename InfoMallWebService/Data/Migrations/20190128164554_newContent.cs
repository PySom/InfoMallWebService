using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoMallWebService.Data.Migrations
{
    public partial class newContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryInformation",
                table: "CategoriesForInformation",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryInformation",
                table: "CategoriesForInformation");
        }
    }
}
