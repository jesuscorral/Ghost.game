using AutoMapper;
using Ghost.Business;
using Ghost.Business.Interface;
using Ghost.Core.Exceptions;
using Ghost.Service.Interface.Request;
using Ghost.Service.Interface.Response;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Ghost.Data;
using Ghost.Data.Interface;

namespace Ghost.Service.Test
{
    [TestClass]
    public class GhostServiceTest
    {
        private readonly Mock<IServiceProvider> mockServiceProvider = new Mock<IServiceProvider>();
        private readonly Mock<ILogger<GhostService>> mockGhostServiceLogger = new Mock<ILogger<GhostService>>();
        private readonly Mock<IMapper> mockmapper = new Mock<IMapper>();
        private Mock<ICheckWord> mockCheckWord = new Mock<ICheckWord>();
        private readonly IGhostRepository ghostRepository;

        [TestMethod]
        public async Task CheckWord_Transaction_Not_Found()
        {
            
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(ICheckWord)))
                .Returns(new CheckWord(ghostRepository));

            
        var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);

            var serviceScopeFactory = new Mock<IServiceScopeFactory>();
            serviceScopeFactory
                .Setup(x => x.CreateScope())
                .Returns(serviceScope.Object);

            serviceProvider
                .Setup(x => x.GetService(typeof(IServiceScopeFactory)))
                .Returns(serviceScopeFactory.Object);
            
            var request = new CheckWordRequest
            {
                Round = 1,
                Turn = Interface.Enums.Enum.Player.Human,
                Word = "ac"
            };
        
            var sut = this.CreateSut();

            // Act
            async Task fn()
            {
                var response = await sut.CheckWordAsync(request);
            }

            // Assert
            await Assert.ThrowsExceptionAsync<TransactionNotFoundException>(fn);
            this.mockServiceProvider.Verify();
            this.mockGhostServiceLogger.VerifyAll();
            this.mockmapper.VerifyAll();
        }

        [TestMethod]
        public async Task CheckWord_When_Request_Is_Null()
        {
            // Arrange
            var sut = this.CreateSut();

            // Act
            async Task fn()
            {
                var response = await sut.CheckWordAsync(null);
            }

            // Assert
            await Assert.ThrowsExceptionAsync<NullRequestException<CheckWordRequest>>(fn);
        }

        public GhostService CreateSut()
        {
            return new GhostService(
                this.mockGhostServiceLogger.Object,
                this.mockServiceProvider.Object,
                this.mockmapper.Object);
        }
    }
}
