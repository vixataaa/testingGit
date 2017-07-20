using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{
    class Program
    {
        static int diameter = 0;

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

            for (int i = 0; i < vertices; i++)
            {
                var used = new bool[vertices];
                diameter = Math.Max(diameter, BfsDistance(verticeNeighbors, used, i));
            }

            Console.WriteLine(diameter);
        }

        static int BfsDistance(LinkedList<int>[] vertexNeighbors, bool[] used, int source)
        {
            var undiscovered = new Queue<int>();
            var distance = new Queue<int>();

            undiscovered.Enqueue(source);
            distance.Enqueue(0);

            used[source] = true;

            int maxDist = 0;

            while(undiscovered.Count != 0)
            {
                var current = undiscovered.Dequeue();
                var dist = distance.Dequeue();

                maxDist = Math.Max(maxDist, dist);

                foreach (var vert in vertexNeighbors[current])
                {
                    if(!used[vert])
                    {
                        used[vert] = true;
                        undiscovered.Enqueue(vert);
                        distance.Enqueue(dist + 1);
                    }
                }
            }

            return maxDist;
        }
    }
}
