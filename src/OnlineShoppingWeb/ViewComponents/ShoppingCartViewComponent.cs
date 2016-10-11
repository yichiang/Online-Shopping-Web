using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Services;
using System.Linq;
using System.Security.Claims;

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
            var userName = this.User.Identity.Name;
            var model = _cartData.GetAll().Where(c =>c.User.UserName== userName).ToList();
            return View("Default", model);
        }

    }
}
