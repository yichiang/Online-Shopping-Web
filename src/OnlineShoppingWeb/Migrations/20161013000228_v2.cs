using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_ShoppingOrder_ShoppingOrderOrderId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_ShoppingOrderOrderId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "OrderConfirmation",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "ShoppingOrderOrderId",
                table: "OrderItem");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingOrderId",
                table: "OrderItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ShoppingOrderId",
                table: "OrderItem",
                column: "ShoppingOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_ShoppingOrder_ShoppingOrderId",
                table: "OrderItem",
                column: "ShoppingOrderId",
                principalTable: "ShoppingOrder",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_ShoppingOrder_ShoppingOrderId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_ShoppingOrderId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "ShoppingOrderId",
                table: "OrderItem");

            migrationBuilder.AddColumn<string>(
                name: "OrderConfirmation",
                table: "ShoppingOrder",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingOrderOrderId",
                table: "OrderItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ShoppingOrderOrderId",
                table: "OrderItem",
                column: "ShoppingOrderOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_ShoppingOrder_ShoppingOrderOrderId",
                table: "OrderItem",
                column: "ShoppingOrderOrderId",
                principalTable: "ShoppingOrder",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
