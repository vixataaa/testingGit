using System;
using NUnit.Framework;
using ProjectManager.Tests.Services.Fakes;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class GetCacheValue_Should
    {
        [Test]
        public void ReturnProperValue_WhenCalledValueExists()
        {
            // Arrange
            var duration = new TimeSpan(100);

            var sut = new FakeCachingService(duration);

            string className = "class1";
            string methodName = "method1";
            string value = "value1";

            sut.AddCacheValue(className, methodName, value);

            // Act
            var result = sut.GetCacheValue(className, methodName);

            // Assert
            Assert.AreEqual(value, result.ToString());
        }

        [Test]
        public void NotThrow_WhenCalledValueExists()
        {
            // Arrange
            var duration = new TimeSpan(100);

            var sut = new FakeCachingService(duration);

            string className = "class1";
            string methodName = "method1";
            string value = "value1";

            sut.AddCacheValue(className, methodName, value);

            // Act & Assert
            Assert.DoesNotThrow(() => sut.GetCacheValue(className, methodName));
        }
    }
}
