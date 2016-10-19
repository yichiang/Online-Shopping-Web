using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Services;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace OnlineShoppingWeb.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private IProductData _ProductData;
        private IDepartmentData _DepartmentData;
        private IHostingEnvironment _env;
        private UserManager<User> _userManager;
        private IShoppingCartData _shoppingCartData;

        public ClientController(IProductData LaptopData, IDepartmentData DepartmentData,IShoppingCartData shoppingCartData, IHostingEnvironment env, UserManager<User> userManager)
        {
            _ProductData = LaptopData;
            _DepartmentData = DepartmentData;
            _shoppingCartData = shoppingCartData;
            _env = env;
            _userManager = userManager;
        }
        // GET: /<controller>/

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(ClientProductPageViewModel vm)
        {
            vm.AllProductsCount = _ProductData.GetAll().Count();

            if (vm.EventCommand == "list")
            {
                vm.IsListAreaVisible = true;
                vm.IsSearchAreaVisible = true;
                vm.Products = _ProductData.GetPorductsofNum(vm.SkipDisplayList, vm.TakeDisplayList);
            }
            else if (vm.EventCommand == "search")
            {
                vm.IsListAreaVisible = true;
                vm.IsSearchAreaVisible = true;

                vm.Products = _ProductData.SearchByTitle(vm.ProductSearchName);
                vm.AllProductsCount = vm.Products.Count();

            }

          
            return View(vm);


    }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(ClientProductPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            vm.EventCommand = "list";
            if (!string.IsNullOrEmpty(userId))
            {
                var currentUser = await _userManager.FindByIdAsync(userId);
                var foundProduct = _ProductData.FindProductById(vm.SaveToCartProductId);
                var foundShoppingProduct = _shoppingCartData.FindCartProductById(vm.SaveToCartProductId, userId);

                //if shopping cart dosen't have this product and product inventory is greater than 0
                //simply save to cart
                if (foundShoppingProduct == null && foundProduct.Quantity > 0)
                {

                    _ProductData.SaveToCart(vm.SaveToCartProductId, currentUser.Id);
                    var foundqQty = _shoppingCartData.GetUserTotalSavedItems(userId);
                    return Json(new { success = true, message = "Add To Our Cart Now", qty = foundqQty });
                }
                //if we don't have any instcok or custom already put all qty in her/his cart
                //we don't nothing
                else if (foundProduct.Quantity == 0 || foundProduct.Quantity == foundShoppingProduct.Qty)
                {
                    vm.EventCommand = "list";
                    var foundqQty = _shoppingCartData.GetUserTotalSavedItems(userId);
                    return Json(new { success = false, message = "We don't have too much in stock for now", qty = foundqQty });

                }
                else
                {
                    _shoppingCartData.ModifyQty(foundShoppingProduct, foundShoppingProduct.Qty + 1);
                    var foundqQty = _shoppingCartData.GetUserTotalSavedItems(userId);
                    return Json(new { success = true, message = "You already add this in your cart. I add one more qty for you", qty = foundqQty });
                }

            }
            else
            {
                return Json(new { success = false, message = "Please Login in first", qty = 0 });

            }


        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Product(ClientProductPageViewModel vm)
        {
            int productId = vm.SaveToCartProductId;
            var temp2 = vm.ProductType;
     
            var foundProduct = _ProductData.FindProductByIdIncludedReview(productId);
            //foundProduct.AvgCustomerReview = _ProductData.GetAverageReview(productId);
            vm.Product = foundProduct;

            if (temp2 == "Laptop")
            {
                vm.Laptop = (Laptop)foundProduct;
            }
            else if (temp2 == "Phone")
            {
                vm.Phone = (Phone)foundProduct;
            }
            return View(vm);
        }

        [HttpPost]
        public  IActionResult Review(ClientProductPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            vm.ProductReview.UserId = userId;
            _ProductData.SaveReview(vm.ProductReview);
            var newReviewScore = _ProductData.GetAverageReview(vm.ProductReview.ProductId);
            _ProductData.SaveAverageScore(vm.ProductReview.ProductId, newReviewScore);
            return Json(new {score = newReviewScore,review = vm.ProductReview });
        }

        [HttpPost]
        public async Task<IActionResult> AddMeToMailList(ClientProductPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            SendEmailService oneEmail = new SendEmailService();
            await oneEmail.SendEmailAsync(vm.MailEmailAddress, "Join us Today","Thanks you for join us");
            return Json(new { message = "Success" });
        }
    }
}

