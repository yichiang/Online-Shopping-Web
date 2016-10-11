using System.Collections.Generic;
using System.Linq;
using OnlineShoppingWeb.Enities;
using Microsoft.EntityFrameworkCore;
using System;

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

        public Product Edit(Product EditProduct)
        {
            _context.Entry(EditProduct).State = EntityState.Modified;
            _context.SaveChanges();
            return EditProduct;
        }

        public void EditQty(Product EditProduct)
        {
            Product foundProduct=this.FindProductById(EditProduct.ProductId);
            foundProduct.Quantity = EditProduct.Quantity;
            _context.SaveChanges();

        }

        public Product FindProductById(int ProductId)
        {
            return _context.Products.FirstOrDefault(computer => computer.ProductId == ProductId);
        }

        public Product FindProductByIdIncludedReview(int ProductId)
        {
            return _context.Products.Include(m =>m.ProductReviews).FirstOrDefault(computer => computer.ProductId == ProductId);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public double GetAverageReview(int ProductId)
        {
            return _context.ProductReview.Select(c => c.Score).Average();
        }

        public IEnumerable<Product> GetPorductsofNum(int SkipNum,int TakeNum)
        {

            var number = _context.Products.Count();
            return _context.Products.Skip(SkipNum).Take(TakeNum).ToList();

        }

        public IEnumerable<Product> GetProductsbySubDepartment(int SubDepartmentId)
        {
            return _context.Products.Where(computer => computer.SubDepartmentId== SubDepartmentId);
        }

        public void SaveReview(ProductReview ProductReview)
        {
            _context.Add(ProductReview);
            _context.SaveChanges();
        }

        public void SaveToCart(int ProductId, string UserId)
        {

            ShoppingCart newProductAddtoCart = new ShoppingCart();
            newProductAddtoCart.ProductId = ProductId;
            newProductAddtoCart.UserId = UserId;
            newProductAddtoCart.AddToCartDate = DateTime.Now;
            newProductAddtoCart.Qty+=1;
            _context.ShoppingCart.Add(newProductAddtoCart);
            _context.SaveChanges();

        }

        public IEnumerable<Product> SearchByTitle(string SearchTitle)
        {
            return _context.Products.Where(product => product.Title.Contains(SearchTitle)).ToList();
        }
    }
}
