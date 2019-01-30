﻿// <auto-generated />
using System;
using InfoMallWebService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfoMallWebService.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190123095135_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InfoMallWebService.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<bool>("UserLikesMail");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("InfoMallWebService.Models.BannerInformation", b =>
                {
                    b.Property<int>("BannerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BannerContent")
                        .IsRequired();

                    b.Property<int>("CategoryForTabId");

                    b.Property<string>("ExtraInformation");

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<bool>("ShowBannerOnHome");

                    b.HasKey("BannerId");

                    b.HasIndex("CategoryForTabId");

                    b.ToTable("BannersInformation");
                });

            modelBuilder.Entity("InfoMallWebService.Models.CategoryForInformation", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.HasKey("CategoryId");

                    b.ToTable("CategoriesForInformation");
                });

            modelBuilder.Entity("InfoMallWebService.Models.CategoryForTab", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.HasKey("CategoryId");

                    b.ToTable("CategoriesForTab");
                });

            modelBuilder.Entity("InfoMallWebService.Models.Clientele", b =>
                {
                    b.Property<int>("ClienteleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<int>("Priority");

                    b.HasKey("ClienteleId");

                    b.ToTable("Clienteles");
                });

            modelBuilder.Entity("InfoMallWebService.Models.ContactInformation", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactType");

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("ContactId");

                    b.HasIndex("UserId");

                    b.ToTable("ContactsInformation");
                });

            modelBuilder.Entity("InfoMallWebService.Models.ContentForMall", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryForInformationId");

                    b.Property<DateTime>("DatePosted");

                    b.Property<string>("ImagePath");

                    b.Property<string>("LongDescription")
                        .IsRequired();

                    b.Property<int>("NumberOfViews");

                    b.Property<int>("Position");

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.Property<bool>("ShowOnHome");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ContentId");

                    b.HasIndex("CategoryForInformationId");

                    b.ToTable("ContentsForMall");
                });

            modelBuilder.Entity("InfoMallWebService.Models.ContentForTab", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryForTabId");

                    b.Property<string>("ImagePath");

                    b.Property<string>("LongDescription")
                        .IsRequired();

                    b.Property<int>("Position");

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.Property<bool>("ShowOnHome");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ContentId");

                    b.HasIndex("CategoryForTabId");

                    b.ToTable("ContentsForTab");
                });

            modelBuilder.Entity("InfoMallWebService.Models.ContentImage", b =>
                {
                    b.Property<int>("ContentImageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarImagePath");

                    b.Property<int?>("ContentForMallContentId");

                    b.Property<int>("ContentForTabId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ExtraData");

                    b.HasKey("ContentImageId");

                    b.HasIndex("ContentForMallContentId");

                    b.HasIndex("ContentForTabId");

                    b.ToTable("ContentImages");
                });

            modelBuilder.Entity("InfoMallWebService.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId");

                    b.HasKey("CustomerId");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("InfoMallWebService.Models.CustomerProduct", b =>
                {
                    b.Property<int>("CustomerProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActualEndDate");

                    b.Property<DateTime>("ActualStartDate");

                    b.Property<string>("CustomerDecription")
                        .IsRequired();

                    b.Property<bool>("CustomerHasPaid");

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("ExpectedEndDate");

                    b.Property<DateTime>("ExpectedStartDate");

                    b.Property<string>("ExtraInformation");

                    b.Property<int>("PaymentType");

                    b.Property<int>("Stage");

                    b.HasKey("CustomerProductId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerProducts");
                });

            modelBuilder.Entity("InfoMallWebService.Models.Promotion", b =>
                {
                    b.Property<int>("PromotionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryForTabId");

                    b.Property<string>("ImagePath");

                    b.Property<bool>("PromotionAvailable");

                    b.Property<string>("PromotionName")
                        .IsRequired();

                    b.HasKey("PromotionId");

                    b.HasIndex("CategoryForTabId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("InfoMallWebService.Models.PromotionCustomer", b =>
                {
                    b.Property<int>("PromotionCustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId");

                    b.Property<int>("PromotionId");

                    b.HasKey("PromotionCustomerId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionCustomers");
                });

            modelBuilder.Entity("InfoMallWebService.Models.PromotionInformation", b =>
                {
                    b.Property<int>("PromotionInformationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath");

                    b.Property<int>("PromotionId");

                    b.Property<string>("PromotionInformationContent")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("PromotionInformationId");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionsInformation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("InfoMallWebService.Models.BannerInformation", b =>
                {
                    b.HasOne("InfoMallWebService.Models.CategoryForTab", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryForTabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InfoMallWebService.Models.ContactInformation", b =>
                {
                    b.HasOne("InfoMallWebService.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("InfoMallWebService.Models.ContentForMall", b =>
                {
                    b.HasOne("InfoMallWebService.Models.CategoryForInformation", "Category")
                        .WithMany("ContentsForInformation")
                        .HasForeignKey("CategoryForInformationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InfoMallWebService.Models.ContentForTab", b =>
                {
                    b.HasOne("InfoMallWebService.Models.CategoryForTab", "Category")
                        .WithMany("ContentForTabs")
                        .HasForeignKey("CategoryForTabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InfoMallWebService.Models.ContentImage", b =>
                {
                    b.HasOne("InfoMallWebService.Models.ContentForMall")
                        .WithMany("OtherContentImages")
                        .HasForeignKey("ContentForMallContentId");

                    b.HasOne("InfoMallWebService.Models.ContentForTab", "ContentForTab")
                        .WithMany()
                        .HasForeignKey("ContentForTabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InfoMallWebService.Models.Customer", b =>
                {
                    b.HasOne("InfoMallWebService.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("InfoMallWebService.Models.CustomerProduct", b =>
                {
                    b.HasOne("InfoMallWebService.Models.Customer", "Customer")
                        .WithMany("CustomerProducts")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("InfoMallWebService.Models.Promotion", b =>
                {
                    b.HasOne("InfoMallWebService.Models.CategoryForTab", "Category")
                        .WithMany("Promotions")
                        .HasForeignKey("CategoryForTabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InfoMallWebService.Models.PromotionCustomer", b =>
                {
                    b.HasOne("InfoMallWebService.Models.Customer", "Customer")
                        .WithMany("MyPromotions")
                        .HasForeignKey("CustomerId");

                    b.HasOne("InfoMallWebService.Models.Promotion", "Promotion")
                        .WithMany("PromotionCustomers")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InfoMallWebService.Models.PromotionInformation", b =>
                {
                    b.HasOne("InfoMallWebService.Models.Promotion", "Promotion")
                        .WithMany("PromotionsInformation")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("InfoMallWebService.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("InfoMallWebService.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InfoMallWebService.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("InfoMallWebService.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
