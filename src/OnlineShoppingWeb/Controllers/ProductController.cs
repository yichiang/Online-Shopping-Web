using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Services;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Net.Http.Headers;

namespace OnlineShoppingWeb.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductData _LaptopData;
        private IDepartmentData _DepartmentData;
        private IHostingEnvironment _env;

        public ProductController(IProductData LaptopData, IDepartmentData DepartmentData, IHostingEnvironment env)
        {
            _LaptopData = LaptopData;
            _DepartmentData = DepartmentData;
            _env = env;
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
        [HttpGet]
        [AllowAnonymous]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UploadFile(ICollection<IFormFile> filesInput)
        {
            var usersfiles = HttpContext.Request.Form.Files;

            var uploads = Path.Combine(_env.WebRootPath, "uploads");
            foreach (var file in usersfiles)
            {
                if (file.Length >0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        //await file.CopyToAsync(fileStream);
                        //file.SaveAs(uploads);

                        file.CopyTo(fileStream);

                    }
                }
            }
            return View();
        }
    }
}

