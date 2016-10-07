using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Services;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace OnlineShoppingWeb.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private IProductData _ProductData;
        private IDepartmentData _DepartmentData;
        private IHostingEnvironment _env;
        private UserManager<User> _userManager;

        public ClientController(IProductData LaptopData, IDepartmentData DepartmentData, IHostingEnvironment env, UserManager<User> userManager)
        {
            _ProductData = LaptopData;
            _DepartmentData = DepartmentData;
            _env = env;
            _userManager = userManager;
        }
        // GET: /<controller>/

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(ClientProductPageViewModel vm)
        {
            var temp = vm.EventCommand;
            if (vm.EventCommand == "list")
            {
                vm.IsListAreaVisible = true;
                vm.IsSearchAreaVisible = true;
                vm.IsDetailAreaVisible = false;
                vm.Products = _ProductData.GetAll();
            }
            else if (vm.EventCommand == "search")
            {
                vm.IsListAreaVisible = true;
                vm.IsSearchAreaVisible = true;
                vm.IsDetailAreaVisible = false;

                vm.Products = _ProductData.SearchByTitle(vm.ProductSearchName);

            }
      
            else if (vm.EventCommand == "detail")
            {
                vm.IsListAreaVisible = false;
                vm.IsSearchAreaVisible = false;
                vm.IsDetailAreaVisible = true;

                vm.Products = _ProductData.GetAll();

            }
            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(ClientProductPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            _ProductData.SaveToCart(vm.SaveToCartProductId, currentUser);
            vm.EventCommand = "list";
            return RedirectToAction("Index",vm);
        }


    }
}

