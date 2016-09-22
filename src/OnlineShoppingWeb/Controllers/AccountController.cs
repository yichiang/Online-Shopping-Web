using Microsoft.AspNetCore.Mvc;


namespace OnlineShoppingWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
