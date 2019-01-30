using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoMallWebService.Data.Migrations
{
    public partial class description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PromotionDescription",
                table: "Promotions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PromotionExtra",
                table: "Promotions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionDescription",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "PromotionExtra",
                table: "Promotions");
        }
    }
}
