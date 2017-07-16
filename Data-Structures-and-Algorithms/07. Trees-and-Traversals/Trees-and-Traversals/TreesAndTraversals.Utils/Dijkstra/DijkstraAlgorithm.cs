using System;
using System.Collections.Generic;
using TreesAndTraversals.Utils.BinaryHeap;

namespace TreesAndTraversals.Utils.Dijkstra
{
    public class DijkstraAlgorithm
    {
        public static int[] Dijkstra(List<Node>[] graph, int start)
        {
            var results = new int[graph.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = int.MaxValue;
            }

            results[start] = 0;

            var queue = new MinHeap<Node>();
            var used = new bool[graph.Length];

            queue.Enqueue(new Node(start, 0));

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (used[currentNode.Vertex])
                {
                    continue;
                }

                used[currentNode.Vertex] = true;

                foreach (var neightbour in graph[currentNode.Vertex])
                {
                    var currentDistance = results[neightbour.Vertex];
                    var newDistance = results[currentNode.Vertex] + neightbour.Weight;

                    if (newDistance < currentDistance)
                    {
                        results[neightbour.Vertex] = newDistance;
                        queue.Enqueue(new Node(neightbour.Vertex, newDistance));
                    }
                }
            }

            return results;
        }
    }
}
