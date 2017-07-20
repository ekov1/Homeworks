using System;
using System.Linq;

namespace MovingDoge
{
    public class Startup
    {
        private static int[,] ways;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var enemyCount = int.Parse(Console.ReadLine());

            ways = new int[n, m];

            var enemyMatrix = new bool[n, m];

            for (int i = 0; i < enemyCount; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                enemyMatrix[input[0], input[1]] = true;
            }

            WaysToPass(enemyMatrix, 0, 0);

            Print(ways);
        }

        private static void WaysToPass(bool[,] enemyMatrix, int startRow, int startCol)
        {
            if (enemyMatrix[startRow, startCol])
            {
                return;
            }

            for (int i = 0; i < ways.GetLength(0); i++)
            {
                for (int j = 0; j < ways.GetLength(1); j++)
                {
                    if (i == startRow && j == startCol)
                    {
                        ways[startRow, startCol] = 1;
                        continue;
                    }

                    if (!enemyMatrix[i, j])
                    {
                        var upperCell = i == 0 || enemyMatrix[i - 1, j] ? 0 : ways[i - 1, j];
                        var leftCell = j == 0 || enemyMatrix[i, j - 1] ? 0 : ways[i, j - 1];

                        ways[i, j] = upperCell + leftCell;
                    }
                }
            }
        }

        private static void Print(int[,] ways)
        {
            for (int i = 0; i < ways.GetLength(0); i++)
            {
                for (int j = 0; j < ways.GetLength(1); j++)
                {
                    Console.Write(ways[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
