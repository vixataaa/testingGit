using System;
using NUnit.Framework;
using ProjectManager.Framework.AmbientContexts;
using ProjectManager.Tests.Services.Fakes;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class ResetCache_Should
    {
        [Test]
        public void ClearTheContentOfTheCacheDictionary_WhenCalled()
        {
            // Arrange
            var duration = new TimeSpan(100);

            var sut = new FakeCachingService(duration);

            sut.AddCacheValue("className", "methodName", "someValue");

            // Act
            sut.ResetCache();

            // Assert
            Assert.AreEqual(0, sut.GetCache.Count);
        }

        [Test]
        public void AppendTheDurationToTheTimeExpiring_WhenCalled()
        {
            // Arrange
            var duration = new TimeSpan(100);

            DateTimeContext.Current = DateTimeContext.Default;
            DateTimeContext.Current = new FakeDateTimeContext();

            var sut = new FakeCachingService(duration);

            var expected = new DateTime(0).Add(duration);

            // Act
            sut.ResetCache();            

            // Assert
            Assert.AreEqual(expected, sut.GetTimeExpiring);
        }
    }
}
