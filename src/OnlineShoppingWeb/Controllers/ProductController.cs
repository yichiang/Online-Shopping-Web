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
        private IDepartmentData _DepartmentData;

        public ProductController(IProductData LaptopData, IDepartmentData DepartmentData)
        {
            _LaptopData = LaptopData;
            _DepartmentData = DepartmentData;
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
        public IActionResult CreateLaptop()
        {
            ViewModels.ProductPageViewModel viewModel = new ViewModels.ProductPageViewModel();
            viewModel.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateLaptop(ProductPageViewModel viewModel)
        {
            viewModel.Laptop.SubDepartment = _DepartmentData.GetSubDepartmentById(viewModel.Laptop.SubDepartmentId);
            if (ModelState.IsValid)
            {
                //Product newProduct = (Product) viewModel.Laptop;
                _LaptopData.AddNewProduct(viewModel.Laptop);
                return RedirectToAction("Index");

            }
            ViewModels.ProductPageViewModel newviewModel = new ViewModels.ProductPageViewModel();
            newviewModel.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(newviewModel);
        }
    }
}
