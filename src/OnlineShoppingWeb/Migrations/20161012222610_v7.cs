using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_Products_ProductId",
                table: "ShoppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrder_ProductId",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "ShoppingOrder");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Qty = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentPrice = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ShoppingOrderOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Qty);
                    table.ForeignKey(
                        name: "FK_OrderItem_ShoppingOrder_ShoppingOrderOrderId",
                        column: x => x.ShoppingOrderOrderId,
                        principalTable: "ShoppingOrder",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "ShoppingOrder",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OrderAddress",
                table: "ShoppingOrder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ShoppingOrderOrderId",
                table: "OrderItem",
                column: "ShoppingOrderOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "OrderAddress",
                table: "ShoppingOrder");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ShoppingOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "ShoppingOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrder_ProductId",
                table: "ShoppingOrder",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_Products_ProductId",
                table: "ShoppingOrder",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
