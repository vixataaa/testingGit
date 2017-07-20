using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        // M > K > P
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var masters = new LinkedList<string>();
            var knights = new LinkedList<string>();
            var padawans = new LinkedList<string>();

            var meditators = Console.ReadLine().Split(' ');
            foreach (var meditator in meditators)
            {
                char mType = meditator[0];

                switch (mType)
                {
                    case 'M':
                        masters.AddLast(meditator);
                        break;
                    case 'K':
                        knights.AddLast(meditator);
                        break;
                    case 'P':
                        padawans.AddLast(meditator);
                        break;
                    default:
                        break;
                }
            }

            var result = String.Join(" ", masters) + " " + string.Join(" ", knights) + " " + string.Join(" ", padawans);
            Console.WriteLine(result);
         }
    }
}
