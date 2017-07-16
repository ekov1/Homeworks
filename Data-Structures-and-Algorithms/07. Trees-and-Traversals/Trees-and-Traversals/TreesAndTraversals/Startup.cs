using System;
using System.Collections.Generic;
using TreesAndTraversals.Utils.Dijkstra;

namespace TreesAndTraversals
{
    public class Startup
    {
        public static void Main()
        {
            var graph = CreateGraph();

            var result = DijkstraAlgorithm.Dijkstra(graph, 0);

            Console.WriteLine("Shortest way to last node: " + result[result.Length - 1]);
        }

        private static List<Node>[] CreateGraph()
        {
            var graph = new List<Node>[6];

            graph[0] = new List<Node>
            {
                new Node(1, 4),
                new Node(3, 0)
            };

            graph[1] = new List<Node>
            {
                new Node(5, 8),
                new Node(4, 3),
                new Node(2, 15),
                new Node(3, 3)
            };

            graph[2] = new List<Node>
            {
                new Node(1, 15),
                new Node(5, 4)
            };

            graph[3] = new List<Node>
            {
                new Node(1, 3),
                new Node(4, 2)
            };

            graph[4] = new List<Node>
            {
                new Node(3, 2),
                new Node(1, 3),
                new Node(5, 1)
            };

            graph[5] = new List<Node>
            {
                new Node(1, 8),
                new Node(2, 4),
                new Node(4, 1)
            };

            return graph;
        }
    }
}
