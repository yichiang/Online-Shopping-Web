using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
