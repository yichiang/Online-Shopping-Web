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
            if (vm.EventCommand == "list")
            {
                vm.AllProductsCount = _ProductData.GetAll().Count();
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
        public async Task<IActionResult> AddToCart(ClientProductPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var foundShoppingProduct = _shoppingCartData.FindCartProductById(vm.SaveToCartProductId, userId);
            if (foundShoppingProduct != null)
            {

                _shoppingCartData.ModifyQty(foundShoppingProduct, foundShoppingProduct.Qty + 1);
            }
            else
            {
                _ProductData.SaveToCart(vm.SaveToCartProductId, currentUser.Id);

            }
            vm.EventCommand = "list";
            var foundqQty = _shoppingCartData.GetUserTotalSavedItems(userId);
            return Json(new { qty= foundqQty });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Product(ClientProductPageViewModel vm)
        {
            int productId = vm.SaveToCartProductId;
            var temp2 = vm.ProductType;
     
            var foundProduct = _ProductData.FindProductByIdIncludedReview(productId);
            foundProduct.AvgCustomerReview = _ProductData.GetAverageReview(productId);
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
            return Json(new { review = vm.ProductReview });
        }
    }
}

