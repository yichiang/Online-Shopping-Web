﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShoppingWeb.Enities;

namespace OnlineShoppingWeb.Services
{

    public class SqlServerLaptopData : IProductData
    {
        private ProductDbContext _context;

        public SqlServerLaptopData(ProductDbContext context)
        {
            _context = context;
        }

        public void AddNewProduct(Product newProduct)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
        }

        public void DeleteProduct(int ProductId)
        {
            
            _context.Remove(this.FindProductById(ProductId));
            _context.SaveChanges();
        }

        public Product FindProductById(int ProductId)
        {
            return _context.Products.FirstOrDefault(computer => computer.ProductId == ProductId);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IProduct GetLaptopById(int id)
        {
            return _context.Products.FirstOrDefault(computer => computer.ProductId == id );
        }

        public IEnumerable<Product> GetProductsbySubDepartment(int SubDepartmentId)
        {
            return _context.Products.Where(computer => computer.SubDepartmentId== SubDepartmentId);
        }
    }
}
