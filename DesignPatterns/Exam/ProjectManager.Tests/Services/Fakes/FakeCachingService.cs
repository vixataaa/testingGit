using System;
using System.Collections.Generic;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.Services.Fakes
{
    public class FakeCachingService : CachingService
    {
        public FakeCachingService(TimeSpan duration) 
            : base(duration)
        {
        }

        public TimeSpan GetDuration
        {
            get
            {
                return this.Duration;
            }
        }

        public DateTime GetTimeExpiring
        {
            get
            {
                return this.TimeExpiring;
            }
        }

        public IDictionary<string, object> GetCache
        {
            get
            {
                return this.Cache;
            }
        }
    }
}
