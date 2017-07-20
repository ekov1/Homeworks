using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace TheGameOfLife
{
    public class Startup
    {
        public static void Main()
        {
            var generationCount = int.Parse(Console.ReadLine());
            var rc = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var matrix = new int[rc[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            for (int gen = 0; gen < generationCount; gen++)
            {
                matrix = CreateNewMatrix(matrix);

                Console.Clear();
                PrintMatrix(matrix);
                Thread.Sleep(75);
            }

            var aliveCount = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        aliveCount++;
                    }
                }
            }

            Console.WriteLine(aliveCount);
        }

        private static int[][] CreateNewMatrix(int[][] initial)
        {
            var newMatrix = new int[initial.Length][];

            for (int i = 0; i < initial.Length; i++)
            {
                newMatrix[i] = new int[initial[0].Length];

                for (int j = 0; j < initial[0].Length; j++)
                {
                    var aliveNeighbours = GetNeighboursCount(initial, i, j);

                    if (initial[i][j] == 1)
                    {
                        if (aliveNeighbours == 2 || aliveNeighbours == 3)
                        {
                            newMatrix[i][j] = 1;
                        }
                        else if (aliveNeighbours < 2)
                        {
                            newMatrix[i][j] = 0;
                        }
                        else
                        {
                            newMatrix[i][j] = 0;
                        }
                    }
                    else
                    {
                        if (aliveNeighbours == 3)
                        {
                            newMatrix[i][j] = 1;
                        }
                        else
                        {
                            newMatrix[i][j] = 0;
                        }

                    }
                }
            }

            return newMatrix;
        }

        private static int GetNeighboursCount(int[][] matrix, int row, int col)
        {
            var result = 0;
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            if (row > 0)
            {
                result += 1 & matrix[row - 1][col];

                if (col > 0)
                {
                    result += 1 & matrix[row - 1][col - 1];
                }

                if (col < cols - 1)
                {
                    result += 1 & matrix[row - 1][col + 1];
                }
            }

            if (row < rows - 1)
            {
                result += 1 & matrix[row + 1][col];

                if (col > 0)
                {
                    result += 1 & matrix[row + 1][col - 1];
                }

                if (col < cols - 1)
                {
                    result += 1 & matrix[row + 1][col + 1];
                }
            }

            if (col > 0)
            {
                result += 1 & matrix[row][col - 1];
            }

            if (col < cols - 1)
            {
                result += 1 & matrix[row][col + 1];
            }

            return result;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            var builder = new StringBuilder();
            builder.AppendLine();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        builder.Append("*");
                    }
                    else
                    {
                        builder.Append(" ");
                    }
                }

                builder.AppendLine();
            }

            Console.WriteLine(builder.ToString());
        }
    }
}
