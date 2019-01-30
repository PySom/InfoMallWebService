using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoMallWebService.Data.Migrations
{
    public partial class newss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentImage_ContentsForMall_ContentForMallContentId",
                table: "ContentImage");

            migrationBuilder.DropIndex(
                name: "IX_ContentImage_ContentForMallContentId",
                table: "ContentImage");

            migrationBuilder.DropColumn(
                name: "ContentForMallContentId",
                table: "ContentImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContentForMallContentId",
                table: "ContentImage",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentImage_ContentForMallContentId",
                table: "ContentImage",
                column: "ContentForMallContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentImage_ContentsForMall_ContentForMallContentId",
                table: "ContentImage",
                column: "ContentForMallContentId",
                principalTable: "ContentsForMall",
                principalColumn: "ContentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
