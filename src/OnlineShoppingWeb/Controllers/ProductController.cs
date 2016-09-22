using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Services;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShoppingWeb.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductData _LaptopData;

        public ProductController(IProductData LaptopData)
        {
            _LaptopData = LaptopData;
        }
        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewModels.ProductPageViewModel viewModel = new ViewModels.ProductPageViewModel();
            viewModel.Laptops = (IEnumerable<Laptop>) _LaptopData.GetAll();
    
            return View(viewModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreateLaptop()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateLaptop(Laptop newLaptop)
        {
            Console.WriteLine(newLaptop);
            Console.WriteLine(ModelState.IsValid);

            if (ModelState.IsValid)
            {
                _LaptopData.AddNewProduct(newLaptop);
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
