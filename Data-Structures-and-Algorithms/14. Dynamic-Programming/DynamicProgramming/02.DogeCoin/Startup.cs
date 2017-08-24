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
            var matrix = new int[rowCol[0]][].Select(x => x = new int[rowCol[1]]).ToArray();

            var coinsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < coinsNumber; i++)
            {
                var coinCoords = Console.ReadLine()
                    .Split(' ');

                matrix[int.Parse(coinCoords[0])][int.Parse(coinCoords[1])] += 1;
            }

            Console.WriteLine(MaxCoinsDogeCanGather(matrix));
            //PrintMatrix<int>(matrix);
        }

        private static long MaxCoinsDogeCanGather(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    var up = 0;
                    var left = 0;

                    if (i > 0)
                    {
                        up = matrix[i - 1][j];
                    }

                    if (j > 0)
                    {
                        left = matrix[i][j - 1];
                    }

                    matrix[i][j] += Math.Max(left, up);
                }
            }

            return matrix[matrix.Length - 1][matrix[0].Length - 1];
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
