using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private ProductDbContext _db;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ProductDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AllUsers()
        {
            return View(_db.Users.ToList());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return View("Index", "Account");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            
           return View();
         
        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult Login(string returnUrl="")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");

                    }
                }
            
            }
            ModelState.AddModelError("", "Invalid Password Attemp");
                return View(model);
        }

        // GET: /Roles/Create
        public ActionResult CreateRole()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult CreateRole(FormCollection collection)
        {

            try
            {
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [Route("user/delete/{id}")]
        public ActionResult DeleteUser(string id)
        {

            //Only SuperAdmin or Admin can delete users (Later when implement roles)

            User appUser =  _db.Users.FirstOrDefault(user => user.Id == id);

            if (appUser != null)
            {
                var result = _db.Users.Remove(appUser);

                return Ok();

            }

            return NotFound();

        }
    }
}
