using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.Services;
using AutoMapper;

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
        public IActionResult Post([FromBody] Laptop theLaptop)
        {
            if (ModelState.IsValid)
            {
              var newLaptop = Mapper.Map<Laptop>(theLaptop);
                return Json(newLaptop);
            }
            return BadRequest(ModelState);

        }
    }
}
