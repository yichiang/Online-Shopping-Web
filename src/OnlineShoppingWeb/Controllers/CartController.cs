using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using OnlineShoppingWeb.ViewModels;
using OnlineShoppingWeb.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using OnlineShoppingWeb.Enities;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShoppingWeb.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private IProductData _productData;
        private IShoppingCartData _shoppingCartData;
        private UserManager<User> _userManager;

        public CartController(IShoppingCartData shoppingCartData, IProductData productData, UserManager<User> userManager)
        {
            _shoppingCartData = shoppingCartData;
            _productData = productData;
            _userManager = userManager;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index(CartPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            IEnumerable<ShoppingCart> allSavedProducts=_shoppingCartData.GetAllByUser(currentUser);
            List<Product> allSavedProduct = new List<Product>();
            foreach (var item in allSavedProducts)
            {
                Product foundProduct = _productData.FindProductById(item.ProductId);
                foundProduct.Quantity = item.Qty;
                allSavedProduct.Add(foundProduct);
            }
            vm.Products = allSavedProduct;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Delete(CartPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var foundShoppingProduct = _shoppingCartData.FindCartProductById(vm.ShoppingCart.ProductId, userId);
            _shoppingCartData.Delete(foundShoppingProduct);
            return RedirectToAction("Index", "Cart");
        }
    }
}
