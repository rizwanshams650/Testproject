using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Testproject.Controllers;
using Testproject.Models;
namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void EnterValue_Get_ReturnsView()
        {
            var controller = new HomeController();
            var result = controller.EnterValue() as ViewResult;
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName), "Expected default value is null or empty");
        }

        [Fact]
        public void EnterValue_Post_RedirectsToDisplayValue()
        {
            var controller = new HomeController();

            var mockTempData = new Mock<ITempDataDictionary>();
            controller.TempData = mockTempData.Object;
            var input = new UserInput { Value = "Test123" };

            //act
            var result = controller.EnterValue(input);
            mockTempData.VerifySet(t => t["UserValue"] = "Test123", Times.Once);
            //assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("DisplayValue", redirect.ActionName);
        }


        [Fact]
        public void DisplayValue_ReturnsView_WithValue()
        {
            var controller = new HomeController();

            var mockTempData = new Mock<ITempDataDictionary>();
            mockTempData.Setup(t => t["UserValue"]).Returns("UnitTestValue");
            controller.TempData = mockTempData.Object;

            var result = controller.DisplayValue() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("UnitTestValue", controller.ViewBag.UserValue);
        }
    }
}