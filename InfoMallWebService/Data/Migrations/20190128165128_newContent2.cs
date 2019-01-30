using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoMallWebService.Data.Migrations
{
    public partial class newContent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryInformation",
                table: "CategoriesForTab",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryInformation",
                table: "CategoriesForInformation",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryInformation",
                table: "CategoriesForTab",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryInformation",
                table: "CategoriesForInformation",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
