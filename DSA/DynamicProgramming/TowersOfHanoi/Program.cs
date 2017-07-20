using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersOfHanoi
{
    class Program
    {
        public static void Hanoi(int n, char source, char middle, char destination)
        {
            if(n == 1)
            {
                Console.WriteLine($"Moving disk {n} from {source} to {destination}");
                return;
            }

            Hanoi(n - 1, source, destination, middle);
            Console.WriteLine($"Moving disk {n - 1} from {source} to {middle}");
        }

        static void Main(string[] args)
        {
            Hanoi(3, 'A', 'B', 'C');
        }
    }
}
