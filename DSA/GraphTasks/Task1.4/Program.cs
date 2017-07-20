using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            var verticesEdges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] vertexNeighborCount = new int[verticesEdges[0]];

            for (int i = 0; i < verticesEdges[1]; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                vertexNeighborCount[edge[0] - 1]++;
                vertexNeighborCount[edge[1] - 1]++;
            }

            Console.WriteLine("{0} {1}", vertexNeighborCount.Max(), vertexNeighborCount.Min());
        }
    }
}
