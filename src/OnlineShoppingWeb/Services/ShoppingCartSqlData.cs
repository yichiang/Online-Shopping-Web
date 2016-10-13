using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShoppingWeb.Enities;
using Microsoft.EntityFrameworkCore;

namespace OnlineShoppingWeb.Services
{
    public class ShoppingCartSqlData : IShoppingCartData
    {
        private ProductDbContext _context;

        public ShoppingCartSqlData(ProductDbContext context)
        {
            _context = context;
        }

        public bool CheckIsExistedInList(int ProductId, string userId)
        {
            return this.GetSaveForLater(ProductId, userId) == null ? false : true;
        }

        public void Delete(ShoppingCart ShoppingCartproduct)
        {
            _context.Remove(ShoppingCartproduct);
            _context.SaveChanges();
        }

        public void DelteSaveToList(int ProductId, string userId)
        {
            SaveForLater DeleteProductList = this.GetSaveForLater(ProductId, userId); 
            _context.Remove(DeleteProductList);
            _context.SaveChanges();
        }

        public ShoppingCart FindCartProductById(int ProductId,string UserId)
        {
            return _context.ShoppingCart.FirstOrDefault(c => c.UserId == UserId && c.ProductId == ProductId); ;
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return _context.ShoppingCart.Include(m => m.User).ToList();
        }

        public IEnumerable<ShoppingCart> GetAllByUser(User User)
        {
            return _context.ShoppingCart.Include(m => m.Proudct). Where(c =>c.User== User).ToList();
        }

        public IEnumerable<SaveForLater> GetAllSaveForLaterByUserId(string UserId)
        {

            return _context.SaveForLaters.Include(m => m.Proudct).ToList();
        }

        public SaveForLater GetSaveForLater(int ProductId, string userId)
        {
            return  _context.SaveForLaters.FirstOrDefault(c => c.UserId == userId && c.ProductId == ProductId);

        }

        public int GetUserTotalSavedItems(string UserId)
        {
            return _context.ShoppingCart.Where(c => c.UserId == UserId).Sum(c => c.Qty);
        }

        public bool IsProductInCart(int ProductId, string UserId)
        {
            var foundProductCount=_context.ShoppingCart.Where(c => c.UserId == UserId && c.ProductId == ProductId).Count();
            if (foundProductCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public void ModifyQty(ShoppingCart product ,int newQty)
        {
            product.Qty = newQty;
            product.AddToCartDate = DateTime.Now;
            _context.SaveChanges();

        }

        public SaveForLater SaveForLater(int ProductId, string userId)
        {
            SaveForLater newProduct = new SaveForLater();
            newProduct.ProductId = ProductId;
            newProduct.UserId = userId;
            _context.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }
    }
}
