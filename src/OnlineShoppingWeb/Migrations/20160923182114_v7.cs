using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_SubDepartment_SubDepartmentId",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_Laptops_PurchasedProductProductId",
                table: "ShoppingOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_UserId",
                table: "ShoppingOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SubDepartment_Department_DepartmentId",
                table: "SubDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubDepartment",
                table: "SubDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingOrder",
                table: "ShoppingOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubDepartments",
                table: "SubDepartment",
                column: "SubDepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingOrderd",
                table: "ShoppingOrder",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Department",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_SubDepartments_SubDepartmentId",
                table: "Laptops",
                column: "SubDepartmentId",
                principalTable: "SubDepartment",
                principalColumn: "SubDepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderd_Laptops_PurchasedProductProductId",
                table: "ShoppingOrder",
                column: "PurchasedProductProductId",
                principalTable: "Laptops",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderd_AspNetUsers_UserId",
                table: "ShoppingOrder",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubDepartments_Departments_DepartmentId",
                table: "SubDepartment",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_SubDepartment_DepartmentId",
                table: "SubDepartment",
                newName: "IX_SubDepartments_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrder_UserId",
                table: "ShoppingOrder",
                newName: "IX_ShoppingOrderd_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrder_PurchasedProductProductId",
                table: "ShoppingOrder",
                newName: "IX_ShoppingOrderd_PurchasedProductProductId");

            migrationBuilder.RenameTable(
                name: "SubDepartment",
                newName: "SubDepartments");

            migrationBuilder.RenameTable(
                name: "ShoppingOrder",
                newName: "ShoppingOrderd");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_SubDepartments_SubDepartmentId",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderd_Laptops_PurchasedProductProductId",
                table: "ShoppingOrderd");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderd_AspNetUsers_UserId",
                table: "ShoppingOrderd");

            migrationBuilder.DropForeignKey(
                name: "FK_SubDepartments_Departments_DepartmentId",
                table: "SubDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubDepartments",
                table: "SubDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingOrderd",
                table: "ShoppingOrderd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubDepartment",
                table: "SubDepartments",
                column: "SubDepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingOrder",
                table: "ShoppingOrderd",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_SubDepartment_SubDepartmentId",
                table: "Laptops",
                column: "SubDepartmentId",
                principalTable: "SubDepartments",
                principalColumn: "SubDepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_Laptops_PurchasedProductProductId",
                table: "ShoppingOrderd",
                column: "PurchasedProductProductId",
                principalTable: "Laptops",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrder_AspNetUsers_UserId",
                table: "ShoppingOrderd",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubDepartment_Department_DepartmentId",
                table: "SubDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_SubDepartments_DepartmentId",
                table: "SubDepartments",
                newName: "IX_SubDepartment_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrderd_UserId",
                table: "ShoppingOrderd",
                newName: "IX_ShoppingOrder_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrderd_PurchasedProductProductId",
                table: "ShoppingOrderd",
                newName: "IX_ShoppingOrder_PurchasedProductProductId");

            migrationBuilder.RenameTable(
                name: "SubDepartments",
                newName: "SubDepartment");

            migrationBuilder.RenameTable(
                name: "ShoppingOrderd",
                newName: "ShoppingOrder");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");
        }
    }
}
