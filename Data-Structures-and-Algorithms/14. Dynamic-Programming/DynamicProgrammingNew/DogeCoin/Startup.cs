using System;
using System.Diagnostics;
using System.Linq;

namespace MovingDoge
{
    public class Startup
    {
        public static void Main()
        {
            var matrix = ParseInput();

            //Print(matrix);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            MaxCoinsCollected(matrix, 0, 0);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        private static int[,] ParseInput()
        {
            var coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var coinsCount = int.Parse(Console.ReadLine());

            var matrix = new int[coords[0], coords[1]];

            for (int i = 0; i < coinsCount; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (matrix[input[0], input[1]] == 0)
                {
                    matrix[input[0], input[1]] = 1;
                }
                else
                {
                    matrix[input[0], input[1]]++;
                }
            }

            return matrix;
        }

        private static int MaxCoinsCollected(int[,] matrix, int startRow, int startCol)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    var upperCell = i == 0 ? 0 : matrix[i - 1, j];
                    var leftCell = j == 0 ? 0 : matrix[i, j - 1];

                    matrix[i, j] = Math.Max(leftCell, upperCell) + matrix[i, j];
                }
            }

            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
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
