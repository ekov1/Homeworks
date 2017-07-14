using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RedRidingHood
{
	// Works for 36/100 needs  optimization
    public class Startup
    {
        public static void Main()
        {
            var destinationsCount = int.Parse(Console.ReadLine());
            var connectionsCount = destinationsCount - 1;

            var connections = new LinkedList<int>[destinationsCount + 1];
            var nodeValues = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < connectionsCount; i++)
            {
                var input = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

                if (connections[input[0]] == null)
                {
                    connections[input[0]] = new LinkedList<int>();
                }

                connections[input[0]].AddLast(input[1]);

                if (connections[input[1]] == null)
                {
                    connections[input[1]] = new LinkedList<int>();
                }

                connections[input[1]].AddLast(input[0]);
            }

            var graph = new Graph(connections, nodeValues);

            graph.FindMostMoney();
        }
    }

    public class Graph
    {
        private LinkedList<int>[] nodes;
        private HashSet<int> visited;
        private int maxValue;
        private int[] values;

        public Graph(LinkedList<int>[] nodes, int[] values)
        {
            this.values = values;
            this.visited = new HashSet<int>();
            this.nodes = nodes;
            this.maxValue = 0;
        }

        public void FindMostMoney()
        {
            for (int i = 1; i < this.nodes.Length; i++)
            {
                this.Bfs(i);
            }

            Console.WriteLine(this.maxValue);
        }

        public void Bfs(int node)
        {
            var queue = new Queue<int>();
            var moneyFound = new Queue<int>();
            this.visited = new HashSet<int>();

            queue.Enqueue(node);
            moneyFound.Enqueue(this.values[node - 1]);
            this.visited.Add(node);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                var currentMoney = moneyFound.Dequeue();

                if (currentMoney > this.maxValue)
                {
                    maxValue = currentMoney;
                }

                foreach (var item in this.nodes[currentNode])
                {
                    if (!this.visited.Contains(item))
                    {
                        this.visited.Add(item);
                        queue.Enqueue(item);
                        moneyFound.Enqueue(currentMoney + this.values[item - 1]);
                    }
                }
            }
        }
    }
}
