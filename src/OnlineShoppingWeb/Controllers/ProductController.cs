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


namespace OnlineShoppingWeb.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductData _ProductData;
        private IDepartmentData _DepartmentData;
        private IHostingEnvironment _env;

        public ProductController(IProductData LaptopData, IDepartmentData DepartmentData, IHostingEnvironment env)
        {
            _ProductData = LaptopData;
            _DepartmentData = DepartmentData;
            _env = env;
        }


        [HttpGet]
        [AllowAnonymous]

        public IActionResult Index(ProductPageViewModel vm)
        {
            

            if (vm.EventCommand == "list")
            {
                vm.AllProductsCount = _ProductData.GetAll().Count();
                vm.IsListAreaVisible = true;
                vm.IsSearchAreaVisible = true;
                vm.IsAddPhoneFormAreaVisible = false;
                vm.IsAddLaptopFormAreaVisible = false;
                vm.Products = _ProductData.GetPorductsofNum(vm.SkipDisplayList, vm.TakeDisplayList);

            }
            else if (vm.EventCommand == "search")
            {
                vm.IsListAreaVisible = true;
                vm.IsSearchAreaVisible = true;
                vm.IsAddPhoneFormAreaVisible = false;
                vm.IsAddLaptopFormAreaVisible = false;
                vm.Products = _ProductData.SearchByTitle(vm.ProductSearchName);
                vm.AllProductsCount = vm.Products.Count();


            }
            else if (vm.EventCommand == "addPhone")
            {
                vm.IsListAreaVisible = false;
                vm.IsSearchAreaVisible = false;
                vm.IsAddPhoneFormAreaVisible = true;

            }
            else if (vm.EventCommand == "addLaptop")
            {
                vm.IsListAreaVisible = false;
                vm.IsSearchAreaVisible = false;
                vm.IsAddPhoneFormAreaVisible = false;
                vm.IsAddLaptopFormAreaVisible = true;

                vm.Products = _ProductData.GetAll();

            }

            else if (vm.EventCommand.Contains("editPhone"))
            {
                string productID = vm.EventCommand.Replace("editPhone/", "");
                vm.Phone = (Phone)_ProductData.FindProductById(int.Parse(productID));
                vm.IsListAreaVisible = false;
                vm.IsSearchAreaVisible = false;
                vm.IsAddPhoneFormAreaVisible = false;
                vm.IsEditLaptopFormAreaVisible = false;
                vm.IsEditPhoneFormAreaVisible = true;

            }
            else if (vm.EventCommand.Contains("editLaptop"))
            {
                string productID = vm.EventCommand.Replace("editLaptop/", "");
                vm.Laptop = (Laptop) _ProductData.FindProductById(int.Parse(productID));
                vm.IsListAreaVisible = false;
                vm.IsSearchAreaVisible = false;
                vm.IsAddPhoneFormAreaVisible = false;
                vm.IsAddLaptopFormAreaVisible = false;
                vm.IsEditLaptopFormAreaVisible = true;

            }

            vm.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(vm);
        }


        [HttpGet]
        public IActionResult CreateLaptop()
        {
            ProductPageViewModel viewModel = new ProductPageViewModel();
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
                _ProductData.AddNewProduct(viewModel.Laptop);
                return RedirectToAction("Index");

            }
            ProductPageViewModel newviewModel = new ProductPageViewModel();
            newviewModel.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(newviewModel);
        }

        [HttpPost]
        [Route("product/DeleteProduct")]
        public IActionResult Delete(ProductPageViewModel viewModel)
        {
            _ProductData.DeleteProduct(viewModel.Product.ProductId);
 
            return RedirectToAction("Index");

        }
        [HttpPost]
        [Route("product/EditLaptop")]
        public IActionResult EditLaptop(ProductPageViewModel viewModel)
        {
            _ProductData.Edit(viewModel.Laptop);
            return RedirectToAction("Index");

        }
        [HttpPost]
        [Route("product/EditPhone")]
        public IActionResult EditPhone(ProductPageViewModel viewModel)
        {
            _ProductData.Edit(viewModel.Phone);
            return RedirectToAction("Index");

        }

        [HttpPost]
        [Route("product/EditQty")]
        public IActionResult EditQty(ProductPageViewModel viewModel)
        {
            if (viewModel.Product.Quantity >= 0)
            {
                _ProductData.EditQty(viewModel.Product);

            }
            return RedirectToAction("Index");

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
                        await file.CopyToAsync(fileStream);
                        file.CopyTo(fileStream);

                    }
                }
            }
            return View();
        }

        //Phone
        [HttpGet]
        public IActionResult CreatePhone()
        {
            ProductPageViewModel viewModel = new ProductPageViewModel();
            viewModel.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreatePhone(ProductPageViewModel viewModel)
        {
            viewModel.Phone.SubDepartment = _DepartmentData.GetSubDepartmentById(viewModel.Phone.SubDepartmentId);
            if (ModelState.IsValid)
            {
                _ProductData.AddNewProduct(viewModel.Phone);
                return RedirectToAction("Index");

            }
            ProductPageViewModel newviewModel = new ProductPageViewModel();
            newviewModel.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(newviewModel);
        }


    }
}

