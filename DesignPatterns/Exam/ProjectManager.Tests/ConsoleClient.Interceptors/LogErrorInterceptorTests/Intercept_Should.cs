using System;
using Moq;
using Ninject.Extensions.Interception;
using NUnit.Framework;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.Tests.ConsoleClient.Interceptors.LogErrorInterceptorTests
{
    [TestFixture]
    public class Intercept_Should
    {
        [Test]
        public void ShouldCallInvocationProceed_WhenInvocationDoesNotThrow()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var writer = new Mock<IWriter>();

            var invocation = new Mock<IInvocation>();

            invocation.Setup(i => i.Proceed());                

            var sut = new LogErrorInterceptor(logger.Object, writer.Object);

            // Act
            sut.Intercept(invocation.Object);

            // Assert
            invocation.Verify(i => i.Proceed(), Times.Once);
        }

        [Test]
        public void CallLoggedErrorWithExceptionMessage_WhenProceedThrowsGenericException()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var writer = new Mock<IWriter>();

            var invocation = new Mock<IInvocation>();

            var exception = new Exception("Generic");

            invocation.Setup(i => i.Proceed())
                .Throws(exception);

            var sut = new LogErrorInterceptor(logger.Object, writer.Object);

            // Act
            sut.Intercept(invocation.Object);

            // Assert
            logger.Verify(l => l.Error("Generic"), Times.Once);
        }

        [Test]
        public void CallWriterWriteLineWithOppsSmthHappened_WhenProceedThrowsGenericException()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var writer = new Mock<IWriter>();

            var invocation = new Mock<IInvocation>();

            var exception = new Exception("Generic");

            invocation.Setup(i => i.Proceed())
                .Throws(exception);

            var sut = new LogErrorInterceptor(logger.Object, writer.Object);

            // Act
            sut.Intercept(invocation.Object);

            // Assert
            writer.Verify(w => w.WriteLine(It.Is<string>(s => s.Contains("something happened"))), Times.Once);
        }

        [Test]
        public void CallLoggerErrorWithExceptionMessage_WhenUserValidationExceptionOccurs()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var writer = new Mock<IWriter>();

            var invocation = new Mock<IInvocation>();

            var exception = new UserValidationException("User");

            invocation.Setup(i => i.Proceed())
                .Throws(exception);

            var sut = new LogErrorInterceptor(logger.Object, writer.Object);

            // Act
            sut.Intercept(invocation.Object);

            // Assert
            logger.Verify(l => l.Error("User"), Times.Once);
        }

        [Test]
        public void CallWriterWriteLineWithExceptionMessage_WhenUserValidationExceptionOccurs()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var writer = new Mock<IWriter>();

            var invocation = new Mock<IInvocation>();

            var exception = new UserValidationException("User");

            invocation.Setup(i => i.Proceed())
                .Throws(exception);

            var sut = new LogErrorInterceptor(logger.Object, writer.Object);

            // Act
            sut.Intercept(invocation.Object);

            // Assert
            writer.Verify(w => w.WriteLine("User"), Times.Once);
        }
    }
}
