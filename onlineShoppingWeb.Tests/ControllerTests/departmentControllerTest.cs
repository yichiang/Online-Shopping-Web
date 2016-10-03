using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Controllers;
using OnlineShoppingWeb.Enities;
using Xunit;
using OnlineShoppingWeb.Services;
using OnlineShoppingWeb.ViewModels;

namespace onlineShoppingWeb.Tests.ControllerTests
{   
    public class DepartmentControllerTest
    {
 
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            DepartmentInMemoryData departmentdata = new DepartmentInMemoryData();
            InMemoryLaptopData LaptopData = new InMemoryLaptopData();
            //IDepartmentData departmentInMemorydata = (IDepartmentData) departmentdata;
            //Arrange
            DepartmentController controller = new DepartmentController(departmentdata, LaptopData);
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<DepartmentViewModel>(result);
        }

        [Fact]
        public void Get_Null_CreateDepartment_Test()
        {
            DepartmentInMemoryData departmentdata = new DepartmentInMemoryData();
            InMemoryLaptopData LaptopData = new InMemoryLaptopData();
            //IDepartmentData departmentInMemorydata = (IDepartmentData) departmentdata;
            //Arrange
            DepartmentController controller = new DepartmentController(departmentdata, LaptopData);
            IActionResult actionResult = controller.CreateDepartment();
            ViewResult indexView = controller.CreateDepartment() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.True(result== null);

        }

        [Fact]
        public void Get_ViewResult_DepartmentofSubDepartment_Test()
        {
            DepartmentInMemoryData departmentdata = new DepartmentInMemoryData();
            InMemoryLaptopData LaptopData = new InMemoryLaptopData();
            //IDepartmentData departmentInMemorydata = (IDepartmentData) departmentdata;
            //Arrange
            DepartmentController controller = new DepartmentController(departmentdata, LaptopData);
            IActionResult actionResult = controller.DepartmentofSubDepartment(3);
            ViewResult indexView = controller.DepartmentofSubDepartment(3) as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<DepartmentViewModel>(result);

        }

        [Fact]
        public void Get_ViewResult_allSubDepartmentProduct_Test()
        {
            DepartmentInMemoryData departmentdata = new DepartmentInMemoryData();
            InMemoryLaptopData LaptopData = new InMemoryLaptopData();
            //IDepartmentData departmentInMemorydata = (IDepartmentData) departmentdata;
            //Arrange
            DepartmentController controller = new DepartmentController(departmentdata, LaptopData);
            IActionResult actionResult = controller.allSubDepartmentProduct(3,2);
            ViewResult indexView = controller.allSubDepartmentProduct(3,2) as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<List<Laptop>>(result);

        }
    }
}
