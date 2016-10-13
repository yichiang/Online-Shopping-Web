using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_ProductId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_AspNetUsers_UserId1",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.AddPrimaryKey(
                name: "PK_File",
                table: "Files",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Products_ProductId",
                table: "Files",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_File_AspNetUsers_UserId1",
                table: "Files",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Files_UserId1",
                table: "Files",
                newName: "IX_File_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Files_ProductId",
                table: "Files",
                newName: "IX_File_ProductId");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "File");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Products_ProductId",
                table: "File");

            migrationBuilder.DropForeignKey(
                name: "FK_File_AspNetUsers_UserId1",
                table: "File");

            migrationBuilder.DropPrimaryKey(
                name: "PK_File",
                table: "File");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "File",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_ProductId",
                table: "File",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_UserId1",
                table: "File",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_File_UserId1",
                table: "File",
                newName: "IX_Files_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_File_ProductId",
                table: "File",
                newName: "IX_Files_ProductId");

            migrationBuilder.RenameTable(
                name: "File",
                newName: "Files");
        }
    }
}
