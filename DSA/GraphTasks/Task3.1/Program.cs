using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Undirected
            var verticesEdges = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            int vertices = verticesEdges[0];
            int edges = verticesEdges[1];

            var matrix = new int[vertices, vertices];

            int totalDist = 0;

            for (int i = 0; i < edges; i++)
            {
                var input = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

                int x = input[0] - 1;
                int y = input[1] - 1;
                int weight = input[2];

                matrix[x, y] = weight;
                matrix[y, x] = weight;
                totalDist += weight;
            }

            // Priority - Vertex
            var verticesWeights = new List<Tuple<int, int>>();

            verticesWeights.Add(new Tuple<int, int>(0, 0));

            for (int i = 1; i < vertices; i++)
            {
                verticesWeights.Add(new Tuple<int, int>(int.MaxValue, i));
            }

            var mst = new HashSet<int>();

            int assembledDistance = 0;


            while (mst.Count < vertices)
            {
                //Console.WriteLine("MST.Count {0} -- Vertices.Count {1}", mst.Count, vertices);
                var currVWeights = verticesWeights;
                currVWeights.Sort();

                for (int i = 0; i < currVWeights.Count; i++)
                {
                    if(!mst.Contains(currVWeights[i].Item2))
                    {
                        mst.Add(i);

                        for (int j = 0; j < vertices; j++)
                        {
                            if(matrix[i, j] != 0)
                            {
                                if(verticesWeights[j].Item1 < matrix[i, j])
                                {
                                    assembledDistance += matrix[i, j];
                                    verticesWeights[j] = new Tuple<int, int>(matrix[i, j], verticesWeights[j].Item2);
                                }
                            }
                        }

                        break;
                    }
                }
            }

            //Console.WriteLine(string.Join(" ", mst));
            Console.WriteLine(totalDist - assembledDistance - 1);
        }
    }

    public class BinaryHeap<T>
    {
        private List<T> heap;
        private Func<T, T, bool> compareFunc;

        public BinaryHeap(Func<T, T, bool> cmpFunc)
        {
            heap = new List<T>();
            heap.Add(default(T));
            compareFunc = cmpFunc;
        }

        public T Top => heap[1];
        public int Count => heap.Count - 1;
        public bool Empty => Count == 0;

        public void Update(Func<T, T, bool> findFunc, T newValue)
        {
            for (int i = 1; i < this.heap.Count; i++)
            {
                if (compareFunc(heap[i], newValue))
                {
                    heap[i] = newValue;
                }
            }

            this.HeapifyDown(1, newValue);
        }

        public void Insert(T value)
        {
            int index = heap.Count;
            heap.Add(value);

            while (index > 1 && compareFunc(value, heap[index / 2]))
            {
                heap[index] = heap[index / 2];
                index /= 2;
            }

            heap[index] = value;
        }

        public void RemoveTop()
        {
            var value = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (!Empty)
            {
                HeapifyDown(1, value);
            }
        }

        private void HeapifyDown(int index, T value)
        {
            while (index * 2 + 1 < heap.Count)
            {
                int smallerKidIndex = compareFunc(heap[index * 2], heap[index * 2 + 1])
                    ? index * 2
                    : index * 2 + 1;
                if (compareFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
                else
                {
                    break;
                }
            }

            if (index * 2 < heap.Count)
            {
                int smallerKidIndex = index * 2;
                if (compareFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
            }

            heap[index] = value;
        }
    }


}
