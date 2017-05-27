using System;
using System.Collections.Generic;

namespace _07.FindPathBetweenCells
{
    public class Startup
    {
        private static IList<char> directions = new List<char>();

        public static void Main()
        {
            var matrix = new char[,]
            {
                {' ', ' ', ' ', '*', ' ', ' ', ' '},
                {'*', '*', ' ', '*', ' ', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', '*', '*', '*', '*', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
            };

            FindPossiblePaths(matrix, 0, 0, 's');
        }

        private static void FindPossiblePaths(char[,] matrix, int currentRow, int currentCol, char direction)
        {
            if (!IsInRange(matrix, currentRow, currentCol))
            {
                return;
            }

            directions.Add(direction);

            if (matrix[currentRow, currentCol] == 'e')
            {
                Console.WriteLine($"Possible path - {string.Join(", ", directions)}");
                return;
            }

            if (matrix[currentRow, currentCol] == ' ')
            {
                matrix[currentRow, currentCol] = 'v';

                FindPossiblePaths(matrix, currentRow, currentCol - 1, 'L');
                FindPossiblePaths(matrix, currentRow + 1, currentCol, 'D');
                FindPossiblePaths(matrix, currentRow, currentCol + 1, 'R');
                FindPossiblePaths(matrix, currentRow - 1, currentCol, 'U');

                matrix[currentRow, currentCol] = ' ';
            }

            directions.RemoveAt(directions.Count - 1);
        }

        private static bool IsInRange(char[,] matrix, int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);

            return rowInRange && colInRange;
        }
    }
}
