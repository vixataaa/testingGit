using System;
using NUnit.Framework;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrow_WhenGivenValidDuration()
        {
            // Arrange
            var duration = new TimeSpan(5);

            // Act & Assert
            Assert.DoesNotThrow(() => new CachingService(duration));
        }

        [Test]
        public void ThrowArgumentOutOfRangeException_WhenGivenNegativeDuration()
        {
            // Arrange
            var duration = new TimeSpan(-5);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new CachingService(duration));
        }
    }
}
