using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Leaves
{
    public class Startup
    {
        public static void Main()
        {
            var edgesCount = int.Parse(Console.ReadLine());
            var nodes = new bool[edgesCount + 1];
            var parentNodesCount = 0;

            for (int i = 0; i < edgesCount; i++)
            {
                var input = int.Parse(Console.ReadLine().Split(' ')[0]);

                if (!nodes[input])
                {
                    parentNodesCount++;
                    nodes[input] = true;
                }
            }

            Console.WriteLine(nodes.Length - parentNodesCount);

            for (int i = 0; i < nodes.Length; i++)
            {
                if (!nodes[i])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
