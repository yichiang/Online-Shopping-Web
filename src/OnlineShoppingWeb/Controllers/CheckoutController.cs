using System;
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
using Stripe;

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
                item.Proudct.Quantity = item.Qty;
                vm.Total += item.Proudct.Quantity * item.Proudct.Price;
                allSavedProduct.Add(item.Proudct);
            }
            vm.Products = allSavedProduct;
            if (!string.IsNullOrEmpty(currentUser.ShippingAddress))
            {
                vm.ShippingAddress = currentUser.ShippingAddress;
            }

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> PlaceOrder(CheckoutPageViewModel vm)
        {
            //Find UserId
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //Find User Object
            var currentUser = await _userManager.FindByIdAsync(userId);
            //Find all CartItem and ready to process checkout
            IEnumerable<ShoppingCart> allSavedProducts = _shoppingCartData.GetAllByUser(currentUser);
            //Find all Product Detail by viewing cart
            List<Product> allSavedProduct = new List<Product>();
            foreach (var item in allSavedProducts)
            {
                //Change Item.Product qty to user's intended purchase qty
                item.Proudct.Quantity = item.Qty;
                //add modified-Qty Product to list of products
                allSavedProduct.Add(item.Proudct);
            }
            ShoppingOrder newOrder = new ShoppingOrder();
            newOrder.User = currentUser;
            newOrder.OrderAddress = vm.ShippingAddress;
            _checkoutData.SaveOrder(newOrder);

            foreach (var product in allSavedProduct)
            {
                OrderItem Item = new OrderItem();
                Item.CurrentPrice = product.Price;
                Item.ProductId = product.ProductId;
                Item.Qty = product.Quantity;
                Item.ShoppingOrderId = newOrder.OrderId;
                //Modify Inventory of Product Qty

                product.Quantity -= Item.Qty;
                if (product.Quantity == 0)
                {
                    //If user bought all stocks, change property of availiablity to false
                    product.IsAvailiable = false;
                }
                _productData.EditQty(product);
                _checkoutData.SaveOrderItem(Item);

            }
            //Delete all item in shopping cart
            foreach (var product in allSavedProducts)
            {
                
                _shoppingCartData.Delete(product);
            }
            var myCharge = new StripeChargeCreateOptions();

            // always set these properties
            myCharge.Amount = 100;
            myCharge.Currency = "usd";

            // set this if you want to
            myCharge.Description = "Charge it like it's hot";

            myCharge.SourceTokenOrExistingSourceId = vm.StripeToken;

            // set this property if using a customer - this MUST be set if you are using an existing source!


            // (not required) set this to false if you don't want to capture the charge yet - requires you call capture later
            myCharge.Capture = true;

   
            var StripeKey = Environment.GetEnvironmentVariable("StripeSecretKey");
            var chargeService = new StripeChargeService(StripeKey);
            StripeCharge stripeCharge = chargeService.Create(myCharge);
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
