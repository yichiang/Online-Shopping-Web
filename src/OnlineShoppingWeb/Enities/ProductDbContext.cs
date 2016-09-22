using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Enities
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}
