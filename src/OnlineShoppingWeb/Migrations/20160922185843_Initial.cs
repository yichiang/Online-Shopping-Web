using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineShoppingWeb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    LaptopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvgCustomerReview = table.Column<double>(nullable: false),
                    Brand = table.Column<string>(maxLength: 20, nullable: true),
                    Condition = table.Column<int>(nullable: false),
                    HardDrive = table.Column<int>(nullable: false),
                    HardDriveSize = table.Column<string>(nullable: false),
                    LaptopModel = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Processor = table.Column<int>(nullable: false),
                    ScreenSize = table.Column<double>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.LaptopId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptops");
        }
    }
}
