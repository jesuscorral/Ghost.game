using Ghost.Host.Mvc;
using Ghost.Service.Interface;
using Ghost.Service.Interface.Request;
using Ghost.Service.Interface.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace GhostHost.Mvc.Test
{
    [TestClass]
    public class GhostControllerTest
    {
        private readonly Mock<IGhostService> mockGhostService = new Mock<IGhostService>();

        [TestMethod]
        public async Task GhostController_CheckWordSuccess()
        {
            // Arrange 
            var request = new CheckWordRequest();
            this.mockGhostService
                .Setup(s => s.CheckWordAsync(request))
                .ReturnsAsync(new CheckWordResponse())
                .Verifiable();

            var sut = this.CreateSut();

            // Act
            var result = await sut.CheckWord(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(JsonResult));
            this.mockGhostService.VerifyAll();
        }

        public GhostController CreateSut()
        {
            return new GhostController(
                this.mockGhostService.Object);
        }
    }
}
