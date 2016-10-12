using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShoppingWeb.Enities;

namespace OnlineShoppingWeb.Services
{
    public class SqlCheckoutData : ICheckoutData
    {
        private ProductDbContext _context;

        public SqlCheckoutData(ProductDbContext context)
        {
            _context = context;

        }
        public void SaveOrder(ShoppingOrder ShoppingOrder)
        {
            ShoppingOrder.Create_Date = DateTime.Now;
            _context.Add(ShoppingOrder);
            _context.SaveChanges();
        }

        public void SaveOrderItem(OrderItem OrderItem)
        {
            _context.Add(OrderItem);
            _context.SaveChanges();
        }
    }
}
