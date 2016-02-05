using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DI.Web.Ex09.Controllers;
using DI.Web.Ex09.Services;
using Moq;

namespace DI.Web.Ex09.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private static Mock<ISampleService> _mockService;

        [TestInitialize]
        public void Setup()
        {
            _mockService = new Mock<ISampleService>();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            _mockService
                .Setup(x => 
                x.GetMessage(It.IsAny<int>())).Returns("This works");

            var controller = new HomeController(_mockService.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            _mockService
                .Verify(x => x.GetMessage(It.IsAny<int>()), Times.Once());

            Assert.IsNotNull(result);
            Assert.AreEqual("This works", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            _mockService.Setup(x => x.GetMessage(It.IsAny<int>())).Returns("This works, too!");
            var controller = new HomeController(_mockService.Object);

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            _mockService.Verify(x => x.GetMessage(It.IsAny<int>()), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual("This works, too!", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            _mockService.Setup(x => x.GetMessage(It.IsAny<int>())).Returns("This works as well!");
            var controller = new HomeController(_mockService.Object);

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            _mockService.Verify(x => x.GetMessage(3), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual("This works as well!", result.ViewBag.Message);
        }
    }
}
