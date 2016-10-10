using OnlineShoppingWeb.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.ViewModels
{
    public class CartPageViewModel
    {
        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public User User { get; set; }

    }
}
