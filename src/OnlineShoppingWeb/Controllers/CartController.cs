﻿using Microsoft.AspNetCore.Mvc;
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
            
            foreach (var item in allSavedProducts)
            {
                vm.Products.ToList().Add(_productData.FindProductById(item.ProductId));
            }

            return View(vm);
        }

    }
}