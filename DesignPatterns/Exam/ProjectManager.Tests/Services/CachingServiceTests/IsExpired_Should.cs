using System;
using NUnit.Framework;
using ProjectManager.Framework.AmbientContexts;
using ProjectManager.Tests.Services.Fakes;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class IsExpired_Should
    {
        [Test]
        public void ReturnTrue_WhenItsTimeExpiringIsLessThanTheCurrentTime()
        {
            // Arrange
            var duration = new TimeSpan(100);

            DateTimeContext.Current = new FakeDateTimeContext();

            var sut = new FakeCachingService(duration);

            DateTimeContext.Current = DateTimeContext.Default;

            // Act
            var cacheExpired = sut.IsExpired;

            // Assert
            Assert.IsTrue(cacheExpired);
        }

        [Test]
        public void ReturnFalse_WhenItsTimeExpiringIsNotLessThanTheCurrentTime()
        {
            // Arrange
            var duration = new TimeSpan(100);

            DateTimeContext.Current = DateTimeContext.Default;
            DateTimeContext.Current = new FakeDateTimeContext();

            var sut = new FakeCachingService(duration);
           
            // Appends to time expiring while fake returns DT(0)
            sut.ResetCache();
            var result = sut.GetTimeExpiring;

            // Act
            var cacheExpired = sut.IsExpired;

            // Assert
            Assert.IsFalse(cacheExpired);
        }
    }
}
