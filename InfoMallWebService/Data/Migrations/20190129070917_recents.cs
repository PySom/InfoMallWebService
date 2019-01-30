using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoMallWebService.Data.Migrations
{
    public partial class recents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentImage_ContentsForTab_ContentForTabId",
                table: "ContentImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentImage",
                table: "ContentImage");

            migrationBuilder.RenameTable(
                name: "ContentImage",
                newName: "ContentImages");

            migrationBuilder.RenameIndex(
                name: "IX_ContentImage_ContentForTabId",
                table: "ContentImages",
                newName: "IX_ContentImages_ContentForTabId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentImages",
                table: "ContentImages",
                column: "ContentImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentImages_ContentsForTab_ContentForTabId",
                table: "ContentImages",
                column: "ContentForTabId",
                principalTable: "ContentsForTab",
                principalColumn: "ContentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentImages_ContentsForTab_ContentForTabId",
                table: "ContentImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentImages",
                table: "ContentImages");

            migrationBuilder.RenameTable(
                name: "ContentImages",
                newName: "ContentImage");

            migrationBuilder.RenameIndex(
                name: "IX_ContentImages_ContentForTabId",
                table: "ContentImage",
                newName: "IX_ContentImage_ContentForTabId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentImage",
                table: "ContentImage",
                column: "ContentImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentImage_ContentsForTab_ContentForTabId",
                table: "ContentImage",
                column: "ContentForTabId",
                principalTable: "ContentsForTab",
                principalColumn: "ContentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
