using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRidingHood
{
    class Program
    {
        static int[] prices;
        static int maxProfit = 0;

        static void Main(string[] args)
        {
            int vertices = int.Parse(Console.ReadLine());
            prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var edges = new LinkedList<int>[vertices];

            for (int i = 0; i < vertices - 1; i++)
            {
                // Undirected
                var input = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

                int x = input[0] - 1;
                int y = input[1] - 1;

                if(edges[x] == null)
                {
                    edges[x] = new LinkedList<int>();
                }

                if(edges[y] == null)
                {
                    edges[y] = new LinkedList<int>();
                }

                edges[x].AddLast(y);
                edges[y].AddLast(x);                
            }

            bool[] used = new bool[vertices];
            int first = BfsProfit(edges, 0, used);
            used = new bool[vertices];
            BfsProfit(edges, first, used);

            Console.WriteLine(maxProfit);
        }

        static int BfsProfit(LinkedList<int>[] vertexEdges, int startVertex, bool[] used)
        {
            var q = new Queue<int>();
            var profit = new Queue<int>();

            q.Enqueue(startVertex);
            profit.Enqueue(prices[startVertex]);

            used[startVertex] = true;

            int maxProfitCollected = 0;

            int lastVisitedVertex = 0;

            while(q.Count != 0)
            {
                int currentVertex = q.Dequeue();
                int currentProfit = profit.Dequeue();

                lastVisitedVertex = currentVertex;

                maxProfitCollected = Math.Max(currentProfit, maxProfitCollected);

                foreach (var vertex in vertexEdges[currentVertex])
                {
                    if(!used[vertex])
                    {
                        used[vertex] = true;
                        q.Enqueue(vertex);
                        profit.Enqueue(currentProfit + prices[vertex]);
                    }
                }
            }

            maxProfit = Math.Max(maxProfit, maxProfitCollected);

            return lastVisitedVertex;
        }
    }
}
