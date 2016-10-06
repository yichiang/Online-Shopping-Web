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
    public class ClientController : Controller
    {
        private IProductData _ProductData;
        private IDepartmentData _DepartmentData;
        private IHostingEnvironment _env;

        public ClientController(IProductData LaptopData, IDepartmentData DepartmentData, IHostingEnvironment env)
        {
            _ProductData = LaptopData;
            _DepartmentData = DepartmentData;
            _env = env;
        }
        // GET: /<controller>/

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Index(ClientProductPageViewModel vm)
        {
            if (vm.EventCommand == "list")
            {
                vm.IsListAreaVisible = true;
                vm.IsSearchAreaVisible = true;
                vm.IsAddPhoneFormAreaVisible = false;
                vm.IsAddLaptopFormAreaVisible = false;
                vm.Products = _ProductData.GetAll();
            }
            else if (vm.EventCommand == "search")
            {
                vm.IsListAreaVisible = true;
                vm.IsSearchAreaVisible = true;
                vm.IsAddPhoneFormAreaVisible = false;
                vm.IsAddLaptopFormAreaVisible = false;
                vm.Products = _ProductData.SearchByTitle(vm.ProductSearchName);

            }
            else if (vm.EventCommand == "addToCart")
            {
                vm.IsListAreaVisible = true;
                vm.IsSearchAreaVisible = true;
                vm.IsAddPhoneFormAreaVisible = false;
                vm.IsAddLaptopFormAreaVisible = false;
                vm.Products = _ProductData.GetAll();

            }
            else if (vm.EventCommand == "viewDetail")
            {
                vm.IsListAreaVisible = false;
                vm.IsSearchAreaVisible = false;
                vm.IsAddPhoneFormAreaVisible = false;
                vm.IsAddLaptopFormAreaVisible = true;

                vm.Products = _ProductData.GetAll();

            }
            vm.SubDepartments = _DepartmentData.GetAllSubDepartments();
            return View(vm);
        }


        
    }
}

