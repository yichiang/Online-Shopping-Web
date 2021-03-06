﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using OnlineShoppingWeb.ApiModel;
using OnlineShoppingWeb.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using OnlineShoppingWeb.Enities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace OnlineShoppingWeb.Controllers.Api
{
    [Authorize]
    public class CartDataController : Controller
    {
        private IProductData _productData;
        private IShoppingCartData _shoppingCartData;
        private UserManager<User> _userManager;

        public async Task<CartModel> InitModel(string userId)
        {
            var vm = new CartModel();
            var currentUser = await _userManager.FindByIdAsync(userId);
            IEnumerable<ShoppingCart> allSavedProducts = _shoppingCartData.GetAllByUser(currentUser);
            List<Product> allSavedProduct = new List<Product>();
            foreach (var item in allSavedProducts)
            {
                item.Product.Quantity = item.Qty;
                allSavedProduct.Add(item.Product);
            }
            vm.Products = allSavedProduct;
            vm.totalPrice = vm.Products.Sum(p => p.Price * p.Quantity);
            vm.SaveForLaters = _shoppingCartData.GetAllSaveForLaterByUserId(userId);
            return vm;
        }
        public CartDataController(IShoppingCartData shoppingCartData, IProductData productData, UserManager<User> userManager)
        {
            _shoppingCartData = shoppingCartData;
            _productData = productData;
            _userManager = userManager;
        }
        [HttpGet("api/cart")]
        public async Task<IActionResult> Index(CartModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            vm = await InitModel(userId);
            //var currentUser = await _userManager.FindByIdAsync(userId);
            //IEnumerable<ShoppingCart> allSavedProducts = _shoppingCartData.GetAllByUser(currentUser);
            //List<Product> allSavedProduct = new List<Product>();
            //foreach (var item in allSavedProducts)
            //{
            //    item.Product.Quantity = item.Qty;
            //    allSavedProduct.Add(item.Product);
            //}
            //vm.Products = allSavedProduct;
            //vm.totalPrice = vm.Products.Sum(p => p.Price * p.Quantity);
            //vm.SaveForLaters = _shoppingCartData.GetAllSaveForLaterByUserId(userId);
            return Json(vm);
        }
        [HttpPost("api/saveForLater/{productId}")]
        public async Task<IActionResult> SaveForLater(int productId)
        {

            var vm = new CartModel();
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (_shoppingCartData.CheckIsExistedInList(productId, userId))
            {
                return Json(new { success = false, responseText = "The attached file is not supported." });
            }
            else
            {
                var foundShoppingProduct = _shoppingCartData.FindCartProductById(productId, userId);

                Product foundProduct = _productData.FindProductById(productId);
                _shoppingCartData.Delete(foundShoppingProduct);
                SaveForLater foundSaveForLater = _shoppingCartData.SaveForLater(productId, userId);
                vm = await InitModel(userId);
                return Json(vm);
            }
        }
        [HttpPost("api/delete/{productId}")]
        public async Task<IActionResult> DelteItem(int productId)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (_shoppingCartData.CheckIsExistedInList(productId, userId))
            {
                return Json(new { success = false, responseText = "The attached file is not supported." });
            }
            else
            {
                var foundShoppingProduct = _shoppingCartData.FindCartProductById(productId, userId);

                Product foundProduct = _productData.FindProductById(productId);
                _shoppingCartData.Delete(foundShoppingProduct);
                //will refactor just return sucess and using front-end to delete one item
                //vm = await InitModel(userId);
                return Json(new { success = true });
            }
        }

        [HttpPost("api/moveToCart/{productId}")]
        public async Task<IActionResult> MoveToCart(int productId)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _productData.SaveToCart(productId, userId);
            _shoppingCartData.DelteSaveToList(productId, userId);
            var vm = await InitModel(userId);
            return Json(vm);
        }

        [HttpPost("api/deleteItem/{productId}")]
        public async Task<IActionResult> DelteSaveForLaterItem(int productId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _shoppingCartData.DelteSaveToList(productId, userId);
            return Json(new { success = true });
        }

    }
}
    