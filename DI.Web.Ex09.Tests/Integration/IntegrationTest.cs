using System.Web.Mvc;
using DI.Web.Ex09.Controllers;
using DI.Web.Ex09.Repositories;
using DI.Web.Ex09.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DI.Web.Ex09.Tests.Integration
{
    [TestClass]
    public class IntegrationTest
    {
        private static HomeController _controller;
        private static SampleService _realService;
        private static Mock<IRepository<string>> _mockRepository;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _mockRepository = new Mock<IRepository<string>>();
            _mockRepository.Setup(x => x.Get(It.IsAny<int>())).Returns("This works");
            _realService = new SampleService(_mockRepository.Object);

            _controller = new HomeController(_realService);
        }

        [ClassCleanup]
        public static void Teardown()
        {
            _controller.Dispose();
        }

        [TestMethod]
        public void Index()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            _mockRepository.Verify(x => x.Get(It.IsAny<int>()), Times.AtLeastOnce);
            Assert.IsNotNull(result);
            Assert.AreEqual("ASP.NET This works", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Act
            var result = _controller.About() as ViewResult;

            // Assert
            _mockRepository.Verify(x => x.Get(It.IsAny<int>()), Times.AtLeastOnce);
            Assert.IsNotNull(result);
            Assert.AreEqual("Your application description page. This works", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Act
            var result = _controller.Contact() as ViewResult;

            // Assert
            _mockRepository.Verify(x => x.Get(It.IsAny<int>()), Times.AtLeastOnce);
            Assert.IsNotNull(result);
            Assert.AreEqual("Your contact page. This works", result.ViewBag.Message);
        }
    }
}
