using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.ViewComponents
{
    public class ShoppingCartViewComponent :ViewComponent
    {
        private IShoppingCartData _cartData;

        public ShoppingCartViewComponent(IShoppingCartData cartData)
        {
            _cartData = cartData;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
