using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineShoppingWeb.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Laptops");

            migrationBuilder.CreateTable(
                name: "SubDepartment",
                columns: table => new
                {
                    SubDepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDepartment", x => x.SubDepartmentId);
                });

            migrationBuilder.AddColumn<int>(
                name: "SubDepartmentId",
                table: "Laptops",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_SubDepartmentId",
                table: "Laptops",
                column: "SubDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_SubDepartment_SubDepartmentId",
                table: "Laptops",
                column: "SubDepartmentId",
                principalTable: "SubDepartment",
                principalColumn: "SubDepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_SubDepartment_SubDepartmentId",
                table: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_SubDepartmentId",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "SubDepartmentId",
                table: "Laptops");

            migrationBuilder.DropTable(
                name: "SubDepartment");

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "Laptops",
                nullable: false,
                defaultValue: 0);
        }
    }
}
