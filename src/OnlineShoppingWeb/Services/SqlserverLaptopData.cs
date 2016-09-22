using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.Models;

namespace OnlineShoppingWeb.Services
{

    public class SqlServerLaptopData : IProductData
    {
        private ProductDbContext _context;

        public SqlServerLaptopData(ProductDbContext context)
        {
            _context = context;
        }

        public void AddNewProduct(IProduct newProduct)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
        }

        public IEnumerable<IProduct> GetAll()
        {
            return _context.Laptops;
        }

        public IProduct GetLaptopById(int id)
        {
            return _context.Laptops.FirstOrDefault(computer => computer.LaptopId == id );
        }
    }
}
