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
using System;

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
        [HttpGet("cart")]
        // GET: /<controller>/
        public async Task<IActionResult> Index(CartPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            IEnumerable<ShoppingCart> allSavedProducts=_shoppingCartData.GetAllByUser(currentUser);
            List<Product> allSavedProduct = new List<Product>();
            foreach (var item in allSavedProducts)
            {
                item.Proudct.Quantity = item.Qty;
                allSavedProduct.Add(item.Proudct);
            }
            vm.Products = allSavedProduct;
            vm.totalPrice = vm.Products.Sum(p => p.Price * p.Quantity);
            vm.SaveForLaters = _shoppingCartData.GetAllSaveForLaterByUserId(userId);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Delete(CartPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var foundShoppingProduct = _shoppingCartData.FindCartProductById(vm.ShoppingCart.ProductId, userId);
            _shoppingCartData.Delete(foundShoppingProduct);
            return RedirectToAction("Index","Cart");
        }

        [HttpPost]
        public IActionResult ChangeQty(CartPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var foundShoppingProduct = _shoppingCartData.FindCartProductById(vm.ShoppingCart.ProductId, userId);
            var foundProduct = _productData.FindProductById(vm.ShoppingCart.ProductId);
            var intendedChangeQty = vm.ShoppingCart.Qty;
            var originalQty = foundProduct.Quantity;
            if (intendedChangeQty <= originalQty)
            {
                decimal totalChangePrice = (intendedChangeQty - foundShoppingProduct.Qty) * foundProduct.Price;

                _shoppingCartData.ModifyQty(foundShoppingProduct, intendedChangeQty);
                return Json(new { qty = intendedChangeQty, totalChangePrice = totalChangePrice, message="success to change qty from "+ originalQty + "to"+ intendedChangeQty });
            }
            else
            {
                return Json(new { qty = originalQty, totalChangePrice = 0, message="Sorry, We Don't have too much in stock" });

            }
        }
        [HttpPost]
        public IActionResult SaveForLater(CartPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
 
            if (_shoppingCartData.CheckIsExistedInList(vm.SaveForLater.ProductId, userId))
            {
                return Json(new { success = false, responseText = "The attached file is not supported." });
            }
            else
            {
                var foundShoppingProduct = _shoppingCartData.FindCartProductById(vm.SaveForLater.ProductId, userId);

                Product foundProduct = _productData.FindProductById(vm.SaveForLater.ProductId);
                decimal totalChangePrice = (-foundShoppingProduct.Qty) * vm.ProductPrice;
                _shoppingCartData.Delete(foundShoppingProduct);
                SaveForLater foundSaveForLater = _shoppingCartData.SaveForLater(vm.SaveForLater.ProductId, userId);
                return Json(new { success = true, list = foundSaveForLater, totalChangePrice = totalChangePrice });
            }
   
        }
        [HttpPost]
        public IActionResult SaveForLaterDelete(CartPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _shoppingCartData.DelteSaveToList(vm.SaveForLater.ProductId,userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MoveToCartFromList(CartPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _productData.SaveToCart(vm.SaveForLater.ProductId, userId);
            _shoppingCartData.DelteSaveToList(vm.SaveForLater.ProductId, userId);
            return RedirectToAction("Index");
        }
    }
}

