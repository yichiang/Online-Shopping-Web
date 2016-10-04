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
        private IProductData _productData;

        public ShoppingCartViewComponent(IShoppingCartData cartData, IProductData productData)
        {
            _cartData = cartData;
            _productData = productData;
        }
        public IViewComponentResult Invoke()
        {
            var model = _productData.GetAll();
            return View("Default", model);
        }

    }
}
