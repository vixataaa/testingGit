using System;
using Bytes2you.Validation;

namespace ProjectManager.Framework.AmbientContexts
{
    public abstract class DateTimeContext
    {
        private static DateTimeContext current;

        protected DateTimeContext()
        {
        }

        public static DateTimeContext Current
        {
            get
            {
                if (current == null)
                {
                    current = new UtcDateTimeContext();
                }

                return current;
            }
            set
            {
                Guard.WhenArgument(value, "value").IsNull().Throw();
                current = value;
            }
        }

        public static DateTimeContext Default
        {
            get
            {
                return new UtcDateTimeContext();
            }
        }

        public abstract DateTime GetCurrentTime();
    }
}
