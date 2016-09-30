using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.Services;
using OnlineShoppingWeb.ViewModels;


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
        [Route("Department/{departmentId}")]
        public IActionResult DepartmentofSubDepartment(int departmentId)
        {
            ViewModels.DepartmentViewModel viewModel = new ViewModels.DepartmentViewModel();
            viewModel.SubDepartments = (IEnumerable<SubDepartment>)_DepartmentData.GetSubDepartmentByDepartmentId(departmentId);
            viewModel.DepartmentOfSub= _DepartmentData.GetDepartmentById(departmentId);
            return View(viewModel);
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
        [Route("department/{departmentId}/AddSubDepartment")]
        public IActionResult AddSubDepartment(int departmentId,DepartmentViewModel newDepartmentViewModel)
        {

            if (!string.IsNullOrEmpty(newDepartmentViewModel.SubDepartment.Description))
            {
                newDepartmentViewModel.SubDepartment.DepartmentId = departmentId;

                _DepartmentData.AddNewSubDepartment(newDepartmentViewModel.SubDepartment);
               return RedirectToAction("DepartmentofSubDepartment", new { departmentId = departmentId });

            }

            return Content("I will try to find a way to add to table ID "+ newDepartmentViewModel.SubDepartment.DepartmentId + "newDepartmentViewModel.SubDepartment Name" + newDepartmentViewModel.SubDepartment.Description);
        }

        [Route("department/{departmentId}/AddSubDepartment/{subDepartmentId}")]
        public IActionResult allSubDepartmentProduct(int departmentId, int subdepartmentId)
        {

            return Content("I will create the list of products based on department soon");
        }

        [HttpPost]
        [Route("department/EditDepartment/{departmentId}")]
        public IActionResult EditDepartment(int departmentId,DepartmentViewModel departmentViewModel)
        {

            if (!string.IsNullOrEmpty(departmentViewModel.Department.Description))
            {
                departmentViewModel.Department.DepartmentId =departmentId;
                _DepartmentData.EditDepartment(departmentViewModel.Department);
                return RedirectToAction("Index", "Department");

            }

            return Content("I will try to find a way to add to table ID " + departmentViewModel.Department.DepartmentId + "New Name Name" + departmentViewModel.Department.Description);
        }
        [HttpPost]
        [Route("department/deleteDepartment/{departmentId}")]
        public IActionResult DeleteDepartment(int departmentId)
        {
            _DepartmentData.DeleteDepartment(departmentId);
                return RedirectToAction("Index", "Department"); 
        }
        [HttpPost]
        [Route("department/deleteSubDepartment/{subDepartmentId}")]
        public IActionResult DeleteSubDepartment(int subDepartmentId, int DepartmentId)
        {

            _DepartmentData.DeleteSubDepartment(subDepartmentId);
            return RedirectToAction("DepartmentofSubDepartment", "Department", new { departmentId = DepartmentId });
        }


        [HttpPost]
        [Route("department/EditSubDepartment/{subDepartmentId}")]
        public IActionResult EditSubDepartment(int subDepartmentId, DepartmentViewModel departmentViewModel)
        {

            if (!string.IsNullOrEmpty(departmentViewModel.SubDepartment.Description))
            {
                departmentViewModel.SubDepartment.SubDepartmentId = subDepartmentId;
                _DepartmentData.EditSubDepartment(departmentViewModel.SubDepartment);
                return RedirectToAction("DepartmentofSubDepartment", "Department",new { departmentId = departmentViewModel.SubDepartment.DepartmentId });

            }

            return Content("I will try to find a way to add to table ID " + departmentViewModel.Department.DepartmentId + "New Name Name" + departmentViewModel.Department.Description);
        }
    }
  }

