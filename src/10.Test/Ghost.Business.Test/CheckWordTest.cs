using Ghost.Data.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ghost.Business.Test
{
    [TestClass]
    public class CheckWordTest
    {
        private readonly Mock<IGhostRepository> mockGhostRepository = new Mock<IGhostRepository>();

        [TestMethod]
        public void CheckWord_Business_Success()
        {
        }

        public CheckWord CreateSut()
        {
            return new CheckWord(
                this.mockGhostRepository.Object);
        }
    }
}
