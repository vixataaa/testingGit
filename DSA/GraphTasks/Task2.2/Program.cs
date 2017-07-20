using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._2
{
    class Program
    {
        static HashSet<int> visited = new HashSet<int>();

        static void Main(string[] args)
        {
            // Directed
            var verticesEdges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int vertices = verticesEdges[0];
            int edges = verticesEdges[1];

            var matrix = new bool[vertices, vertices];

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int x = edge[0] - 1;
                int y = edge[1] - 1;

                matrix[x, y] = true;
            }

            bool[] used = new bool[vertices];

            Console.WriteLine(CycleExists(matrix, used, 0) ? "YES" : "NO");
        }

        private static bool CycleExists(bool[,] matrix, bool[] used, int vertex)
        {
            var sortedElements = new LinkedList<int>();

            var nodesNoEdges = GetNoSuccessorNodes(matrix);

            while (nodesNoEdges.Count != 0)
            {
                var current = nodesNoEdges.First.Value;
                nodesNoEdges.RemoveFirst();

                sortedElements.AddLast(current + 1);

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[current, i])
                    {
                        matrix[current, i] = false;
                        if (!HasIncomingEdges(matrix, i))
                        {
                            nodesNoEdges.AddLast(i);
                        }
                    }
                }
            }

            if (HasEdges(matrix))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static LinkedList<int> GetNoSuccessorNodes(bool[,] matrix)
        {
            var result = new LinkedList<int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool hasSuccessors = false;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[j, i])
                    {
                        hasSuccessors = true;
                    }
                }

                if (!hasSuccessors)
                {
                    result.AddLast(i);
                }
            }

            return result;
        }

        static bool HasIncomingEdges(bool[,] matrix, int vertex)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[i, vertex])
                {
                    return true;
                }
            }

            return false;
        }

        static bool HasEdges(bool[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
