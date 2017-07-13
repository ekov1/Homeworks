using System;
using System.Collections.Generic;
using System.Text;

namespace _07.HorseMovements
{
    public class Startup
    {
        private static int EncodeValueConstant = 1501;

        private static int[] deltaX = new int[] { -1, -2, -2, -1, 1, 2, 2, 1 };
        private static int[] deltaY = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };

        public static void Main()
        {
            var matrixRows = int.Parse(Console.ReadLine());
            var matrixCols = int.Parse(Console.ReadLine());

            var startRow = int.Parse(Console.ReadLine());
            var startCol = int.Parse(Console.ReadLine());

            var matrix = new int[matrixRows][];

            for (int i = 0; i < matrixRows; i++)
            {
                matrix[i] = new int[matrixCols];
            }

            Bfs(matrix, startRow, startCol);

            PrintColumn(matrix);
        }

        public static void Bfs(int[][] matrix, int row, int col)
        {
            matrix[row][col] = 1;

            var currentRow = 0;
            var currentCol = 0;
            var currentElement = 0;
            var nextRow = 0;
            var nextCol = 0;

            var queue = new Queue<int>();
            queue.Enqueue(EncodeValue(row, col));

            while (queue.Count != 0)
            {
                currentElement = queue.Dequeue();
                currentRow = DecodeRow(currentElement);
                currentCol = DecodeCol(currentElement);

                for (int i = 0; i < deltaX.Length; i++)
                {
                    nextRow = currentRow + deltaX[i];
                    nextCol = currentCol + deltaY[i];

                    if (IsInRange(matrix, nextRow, nextCol) && matrix[nextRow][nextCol] == 0)
                    {
                        matrix[nextRow][nextCol] = matrix[currentRow][currentCol] + 1;
                        queue.Enqueue(EncodeValue(nextRow, nextCol));
                    }
                }
            }
        }

        private static int EncodeValue(int row, int col)
        {
            return row * EncodeValueConstant + col;
        }

        private static int DecodeRow(int code)
        {
            return code / EncodeValueConstant;
        }

        private static int DecodeCol(int code)
        {
            return code % EncodeValueConstant;
        }

        private static bool IsInRange(int[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length &&
                col >= 0 && col < matrix[0].Length;
        }
        public static void PrintColumn(int[][] matrix)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < matrix.Length; i++)
            {
                builder.AppendLine(matrix[i][matrix[0].Length / 2].ToString());
            }

            Console.Write(builder.ToString());
        }
    }
}
