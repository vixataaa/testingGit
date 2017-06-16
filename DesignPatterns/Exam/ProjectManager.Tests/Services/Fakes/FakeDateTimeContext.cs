using System;
using ProjectManager.Framework.AmbientContexts;

namespace ProjectManager.Tests.Services.Fakes
{
    public class FakeDateTimeContext : DateTimeContext
    {
        public override DateTime GetCurrentTime()
        {
            return new DateTime(0);
        }
    }
}
