using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "SubDepartment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubDepartment_DepartmentId",
                table: "SubDepartment",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubDepartment_Department_DepartmentId",
                table: "SubDepartment",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubDepartment_Department_DepartmentId",
                table: "SubDepartment");

            migrationBuilder.DropIndex(
                name: "IX_SubDepartment_DepartmentId",
                table: "SubDepartment");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "SubDepartment",
                nullable: false);
        }
    }
}
