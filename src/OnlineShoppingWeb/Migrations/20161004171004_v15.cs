using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderd_Products_ProductId",
                table: "ShoppingOrderd");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderd_AspNetUsers_UserId1",
                table: "ShoppingOrderd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingOrderd",
                table: "ShoppingOrderd");

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddToCartDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingOrder",
                table: "ShoppingOrderd",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_ProductId",
                table: "ShoppingCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId1",
                table: "ShoppingCart",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_Products_ProductId",
                table: "ShoppingOrderd",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_UserId1",
                table: "ShoppingOrderd",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrderd_UserId1",
                table: "ShoppingOrderd",
                newName: "IX_ShoppingOrder_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrderd_ProductId",
                table: "ShoppingOrderd",
                newName: "IX_ShoppingOrder_ProductId");

            migrationBuilder.RenameTable(
                name: "ShoppingOrderd",
                newName: "ShoppingOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_Products_ProductId",
                table: "ShoppingOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_UserId1",
                table: "ShoppingOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingOrder",
                table: "ShoppingOrder");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingOrderd",
                table: "ShoppingOrder",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderd_Products_ProductId",
                table: "ShoppingOrder",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderd_AspNetUsers_UserId1",
                table: "ShoppingOrder",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrder_UserId1",
                table: "ShoppingOrder",
                newName: "IX_ShoppingOrderd_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrder_ProductId",
                table: "ShoppingOrder",
                newName: "IX_ShoppingOrderd_ProductId");

            migrationBuilder.RenameTable(
                name: "ShoppingOrder",
                newName: "ShoppingOrderd");
        }
    }
}
