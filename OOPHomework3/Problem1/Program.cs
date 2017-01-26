using System;
using System.Text;

namespace Problem1
{
    class Program
    {
        static void Main()
        {
            StringBuilder builder = new StringBuilder("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");

            StringBuilder cut1 = builder.Substring(4);  //no length given
            Console.WriteLine(cut1.ToString());

            StringBuilder cut2 = builder.Substring(4, 2);
            Console.WriteLine(cut2.ToString());
            
        }
    }
}
