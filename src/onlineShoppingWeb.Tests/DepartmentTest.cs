using Xunit;
using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.Services;
namespace onlineShoppingWeb.Tests
{

        public class DepartmentTest
        {
            [Fact]
            public void GetDepartments()
            {
                //Arrange
                var newDepartment = new Department();

                //Act
                newDepartment.Description = "Electronic";
                var result = newDepartment.Description;
                //Assert
                Assert.Equal("Electronic", result);
            }
        }
    
}
