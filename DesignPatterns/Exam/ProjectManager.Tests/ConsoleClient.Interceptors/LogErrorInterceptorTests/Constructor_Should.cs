using System;
using Moq;
using NUnit.Framework;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.Tests.ConsoleClient.Interceptors.LogErrorInterceptorTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrow_WhenGivenValidArguments()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var writer = new Mock<IWriter>();

            // Act & Assert
            Assert.DoesNotThrow(() => new LogErrorInterceptor(logger.Object, writer.Object));            
        }

        [Test]
        public void ThrowArgumentNullException_WhenGivenNullLogger()
        {
            // Arrange
            ILogger logger = null;
            var writer = new Mock<IWriter>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(logger, writer.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenGivenNullWriter()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            IWriter writer = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(logger.Object, writer));
        }
    }
}
