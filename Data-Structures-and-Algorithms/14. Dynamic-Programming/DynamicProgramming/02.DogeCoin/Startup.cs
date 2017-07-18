using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.DogeCoin
{
    class Startup
    {
        static void Main()
        {
            var rowCol = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var matrix = new int[rowCol[0], rowCol[1]];

            var coinsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < coinsNumber; i++)
            {
                var coinCoords = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();

                matrix[coinCoords[0], coinCoords[1]] += 1;
            }

            Console.WriteLine("Max coins gathered = " + MaxCoinsDogeCanGather(matrix));
            PrintMatrix<int>(matrix);
        }

        private static long MaxCoinsDogeCanGather(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var up = 0;
                    var left = 0;

                    if (i > 0)
                    {
                        up = matrix[i - 1, j];
                    }

                    if (j > 0)
                    {
                        left = matrix[i, j - 1];
                    }

                    matrix[i, j] += Math.Max(left, up);
                }
            }

            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        }

        private static void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
