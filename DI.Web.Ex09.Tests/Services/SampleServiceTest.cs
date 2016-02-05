using DI.Web.Ex09.Repositories;
using DI.Web.Ex09.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DI.Web.Ex09.Tests.Services
{
    [TestClass]
    public class SampleServiceTest
    {
        private static Mock<IRepository<string>> _mockRepository;
        private int _messageID;
        private SampleService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository<string>>();
            _mockRepository.Setup(x => x.Get(It.IsAny<int>())).Returns("This works");
            _service = new SampleService(_mockRepository.Object);
        }

        [TestMethod]
        public void ItReturnsMessageForOne()
        {
            // Arrange
            _messageID = 1;
            
            // Act
            var result = _service.GetMessage(_messageID);

            // Assert
            _mockRepository.Verify(x => x.Get(_messageID), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual("ASP.NET This works", result);
        }

        [TestMethod]
        public void ItReturnsMessageForTwo()
        {
            // Arrange
            _messageID = 2;

            // Act
            var result = _service.GetMessage(_messageID);

            // Assert
            _mockRepository.Verify(x => x.Get(_messageID), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual("Your application description page. This works", result);
        }

        [TestMethod]
        public void ItReturnsMessageForThree()
        {
            // Arrange
            _messageID = 3;

            // Act
            var result = _service.GetMessage(_messageID);

            // Assert
            _mockRepository.Verify(x => x.Get(_messageID), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual("Your contact page. This works", result);
        }

        [TestMethod]
        public void ItReturnsEmptyForFour()
        {
            // Arrange
            _messageID = 4;

            // Act
            var result = _service.GetMessage(_messageID);

            // Assert
            _mockRepository.Verify(x => x.Get(It.IsAny<int>()), Times.Never);
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }
    }
}
