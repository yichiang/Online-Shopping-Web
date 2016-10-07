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
        public IEnumerable<ShoppingCart> GetAll()
        {
            return _context.ShoppingCart.ToList();
        }

        public IEnumerable<ShoppingCart> GetAllByUser(User User)
        {
            return _context.ShoppingCart.Where(c =>c.User== User).ToList();
        }
    }
}
