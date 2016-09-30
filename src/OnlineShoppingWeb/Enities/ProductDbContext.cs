﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace OnlineShoppingWeb.Enities
{
    public class ProductDbContext : IdentityDbContext<User>
    {
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingOrder> ShoppingOrderd { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SubDepartment> SubDepartments { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<ShoppingOrder>().HasKey(x => new { x.ProductId, x.UserId });

        }
    }

}
