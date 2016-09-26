using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_SubDepartments_SubDepartmentId",
                table: "Laptops");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SubDepartments",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Laptops",
                maxLength: 255,
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SubDepartmentId",
                table: "Laptops",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_SubDepartments_SubDepartmentId",
                table: "Laptops",
                column: "SubDepartmentId",
                principalTable: "SubDepartments",
                principalColumn: "SubDepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_SubDepartments_SubDepartmentId",
                table: "Laptops");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SubDepartments",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Laptops",
                maxLength: 30,
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "SubDepartmentId",
                table: "Laptops",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_SubDepartments_SubDepartmentId",
                table: "Laptops",
                column: "SubDepartmentId",
                principalTable: "SubDepartments",
                principalColumn: "SubDepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
