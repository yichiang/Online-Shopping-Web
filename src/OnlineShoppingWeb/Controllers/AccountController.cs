using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        private RoleManager<IdentityRole> _roleManager;

        private ProductDbContext _db;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ProductDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            RegisterViewModel model = new RegisterViewModel();
            model.RoleNames = _db.Roles.Select(x =>x.Name).ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            model.RoleNames = _db.Roles.Select(x => x.Name).ToList();
            var role = _db.Roles.FirstOrDefault(x => x.Name== model.RoleName);
            var foundRole = await _roleManager.FindByIdAsync(role.Id);

            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    IdentityUserRole<string> newUserRole = new IdentityUserRole<string>();
                    newUserRole.RoleId = role.Id;
                    newUserRole.UserId = user.Id;
                    //_db.UserRoles.Add(newUserRole);
                    //await _userManager.AddToRoleAsync(user, model.RoleName);
                    user.Roles.Add(newUserRole);
                    _db.SaveChanges();
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
            
           return View(model);
         
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
        [HttpGet]
        [Route("account/createRole")]
        public ActionResult CreateRole()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("account/createRole")]
        public ActionResult CreateRole(IdentityRole Role)
        {
            _db.Roles.Add(Role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
