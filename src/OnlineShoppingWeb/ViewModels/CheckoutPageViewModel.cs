using Microsoft.AspNet.Http;
using OnlineShoppingWeb.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.ViewModels
{

    public class CheckoutPageViewModel
    {
        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string ShippingAddress { get; set; }
        public ShoppingOrder ShoppingOrder { get; set; }
        public decimal Total { get; set; }
        public string Key { get; set; }

    }
}
