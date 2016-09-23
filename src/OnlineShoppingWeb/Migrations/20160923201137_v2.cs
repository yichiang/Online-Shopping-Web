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
                name: "FK_SubDepartments_Departments_DepartmentId",
                table: "SubDepartments");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "SubDepartments",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_SubDepartments_Departments_DepartmentId",
                table: "SubDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubDepartments_Departments_DepartmentId",
                table: "SubDepartments");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "SubDepartments",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubDepartments_Departments_DepartmentId",
                table: "SubDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
