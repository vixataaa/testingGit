using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Core.Commands.Decorators.CacheableCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void CallCachingServiceResetCache_WhenCacheIsExpired()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            string methodName = "execute";

            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(true);

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            sut.Execute(new List<string>());

            // Assert
            cachingService.Verify(cs => cs.ResetCache(), Times.Once);
        }

        [Test]
        public void CallTheCommandExecute_WhenCacheIsExpired()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();


            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(true);

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            sut.Execute(new List<string>());

            // Assert
            command.Verify(c => c.Execute(It.IsAny<List<string>>()), Times.Once);
        }

        [Test]
        public void CallCachingServiceAddCacheValue_WithMethodNameExecuteAndCommandExecutionResult_WhenCacheIsExpired()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            string methodName = "execute";
            string className = "SomeCommand";

            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(true);

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            sut.Execute(new List<string>());

            // Assert
            cachingService.Verify(cs => cs.AddCacheValue(It.IsAny<string>(), methodName, "executed"),
                Times.Once);
        }

        [Test]
        public void CallCachingServiceGetCacheValueWithProperValues_WhenCacheIsExpired()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            string methodName = "execute";
            string className = "SomeCommand";

            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(true);

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            sut.Execute(new List<string>());

            // Assert
            cachingService.Verify(cs => cs.GetCacheValue(It.IsAny<string>(), methodName), Times.Once);
        }

        [Test]
        public void CallCachingServiceGetCacheValueWithProperValues_WhenCacheIsNotExpired()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            string methodName = "execute";
            string className = "SomeCommand";

            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(false);

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            sut.Execute(new List<string>());

            // Assert
            cachingService.Verify(cs => cs.GetCacheValue(It.IsAny<string>(), methodName), Times.Once);
        }

        [Test]
        public void CallCachingServiceAddValue_WhenCacheIsNotExpiredButValueDoesntExist()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            string methodName = "execute";
            string className = "SomeCommand";

            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(false);

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<KeyNotFoundException>();

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            sut.Execute(new List<string>());

            // Assert
            cachingService.Verify(cs => cs.AddCacheValue(It.IsAny<string>(), methodName, "executed"),
                Times.Once);
        }

        [Test]
        public void CallCommandExecute_WhenCacheIsNotExpiredButValueDoesNotExist()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            string methodName = "execute";
            string className = "SomeCommand";

            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(false);

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<KeyNotFoundException>();

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            sut.Execute(new List<string>());

            // Assert
            command.Verify(c => c.Execute(It.IsAny<List<string>>()), Times.Once);
        }

        /// <summary>
        /// Tests whether cached result is returned by not calling the inner command`s execute
        /// </summary>
        [Test]
        public void NotCallCommandExecute_WhenCacheIsNotExpiredAndHasCachedValues()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            string methodName = "execute";
            string className = "SomeCommand";

            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(false);

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("executed");

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            sut.Execute(new List<string>());

            // Assert
            command.Verify(c => c.Execute(It.IsAny<List<string>>()), Times.Never);
        }

        [Test]
        public void CallCommandExecute_WhenCacheIsNotExpiredButNoCachedValues()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            string methodName = "execute";
            string className = "SomeCommand";

            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(false);

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<KeyNotFoundException>();

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            sut.Execute(new List<string>());

            // Assert
            command.Verify(c => c.Execute(It.IsAny<List<string>>()), Times.Once);
        }

        [Test]
        public void ReturnNewCommandExecutionResult_WhenCacheIsNotExpiredButNoCachedValues()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            string methodName = "execute";
            string className = "SomeCommand";

            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed no-cache");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(false);

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<KeyNotFoundException>();

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            string result = sut.Execute(new List<string>());

            // Assert
            Assert.AreEqual("executed no-cache", result);
        }

        [Test]
        public void ReturnCachedCommandExecutionResult_WhenCacheIsNotExpiredAndExistsCachedValues()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var cachingService = new Mock<ICachingService>();

            string methodName = "execute";
            string className = "SomeCommand";

            command.Setup(c => c.Execute(It.IsAny<List<string>>()))
                .Returns("executed no-cache");

            cachingService.Setup(cs => cs.IsExpired)
                .Returns(false);

            cachingService.Setup(cs => cs.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("cached execute");

            var sut = new CacheableCommand(command.Object, cachingService.Object);

            // Act
            string result = sut.Execute(new List<string>());

            // Assert
            Assert.AreEqual("cached execute", result);
        }
    }
}
