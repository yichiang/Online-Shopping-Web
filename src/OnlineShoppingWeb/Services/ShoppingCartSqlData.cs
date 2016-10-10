using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShoppingWeb.Enities;

namespace OnlineShoppingWeb.Services
{
    public class ShoppingCartSqlData : IShoppingCartData
    {
        private ProductDbContext _context;

        public ShoppingCartSqlData(ProductDbContext context)
        {
            _context = context;
        }

        public void Delete(ShoppingCart ShoppingCartproduct)
        {
            _context.Remove(ShoppingCartproduct);
            _context.SaveChanges();
        }

        public ShoppingCart FindCartProductById(int ProductId,string UserId)
        {
            return _context.ShoppingCart.FirstOrDefault(c => c.UserId == UserId && c.ProductId == ProductId); ;
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return _context.ShoppingCart.ToList();
        }

        public IEnumerable<ShoppingCart> GetAllByUser(User User)
        {
            return _context.ShoppingCart.Where(c =>c.User== User).ToList();
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
    }
}
