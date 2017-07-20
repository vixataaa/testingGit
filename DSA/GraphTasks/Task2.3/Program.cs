using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._3
{
    class Program
    {
        static int maxConnectivity = 0;

        static void Main(string[] args)
        {
            var verticesEdges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int vertices = verticesEdges[0];
            int edges = verticesEdges[1];

            var verticeNeighbors = new LinkedList<int>[vertices];

            for (int i = 0; i < verticeNeighbors.Length; i++)
            {
                verticeNeighbors[i] = new LinkedList<int>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                int x = edge[0] - 1;
                int y = edge[1] - 1;

                // Not directed
                verticeNeighbors[x].AddLast(y);
                verticeNeighbors[y].AddLast(x);
            }

            var used = new bool[vertices];

            for (int i = 0; i < vertices; i++)
            {
                if (!used[i])
                {
                    maxConnectivity = Math.Max(maxConnectivity, BfsConnectedComponents(verticeNeighbors, used, i));
                }
            }

            Console.WriteLine(maxConnectivity);            
        }

        static int BfsConnectedComponents(LinkedList<int>[] vertexNeighbors, bool[] used, int source)
        {
            var undiscovered = new Queue<int>();
            var distance = new Queue<int>();

            undiscovered.Enqueue(source);
            distance.Enqueue(0);

            used[source] = true;

            int components = 1;

            while (undiscovered.Count != 0)
            {
                var current = undiscovered.Dequeue();

                foreach (var vert in vertexNeighbors[current])
                {
                    if (!used[vert])
                    {
                        components++;
                        used[vert] = true;
                        undiscovered.Enqueue(vert);
                    }
                }
            }

            return components;
        }
    }
}
