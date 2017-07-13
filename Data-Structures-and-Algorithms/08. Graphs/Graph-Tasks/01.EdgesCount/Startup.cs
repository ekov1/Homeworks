using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EdgesCount
{
    public class Startup
    {
        private static List<int> isVisited = new List<int>();

        public static void Main()
        {
            var testsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < testsCount; i++)
            {
                var matrixLength = int.Parse(Console.ReadLine());

                int[][] matrix = new int[matrixLength][];

                for (int j = 0; j < matrixLength; j++)
                {
                    var lineInput = Console.ReadLine().Select(x => int.Parse(x.ToString())).ToArray();

                    matrix[j] = lineInput;
                }

                var graph = new Graph(matrix);
                var componentCount = 0;

                for (int m = 0; m < matrixLength; m++)
                {
                    if (!graph.Visited.Contains(m))
                    {
                        graph.Dfs(m);
                        componentCount++;
                    }
                }

                Console.WriteLine(componentCount);
            }
        }
    }
}
