using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlineShoppingWeb.Enities;

namespace OnlineShoppingWeb.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineShoppingWeb.Enities.Laptop", b =>
                {
                    b.Property<int>("LaptopId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AvgCustomerReview");

                    b.Property<string>("Brand")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int>("Condition");

                    b.Property<int>("HardDrive");

                    b.Property<string>("HardDriveSize")
                        .IsRequired();

                    b.Property<string>("LaptopModel");

                    b.Property<decimal>("Price");

                    b.Property<int>("Processor");

                    b.Property<double>("ScreenSize");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("LaptopId");

                    b.ToTable("Laptops");
                });
        }
    }
}
