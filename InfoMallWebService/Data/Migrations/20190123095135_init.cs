using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoMallWebService.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UserLikesMail",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CategoriesForInformation",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesForInformation", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesForTab",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesForTab", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Clienteles",
                columns: table => new
                {
                    ClienteleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienteles", x => x.ClienteleId);
                });

            migrationBuilder.CreateTable(
                name: "ContactsInformation",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(nullable: false),
                    ContactType = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsInformation", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_ContactsInformation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentsForMall",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    LongDescription = table.Column<string>(nullable: false),
                    NumberOfViews = table.Column<int>(nullable: false),
                    ShowOnHome = table.Column<bool>(nullable: false),
                    DatePosted = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    CategoryForInformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentsForMall", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_ContentsForMall_CategoriesForInformation_CategoryForInformationId",
                        column: x => x.CategoryForInformationId,
                        principalTable: "CategoriesForInformation",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BannersInformation",
                columns: table => new
                {
                    BannerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BannerContent = table.Column<string>(nullable: false),
                    ShowBannerOnHome = table.Column<bool>(nullable: false),
                    ExtraInformation = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    CategoryForTabId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannersInformation", x => x.BannerId);
                    table.ForeignKey(
                        name: "FK_BannersInformation_CategoriesForTab_CategoryForTabId",
                        column: x => x.CategoryForTabId,
                        principalTable: "CategoriesForTab",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentsForTab",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    ShowOnHome = table.Column<bool>(nullable: false),
                    LongDescription = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    CategoryForTabId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentsForTab", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_ContentsForTab_CategoriesForTab_CategoryForTabId",
                        column: x => x.CategoryForTabId,
                        principalTable: "CategoriesForTab",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    PromotionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PromotionName = table.Column<string>(nullable: false),
                    PromotionAvailable = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    CategoryForTabId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.PromotionId);
                    table.ForeignKey(
                        name: "FK_Promotions_CategoriesForTab_CategoryForTabId",
                        column: x => x.CategoryForTabId,
                        principalTable: "CategoriesForTab",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProducts",
                columns: table => new
                {
                    CustomerProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerDecription = table.Column<string>(nullable: false),
                    CustomerHasPaid = table.Column<bool>(nullable: false),
                    ExtraInformation = table.Column<string>(nullable: true),
                    ExpectedStartDate = table.Column<DateTime>(nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(nullable: false),
                    ActualStartDate = table.Column<DateTime>(nullable: false),
                    ActualEndDate = table.Column<DateTime>(nullable: false),
                    Stage = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProducts", x => x.CustomerProductId);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentImages",
                columns: table => new
                {
                    ContentImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    ExtraData = table.Column<string>(nullable: true),
                    CarImagePath = table.Column<string>(nullable: true),
                    ContentForTabId = table.Column<int>(nullable: false),
                    ContentForMallContentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentImages", x => x.ContentImageId);
                    table.ForeignKey(
                        name: "FK_ContentImages_ContentsForMall_ContentForMallContentId",
                        column: x => x.ContentForMallContentId,
                        principalTable: "ContentsForMall",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentImages_ContentsForTab_ContentForTabId",
                        column: x => x.ContentForTabId,
                        principalTable: "ContentsForTab",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromotionCustomers",
                columns: table => new
                {
                    PromotionCustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PromotionId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionCustomers", x => x.PromotionCustomerId);
                    table.ForeignKey(
                        name: "FK_PromotionCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotionCustomers_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromotionsInformation",
                columns: table => new
                {
                    PromotionInformationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    PromotionInformationContent = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    PromotionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionsInformation", x => x.PromotionInformationId);
                    table.ForeignKey(
                        name: "FK_PromotionsInformation_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannersInformation_CategoryForTabId",
                table: "BannersInformation",
                column: "CategoryForTabId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactsInformation_UserId",
                table: "ContactsInformation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentImages_ContentForMallContentId",
                table: "ContentImages",
                column: "ContentForMallContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentImages_ContentForTabId",
                table: "ContentImages",
                column: "ContentForTabId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentsForMall_CategoryForInformationId",
                table: "ContentsForMall",
                column: "CategoryForInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentsForTab_CategoryForTabId",
                table: "ContentsForTab",
                column: "CategoryForTabId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_CustomerId",
                table: "CustomerProducts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionCustomers_CustomerId",
                table: "PromotionCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionCustomers_PromotionId",
                table: "PromotionCustomers",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_CategoryForTabId",
                table: "Promotions",
                column: "CategoryForTabId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionsInformation_PromotionId",
                table: "PromotionsInformation",
                column: "PromotionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannersInformation");

            migrationBuilder.DropTable(
                name: "Clienteles");

            migrationBuilder.DropTable(
                name: "ContactsInformation");

            migrationBuilder.DropTable(
                name: "ContentImages");

            migrationBuilder.DropTable(
                name: "CustomerProducts");

            migrationBuilder.DropTable(
                name: "PromotionCustomers");

            migrationBuilder.DropTable(
                name: "PromotionsInformation");

            migrationBuilder.DropTable(
                name: "ContentsForMall");

            migrationBuilder.DropTable(
                name: "ContentsForTab");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "CategoriesForInformation");

            migrationBuilder.DropTable(
                name: "CategoriesForTab");

            migrationBuilder.DropColumn(
                name: "UserLikesMail",
                table: "AspNetUsers");
        }
    }
}
