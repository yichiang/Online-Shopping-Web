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
using Microsoft.AspNet.Http;

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

        public IActionResult Index(ManagerProductViewModel vm)
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
            ManagerProductViewModel viewModel = new ManagerProductViewModel();
            viewModel.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLaptop(ManagerProductViewModel viewModel, ICollection<Microsoft.AspNet.Http.IFormFile> UploadFile)
        {
            viewModel.Laptop.SubDepartment = _DepartmentData.GetSubDepartmentById(viewModel.Laptop.SubDepartmentId);
            var usersfiles = HttpContext.Request.Form.Files;

            if (ModelState.IsValid)
            {

                foreach (var file in usersfiles)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    if (fileName.EndsWith(".jpg"))
                    {
                        var filePath = _env.ContentRootPath + "\\wwwroot\\" + fileName;
                        await file.CopyToAsync(new FileStream(Path.Combine(Path.Combine(_env.WebRootPath, "uploads"), file.FileName), FileMode.Create));
                    }

                }

                //Product newProduct = (Product) viewModel.Laptop;
                _ProductData.AddNewProduct(viewModel.Laptop);
                return RedirectToAction("Index");

            }

            ManagerProductViewModel newviewModel = new ManagerProductViewModel();
            newviewModel.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(newviewModel);
        }

        [HttpPost]
        [Route("product/DeleteProduct")]
        public IActionResult Delete(ManagerProductViewModel viewModel)
        {
            _ProductData.DeleteProduct(viewModel.Product.ProductId);
 
            return RedirectToAction("Index");

        }
        [HttpPost]
        [Route("product/EditLaptop")]
        public IActionResult EditLaptop(ManagerProductViewModel viewModel)
        {
            _ProductData.Edit(viewModel.Laptop);
            return RedirectToAction("Index");

        }
        [HttpPost]
        [Route("product/EditPhone")]
        public IActionResult EditPhone(ManagerProductViewModel viewModel)
        {
            _ProductData.Edit(viewModel.Phone);
            return RedirectToAction("Index");

        }

        [HttpPost]
        [Route("product/EditQty")]
        public IActionResult EditQty(ManagerProductViewModel viewModel)
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
        public async Task<IActionResult> UploadFile(ICollection<Microsoft.AspNetCore.Http.IFormFile> filesInput)
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
            ManagerProductViewModel viewModel = new ManagerProductViewModel();
            viewModel.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreatePhone(ManagerProductViewModel viewModel)
        {
            viewModel.Phone.SubDepartment = _DepartmentData.GetSubDepartmentById(viewModel.Phone.SubDepartmentId);
            if (ModelState.IsValid)
            {
                _ProductData.AddNewProduct(viewModel.Phone);
                return RedirectToAction("Index");

            }
            ManagerProductViewModel newviewModel = new ManagerProductViewModel();
            newviewModel.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(newviewModel);
        }


    }
}

