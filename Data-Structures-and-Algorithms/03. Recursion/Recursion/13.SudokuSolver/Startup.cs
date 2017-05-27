using System;

namespace _13.SudokuSolver
{
    public class Startup
    {
        public static void Main()
        {
            var matrix = new int[,]
            {
                { 0, 0, 4,  9, 7, 0,  2, 3, 5 },
                { 5, 3, 0,  0, 0, 0,  0, 0, 0 },
                { 0, 0, 0,  0, 0, 0,  0, 9, 8 },

                { 0, 6, 0,  0, 2, 5,  0, 0, 0 },
                { 4, 0, 0,  0, 0, 0,  0, 0, 1 },
                { 0, 0, 0,  6, 4, 0,  0, 5, 0 },
                
                { 6, 7, 0,  0, 0, 0,  0, 0, 0 },
                { 0, 0, 0,  0, 0, 0,  0, 1, 9 },
                { 1, 9, 2,  0, 5, 4,  8, 0, 0 }
            };

            SolveSudoku(matrix, 0, 0);
        }

        private static bool SolveSudoku(int[,] matrix, int currentRow, int currentCol)
        {
            if (currentCol == 9)
            {
                currentRow++;
                currentCol = 0;

                if (currentRow == 9)
                {
                    PrintMatrix(matrix);
                    return true;
                }
            }

            if (matrix[currentRow, currentCol] > 0)
            {
                return SolveSudoku(matrix, currentRow, currentCol + 1);
            }

            for (int i = 1; i <= 9; i++)
            {
                if (IsValid(matrix, currentRow, currentCol, i))
                {
                    matrix[currentRow, currentCol] = i;

                    if (SolveSudoku(matrix, currentRow, currentCol + 1))
                    {
                        return true;
                    }

                    matrix[currentRow, currentCol] = 0;
                }
            }

            return false;
        }

        private static bool IsValid(int[,] matrix, int row, int col, int inputNumber)
        {
            for (int i = 0; i < 9; i++)
            {

                // (row or col) / 3 * 3 gives the position of the 3x3 quare on the board
                // i % 3 , i / 3 gives the indexing in the 3x3 quare
                if (matrix[i, col] == inputNumber ||
                    matrix[row, i] == inputNumber ||
                    matrix[row / 3 * 3 + i / 3, col / 3 * 3 + i % 3] == inputNumber)
                {
                    return false;
                }
            }

            return true;

        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
