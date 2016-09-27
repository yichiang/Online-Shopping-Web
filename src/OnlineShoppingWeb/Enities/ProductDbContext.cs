using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Enities
{
    public class ProductDbContext : IdentityDbContext<User>
    {
        public DbSet<Laptop> Laptops { get; set; }
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
