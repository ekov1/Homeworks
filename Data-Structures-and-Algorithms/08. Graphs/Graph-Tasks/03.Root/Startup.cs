using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Root
{
    public class Startup
    {
        public static void Main()
        {
            var edgesCount = int.Parse(Console.ReadLine());
            var nodes = new bool[edgesCount + 1];

            for (int i = 0; i < edgesCount; i++)
            {
                var input = int.Parse(Console.ReadLine().Split(' ')[1]);

                if (!nodes[input])
                {
                    nodes[input] = true;
                }
            }

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
