using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using OnlineShoppingWeb.ViewModels;
using OnlineShoppingWeb.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using OnlineShoppingWeb.Enities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace OnlineShoppingWeb.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private IShoppingCartData _shoppingCartData;
        private UserManager<User> _userManager;

        public CartController(IShoppingCartData shoppingCartData, UserManager<User> userManager)
        {
            _shoppingCartData = shoppingCartData;
            _userManager = userManager;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index(CartPageViewModel vm)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            return View(vm);
        }

    }
}
