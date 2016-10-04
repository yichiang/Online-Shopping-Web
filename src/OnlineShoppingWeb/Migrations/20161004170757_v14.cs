using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderd_Products_PurchasedProductProductId",
                table: "ShoppingOrderd");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderd_AspNetUsers_UserId",
                table: "ShoppingOrderd");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrderd_PurchasedProductProductId",
                table: "ShoppingOrderd");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrderd_UserId",
                table: "ShoppingOrderd");

            migrationBuilder.DropColumn(
                name: "PurchasedProductProductId",
                table: "ShoppingOrderd");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ShoppingOrderd",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ShoppingOrderd",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingOrderd",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrderd_ProductId",
                table: "ShoppingOrderd",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrderd_UserId1",
                table: "ShoppingOrderd",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderd_Products_ProductId",
                table: "ShoppingOrderd",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderd_AspNetUsers_UserId1",
                table: "ShoppingOrderd",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderd_Products_ProductId",
                table: "ShoppingOrderd");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderd_AspNetUsers_UserId1",
                table: "ShoppingOrderd");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrderd_ProductId",
                table: "ShoppingOrderd");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrderd_UserId1",
                table: "ShoppingOrderd");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShoppingOrderd");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ShoppingOrderd");

            migrationBuilder.AddColumn<int>(
                name: "PurchasedProductProductId",
                table: "ShoppingOrderd",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingOrderd",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrderd_PurchasedProductProductId",
                table: "ShoppingOrderd",
                column: "PurchasedProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrderd_UserId",
                table: "ShoppingOrderd",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderd_Products_PurchasedProductProductId",
                table: "ShoppingOrderd",
                column: "PurchasedProductProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderd_AspNetUsers_UserId",
                table: "ShoppingOrderd",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
