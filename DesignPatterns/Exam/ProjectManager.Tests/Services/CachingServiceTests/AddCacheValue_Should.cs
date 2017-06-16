using System;
using NUnit.Framework;
using ProjectManager.Tests.Services.Fakes;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class AddCacheValue_Should
    {
        [Test]
        public void IncreaseTheCacheSizeWithOnce_WhenGivenValidValues()
        {
            // Arrange
            var duration = new TimeSpan(100);

            var sut = new FakeCachingService(duration);

            // Act 
            sut.AddCacheValue("class", "method", "value");

            // Assert
            Assert.AreEqual(1, sut.GetCache.Count);
        }

        [Test]
        public void AppendValueWithKeyContainingClassAndMethodNameSeparatedWithDot_WhenGivenValidValues()
        {
            // Arrange
            var duration = new TimeSpan(100);

            var sut = new FakeCachingService(duration);

            // Act 
            sut.AddCacheValue("class", "method", "value");

            bool hasExpectedKey = sut.GetCache.Keys.Contains("class.method");

            // Assert
            Assert.IsTrue(hasExpectedKey);
        }
    }
}
