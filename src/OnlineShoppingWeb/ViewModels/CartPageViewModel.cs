﻿using OnlineShoppingWeb.Enities;
using System.Collections.Generic;

namespace OnlineShoppingWeb.ViewModels
{
    public class CartPageViewModel
    {
        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
        public IEnumerable<SaveForLater> SaveForLaters { get; set; }

        public IEnumerable<Product> Products { get; set; }
        public User User { get; set; }
        public SaveForLater SaveForLater { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public decimal totalPrice { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
