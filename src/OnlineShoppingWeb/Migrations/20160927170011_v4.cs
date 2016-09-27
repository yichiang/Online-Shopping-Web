using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderd_Laptops_PurchasedProductProductId",
                table: "ShoppingOrderd");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvgCustomerReview = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SubDepartmentId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Brand = table.Column<string>(maxLength: 20, nullable: true),
                    Condition = table.Column<int>(nullable: true),
                    HardDrive = table.Column<int>(nullable: true),
                    HardDriveSize = table.Column<string>(nullable: true),
                    LaptopModel = table.Column<string>(nullable: true),
                    Processor = table.Column<int>(nullable: true),
                    ScreenSize = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_SubDepartments_SubDepartmentId",
                        column: x => x.SubDepartmentId,
                        principalTable: "SubDepartments",
                        principalColumn: "SubDepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubDepartmentId",
                table: "Products",
                column: "SubDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderd_Products_PurchasedProductProductId",
                table: "ShoppingOrderd",
                column: "PurchasedProductProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderd_Products_PurchasedProductProductId",
                table: "ShoppingOrderd");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvgCustomerReview = table.Column<double>(nullable: false),
                    Brand = table.Column<string>(maxLength: 20, nullable: true),
                    Condition = table.Column<int>(nullable: false),
                    HardDrive = table.Column<int>(nullable: false),
                    HardDriveSize = table.Column<string>(nullable: false),
                    LaptopModel = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Processor = table.Column<int>(nullable: false),
                    ScreenSize = table.Column<double>(nullable: false),
                    SubDepartmentId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Laptops_SubDepartments_SubDepartmentId",
                        column: x => x.SubDepartmentId,
                        principalTable: "SubDepartments",
                        principalColumn: "SubDepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_SubDepartmentId",
                table: "Laptops",
                column: "SubDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderd_Laptops_PurchasedProductProductId",
                table: "ShoppingOrderd",
                column: "PurchasedProductProductId",
                principalTable: "Laptops",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
