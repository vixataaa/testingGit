using System;

namespace VersionAttribute
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
        AttributeTargets.Interface | AttributeTargets.Enum |
        AttributeTargets.Method, AllowMultiple = false)]    //cant use multiple versions at once
    public class CustomAttribute : System.Attribute
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }

        public CustomAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
    }
}
