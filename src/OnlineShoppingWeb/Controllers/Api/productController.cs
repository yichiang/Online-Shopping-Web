using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShoppingWeb.Controllers.Api
{
    public class ProductController : Controller
    {
        private IProductData _LaptopData;

        public ProductController(IProductData LaptopData)
        {
            _LaptopData = LaptopData;
        }

        [HttpGet("api/product")]
        public JsonResult Get()
        {
            return Json(_LaptopData.GetAll());
        }
        [HttpPost("api/product")]
        public IActionResult Post([FromBody] Product theLaptop)
        {
            return Json(theLaptop);
        }
    }
}
