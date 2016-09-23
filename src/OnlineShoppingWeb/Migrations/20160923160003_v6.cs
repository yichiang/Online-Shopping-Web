using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_Laptops_ProductId",
                table: "ShoppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrder_ProductId",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShoppingOrder");

            migrationBuilder.AddColumn<int>(
                name: "PurchasedProductProductId",
                table: "ShoppingOrder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrder_PurchasedProductProductId",
                table: "ShoppingOrder",
                column: "PurchasedProductProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_Laptops_PurchasedProductProductId",
                table: "ShoppingOrder",
                column: "PurchasedProductProductId",
                principalTable: "Laptops",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_Laptops_PurchasedProductProductId",
                table: "ShoppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrder_PurchasedProductProductId",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "PurchasedProductProductId",
                table: "ShoppingOrder");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ShoppingOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrder_ProductId",
                table: "ShoppingOrder",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_Laptops_ProductId",
                table: "ShoppingOrder",
                column: "ProductId",
                principalTable: "Laptops",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
