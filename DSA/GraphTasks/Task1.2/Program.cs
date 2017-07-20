using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int vertices = int.Parse(Console.ReadLine());

            var vertexNeighbors = new LinkedList<int>[vertices];

            int edgeCount = 0;

            for (int i = 0; i < vertices; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                edgeCount += line[0];
                vertexNeighbors[i] = new LinkedList<int>();

                for (int j = 1; j <= line[0]; j++)
                {
                    vertexNeighbors[i].AddLast(line[j]);
                }                
            }

            Console.WriteLine("{0} {1}", vertices, edgeCount);

            for (int i = 0; i < vertexNeighbors.Length; i++)
            {
                foreach (var neighbor in vertexNeighbors[i])
                {
                    Console.WriteLine("{0} {1}", i + 1, neighbor);
                }
            }
        }
    }
}
