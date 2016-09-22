using Microsoft.EntityFrameworkCore;
using OnlineShoppingWeb.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Models
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; }
    }
}
