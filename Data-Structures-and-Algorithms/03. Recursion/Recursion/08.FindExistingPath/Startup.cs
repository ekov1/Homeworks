using System;

namespace _07.FindPathBetweenCells
{
    public class Startup
    {
        public static void Main()
        {
            var matrix = new int[100, 100];
            matrix[59, 29] = 69;

            FindPossiblePaths(matrix, 0, 0);
        }

        private static void FindPossiblePaths(int[,] matrix, int currentRow, int currentCol)
        {
            if (!IsInRange(matrix, currentRow, currentCol))
            {
                return;
            }

            if (matrix[currentRow, currentCol] == 69)
            {
                Console.WriteLine("Path to the desired cell exists!");
                Environment.Exit(0);
            }

            if (matrix[currentRow, currentCol] == 0)
            {
                matrix[currentRow, currentCol] = 1; // Visited

                FindPossiblePaths(matrix, currentRow, currentCol - 1);
                FindPossiblePaths(matrix, currentRow + 1, currentCol);
                FindPossiblePaths(matrix, currentRow, currentCol + 1);
                FindPossiblePaths(matrix, currentRow - 1, currentCol);
            }
        }

        private static bool IsInRange(int[,] matrix, int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);

            return rowInRange && colInRange;
        }
    }
}
