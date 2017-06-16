using System;
using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Core.Commands.Decorators.CacheableCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrow_WhenGivenValidArguments()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            // Act & Assert
            Assert.DoesNotThrow(() => new CacheableCommand(command.Object, cachingService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenGivenNullCommand()
        {
            // Arrange
            ICommand command = null;
            var cachingService = new Mock<ICachingService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(command, cachingService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenGivenNullCachingService()
        {
            // Arrange
            var command = new Mock<ICommand>();
            ICachingService cachingService = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(command.Object, cachingService));
        }
    }
}
