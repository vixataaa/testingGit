using System;

namespace ProjectManager.Framework.AmbientContexts
{
    public class UtcDateTimeContext : DateTimeContext
    {
        public override DateTime GetCurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}
