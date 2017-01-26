using System;
using System.Text;

namespace Problem1
{
    public static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder builder, int index, int length = -1)
        {
            StringBuilder result;

            string builderString = builder.ToString();

            if(length == -1)
            {
                result = new StringBuilder(builderString.Substring(index));
                return result;
            }   //if length is not given - go till string end; return

            result = new StringBuilder(builderString.Substring(index, length));

            return result;
        }   //StringBuilder.Substring
    }
}
