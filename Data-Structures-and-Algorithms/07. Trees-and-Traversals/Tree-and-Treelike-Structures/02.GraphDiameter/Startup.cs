using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GraphDiameter
{
    public class Startup
    {
        public static void Main()
        {
            var nodesAndEdges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var connections = new int[nodesAndEdges[0] + 1][];

            for (int i = 0; i < nodesAndEdges[1]; i++)
            {
                var input = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

                if (connections[input[0]] == null)
                {
                    connections[input[0]] = new int[nodesAndEdges[0] + 1];
                }

                connections[input[0]][input[1]] = 1;

                if (connections[input[1]] == null)
                {
                    connections[input[1]] = new int[nodesAndEdges[0] + 1];
                }

                connections[input[1]][input[0]] = 1;
            }

            var graph = new Graph(connections);

            graph.FindDiameter();
        }
    }

    public class Graph
    {
        private int[][] nodes;
        private HashSet<int> visited;
        private int maxValue;

        public Graph(int[][] nodes)
        {
            this.visited = new HashSet<int>();
            this.nodes = nodes;
            this.maxValue = 0;
        }

        public void FindDiameter()
        {
            for (int i = 1; i < this.nodes.Length; i++)
            {
                this.Bfs(i);
            }

            Console.WriteLine(maxValue);
        }

        public void Bfs(int node)
        {
            var queue = new Queue<int>();
            var travelledWay = new Queue<int>();
            this.visited = new HashSet<int>();

            queue.Enqueue(node);
            travelledWay.Enqueue(0);
            this.visited.Add(node);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                var currentDestination = travelledWay.Dequeue();
                if (currentDestination > maxValue)
                {
                    maxValue = currentDestination;
                }

                for (int i = 0; i < this.nodes.Length; i++)
                {
                    if (this.nodes[currentNode]?[i] > 0 && !this.visited.Contains(i))
                    {
                        this.visited.Add(i);
                        queue.Enqueue(i);
                        travelledWay.Enqueue(currentDestination + 1);
                    }
                }
            }
        }
    }
}
