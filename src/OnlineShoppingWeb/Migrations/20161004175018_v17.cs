using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserId1",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_UserId1",
                table: "ShoppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrder_UserId1",
                table: "ShoppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_UserId1",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ShoppingCart");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingOrder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrder_UserId",
                table: "ShoppingOrder",
                column: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserId",
                table: "ShoppingCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_UserId",
                table: "ShoppingOrder",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserId",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_UserId",
                table: "ShoppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingOrder_UserId",
                table: "ShoppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ShoppingOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingOrder",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrder_UserId1",
                table: "ShoppingOrder",
                column: "UserId1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingCart",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId1",
                table: "ShoppingCart",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserId1",
                table: "ShoppingCart",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_UserId1",
                table: "ShoppingOrder",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
