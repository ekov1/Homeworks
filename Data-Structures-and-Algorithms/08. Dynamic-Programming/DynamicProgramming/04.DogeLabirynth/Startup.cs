using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.DogeLabirynth
{
    public class Startup
    {
        public static void Main()
        {
            var matrix = new int[6, 8];
            AlignEnemies(matrix);

            //CalcPathsDynamic(matrix);
            CalcPathsRec(matrix, 0, 3);

            PrintMatrix<int>(matrix);
        }

        private static void CalcPathsDynamic(int[,] matrix)
        {
            matrix[0, 0] = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == -1)
                    {
                        continue;
                    }

                    if (j > 0 && matrix[i, j - 1] != -1)
                    {
                        matrix[i, j] += matrix[i, j - 1];
                    }

                    if (i > 0 && matrix[i - 1, j] != -1)
                    {
                        matrix[i, j] += matrix[i - 1, j];
                    }
                }
            }
        }

        private static void CalcPathsRec(int[,] matrix, int i, int j)
        {
            if (i == matrix.GetLength(0) || j == matrix.GetLength(1))
            {
                return;
            }

            if (matrix[i, j] == -1)
            {
                return;
            }

            if (i > 0 && j > 0)
            {
                if (matrix[i - 1, j] < 0)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
                else if (matrix[i, j - 1] < 0)
                {
                    matrix[i, j] = matrix[i - 1, j];
                }
                else if (matrix[i, j - 1] < 0 && matrix[i - 1, j] < 0)
                {
                    matrix[i, j] = 0;
                }
                else
                {
                    matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
                }

            }
            else
            {
                matrix[i, j] = 1;
            }

            CalcPathsRec(matrix, i + 1, j);
            CalcPathsRec(matrix, i, j + 1);
        }

        private static void AlignEnemies(int[,] matrix)
        {
            var enemies = new List<string>()
            {
                "0 1",
                //"1 0",
                "2 3",
                "5 6",
                "4 5",
                "5 4",
                "5 5",
                "5 7"
            };

            for (int i = 0; i < enemies.Count; i++)
            {
                var enemyCoords = enemies[i].Split(' ').Select(int.Parse).ToList();

                matrix[enemyCoords[0], enemyCoords[1]] = -1;
            }
        }

        private static void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 5}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
