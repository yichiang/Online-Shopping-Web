﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using OnlineShoppingWeb.Enities;
using Microsoft.AspNetCore.Identity;
using OnlineShoppingWeb.Services;
using OnlineShoppingWeb.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShoppingWeb.Controllers
{
    [Authorize]

    public class CheckoutController : Controller
    {
        private IProductData _productData;
        private IShoppingCartData _shoppingCartData;
        private UserManager<User> _userManager;
        private ICheckoutData _checkoutData;

        public CheckoutController(ICheckoutData checkoutData, IShoppingCartData shoppingCartData, IProductData productData, UserManager<User> userManager)
        {
            _userManager = userManager;
            _shoppingCartData = shoppingCartData;
            _productData = productData;
            _checkoutData = checkoutData;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            CheckoutPageViewModel vm = new CheckoutPageViewModel();
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            IEnumerable<ShoppingCart> allSavedProducts = _shoppingCartData.GetAllByUser(currentUser);
            List<Product> allSavedProduct = new List<Product>();
            foreach (var item in allSavedProducts)
            {
                Product foundProduct = _productData.FindProductById(item.ProductId);
                foundProduct.Quantity = item.Qty;
                allSavedProduct.Add(foundProduct);
            }
            vm.Products = allSavedProduct;
            if (!string.IsNullOrEmpty(currentUser.ShippingAddress))
            {
                vm.ShippingAddress = currentUser.ShippingAddress;
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult PlaceOrder(CheckoutPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ShoppingOrder newOrder = new ShoppingOrder();
            newOrder.OrderAddress = vm.ShippingAddress;
            foreach (var product in vm.Products)
            {
                OrderItem Item = new OrderItem();
                Item.CurrentPrice = product.Price;
                Item.ProductId = product.ProductId;
                Item.Qty = product.Quantity;
                
            }
            return RedirectToAction("Index", "Cart");
        }
        [HttpPost]
        public async Task<IActionResult> AddShippingAddress(CheckoutPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            currentUser.ShippingAddress = vm.ShippingAddress;
            await _userManager.UpdateAsync(currentUser);
            return RedirectToAction("Index", "Checkout");
        }

    }
}
