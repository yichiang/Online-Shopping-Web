using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShoppingWeb.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentData _DepartmentData;

        public DepartmentController(IDepartmentData DepartmentData)
        {
            _DepartmentData = DepartmentData;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewModels.DepartmentViewModel viewModel = new ViewModels.DepartmentViewModel();
            viewModel.Departments = (IEnumerable<Department>)_DepartmentData.GetDepartments();

            return View(viewModel);
        }

        [HttpGet]
        [Route("Department/CreateDepartment")]
        public IActionResult CreateDepartment()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateDepartment(Department newDepartment)
        {

            if (ModelState.IsValid)
            {
                _DepartmentData.AddNewDepartment(newDepartment);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        [Route("department/{departmentId}")]
        public IActionResult DepartmentofSubDepartment(int departmentId)
        {
            ViewModels.DepartmentViewModel viewModel = new ViewModels.DepartmentViewModel();
            viewModel.SubDepartments = (IEnumerable<SubDepartment>)_DepartmentData.GetSubDepartmentByDepartmentId(departmentId);
            viewModel.DepartmentOfSub= _DepartmentData.GetDepartmentById(departmentId);
            return View(viewModel.SubDepartments.ToList());
        }
        [HttpGet]
        [Route("department/{departmentId}/AddSubDepartment")]
        public IActionResult AddSubDepartment(int departmentId)
        {
            ViewModels.DepartmentViewModel viewModel = new ViewModels.DepartmentViewModel();
            viewModel.DepartmentOfSub = _DepartmentData.GetDepartmentById(departmentId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddSubDepartment(SubDepartment newSubDepartment)
        {
            return View();
        }

        [Route("department/{departmentId}/AddSubDepartment/{subDepartmentId}")]
        public IActionResult allSubDepartmentProduct(int departmentId, int subdepartmentId)
        {

            return Content("I will create the list of products based on department soon");
        }
    }
}
