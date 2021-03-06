﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlineShoppingWeb.Enities;

namespace OnlineShoppingWeb.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20161018181905_totalToOrder")]
    partial class totalToOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CurrentPrice");

                    b.Property<int>("ProductId");

                    b.Property<int>("Qty");

                    b.Property<int>("ShoppingOrderId");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingOrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AvgCustomerReview");

                    b.Property<string>("Brand")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int>("Condition");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsAvailiable");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("SubDepartmentId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("ProductId");

                    b.HasIndex("SubDepartmentId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.ProductImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<string>("ContentType")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("FileName")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("FileType");

                    b.Property<int>("ProductId");

                    b.HasKey("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.ProductReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Context");

                    b.Property<DateTime>("PostTime");

                    b.Property<int>("ProductId");

                    b.Property<double>("Score");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductReviews");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.SaveForLater", b =>
                {
                    b.Property<int>("SaveForLaterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductId");

                    b.Property<string>("UserId");

                    b.HasKey("SaveForLaterId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("SaveForLaters");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddToCartDate");

                    b.Property<int>("ProductId");

                    b.Property<int>("Qty");

                    b.Property<string>("UserId");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.ShoppingOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Create_Date");

                    b.Property<bool>("IsCanceled");

                    b.Property<bool>("IsReceived");

                    b.Property<bool>("IsRequestReturn");

                    b.Property<bool>("IsShipped");

                    b.Property<string>("Notes");

                    b.Property<string>("OrderAddress");

                    b.Property<string>("Payment");

                    b.Property<decimal>("Total");

                    b.Property<string>("UserId");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingOrder");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.SubDepartment", b =>
                {
                    b.Property<int>("SubDepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Description");

                    b.HasKey("SubDepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("SubDepartments");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<DateTime>("JoinDate");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("ShippingAddress");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.Laptop", b =>
                {
                    b.HasBaseType("OnlineShoppingWeb.Enities.Product");

                    b.Property<int>("HardDrive");

                    b.Property<string>("HardDriveSize")
                        .IsRequired();

                    b.Property<string>("LaptopModel");

                    b.Property<int>("Processor");

                    b.Property<double>("ScreenSize");

                    b.ToTable("Laptops");

                    b.HasDiscriminator().HasValue("Laptop");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.Phone", b =>
                {
                    b.HasBaseType("OnlineShoppingWeb.Enities.Product");

                    b.Property<string>("Carrier");

                    b.Property<double>("ScreenSize");

                    b.ToTable("Products");

                    b.HasDiscriminator().HasValue("Phone");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineShoppingWeb.Enities.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineShoppingWeb.Enities.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineShoppingWeb.Enities.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.OrderItem", b =>
                {
                    b.HasOne("OnlineShoppingWeb.Enities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineShoppingWeb.Enities.ShoppingOrder", "ShoppingOrder")
                        .WithMany("OrderItem")
                        .HasForeignKey("ShoppingOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.Product", b =>
                {
                    b.HasOne("OnlineShoppingWeb.Enities.SubDepartment", "SubDepartment")
                        .WithMany("Products")
                        .HasForeignKey("SubDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.ProductImage", b =>
                {
                    b.HasOne("OnlineShoppingWeb.Enities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.ProductReview", b =>
                {
                    b.HasOne("OnlineShoppingWeb.Enities.Product", "Product")
                        .WithMany("ProductReviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineShoppingWeb.Enities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.SaveForLater", b =>
                {
                    b.HasOne("OnlineShoppingWeb.Enities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineShoppingWeb.Enities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.ShoppingCart", b =>
                {
                    b.HasOne("OnlineShoppingWeb.Enities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineShoppingWeb.Enities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.ShoppingOrder", b =>
                {
                    b.HasOne("OnlineShoppingWeb.Enities.User", "User")
                        .WithMany("ShoppingOrders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OnlineShoppingWeb.Enities.SubDepartment", b =>
                {
                    b.HasOne("OnlineShoppingWeb.Enities.Department", "Department")
                        .WithMany("SubDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
