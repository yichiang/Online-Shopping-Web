﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Controllers;
using OnlineShoppingWeb.Enities;
using Xunit;
namespace onlineShoppingWeb.Tests.ControllerTests
{   
    public class DepartmentControllerTest
    {
 
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            DepartmentController controller = new DepartmentController(IDepartmentData DepartmentInMemoryData);
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<List<Department>>(result);
        }
    }
}
