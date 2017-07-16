using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Loops
{
    // Task is taken from Hackerrank.com
    public class Startup
    {
        public static void Main()
        {
            var verticesAndEdges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var connections = new List<int>[verticesAndEdges[0] + 1];
            var startNode = 0;

            for (int i = 0; i < verticesAndEdges[1]; i++)
            {
                var fromTo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (i == 0)
                {
                    startNode = fromTo[0];
                }

                if (connections[fromTo[0]] == null)
                {
                    connections[fromTo[0]] = new List<int>();
                }

                connections[fromTo[0]].Add(fromTo[1]);
            }

            var result = CheckForGraphLoops(connections, verticesAndEdges[0], startNode) ? "YES" : "NO";

            Console.WriteLine(result);
        }

        public static bool CheckForGraphLoops(List<int>[] connections, int elementsCount, int startNode)
        {
            var used = new bool[elementsCount + 1];
            var queue = new Queue<int>();

            queue.Enqueue(startNode);
            used[startNode] = true;

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (connections[currentNode] != null)
                {
                    foreach (var item in connections[currentNode])
                    {
                        if (!used[item])
                        {
                            queue.Enqueue(item);
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
