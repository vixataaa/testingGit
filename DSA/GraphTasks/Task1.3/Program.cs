using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int vertices = int.Parse(Console.ReadLine());

            var childrenPerParent = new int[vertices + 1];

            var input = Console.ReadLine().Split(' ').Select(int.Parse);

            foreach (var item in input)
            {
                childrenPerParent[item]++;
            }

            Console.WriteLine(childrenPerParent.Max());
        }
    }
}
