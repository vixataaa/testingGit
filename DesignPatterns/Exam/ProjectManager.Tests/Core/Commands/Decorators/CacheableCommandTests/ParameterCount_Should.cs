using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Core.Commands.Decorators.CacheableCommandTests
{
    [TestFixture]
    public class ParameterCount_Should
    {
        [Test]
        public void ReturnTheParameterCountOfThePassedCommand_WhenCalled()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            int commandParamCount = 4;

            command.Setup(x => x.ParameterCount)
                .Returns(commandParamCount);

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            int result = sut.ParameterCount;

            // Assert
            Assert.AreEqual(commandParamCount, result);
        }
    }
}
