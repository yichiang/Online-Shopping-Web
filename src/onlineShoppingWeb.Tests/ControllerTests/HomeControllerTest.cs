using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWeb.Controllers;
using OnlineShoppingWeb.Enities;
using Xunit;
namespace onlineShoppingWeb.Tests.ControllerTests
{   
    public class HomeControllerTest
    {
 
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            HomeController controller = new HomeController();
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
