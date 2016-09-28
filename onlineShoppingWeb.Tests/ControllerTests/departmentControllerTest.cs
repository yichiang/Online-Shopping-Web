﻿using System.Collections.Generic;
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
            //IDepartmentData departmentInMemorydata = (IDepartmentData) departmentdata;
            //Arrange
            DepartmentController controller = new DepartmentController(departmentdata);
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<DepartmentViewModel>(result);
        }
    }
}