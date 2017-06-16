using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using ProjectManager.Framework.AmbientContexts;

namespace ProjectManager.Framework.Services
{
    public class CachingService : ICachingService
    {
        private readonly TimeSpan duration;
        private DateTime timeExpiring;

        private IDictionary<string, object> cache;

        public CachingService(TimeSpan duration)
        {
            Guard.WhenArgument(duration, "duration").IsLessThan(TimeSpan.Zero).Throw();

            this.duration = duration;
            this.timeExpiring = DateTimeContext.Current.GetCurrentTime();
            this.cache = new Dictionary<string, object>();
        }

        protected TimeSpan Duration
        {
            get
            {
                return this.duration;
            }
        }

        protected DateTime TimeExpiring
        {
            get
            {
                return this.timeExpiring;
            }
        }

        protected IDictionary<string, object> Cache
        {
            get
            {
                return this.cache;
            }
        }

        public void ResetCache()
        {
            this.cache = new Dictionary<string, object>();
            this.timeExpiring = DateTimeContext.Current.GetCurrentTime() + (this.duration);
        }

        public bool IsExpired
        {
            get
            {
                // Console.WriteLine($"NOW: {DateTimeContext.Current.GetCurrentTime()} -- EXP: {this.timeExpiring}");
                if (this.timeExpiring <= DateTimeContext.Current.GetCurrentTime())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public object GetCacheValue(string className, string methodName)
        {
            return this.cache[$"{className}.{methodName}"];
        }

        public void AddCacheValue(string className, string methodName, object value)
        {
            this.cache.Add($"{className}.{methodName}", value);
        }
    }
}
