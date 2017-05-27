using System;

namespace _12._8QueensPuzzle
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Enter queens count:");
            var queensLeft = int.Parse(Console.ReadLine());

            var matrix = new int[queensLeft, queensLeft];


            Console.WriteLine("Ways to place queens on board = " + PlaceQueen(matrix, queensLeft));
        }

        private static int PlaceQueen(int[,] matrix, int queensLeft)
        {
            if (queensLeft == 0)
            {
                return 1;
            }

            var total = 0;

            // The board is being filled up from the bottom and everytime we are searching only
            // the lower side, lower-left and lower-right diagonal

            var deltaX = new int[] { 1, 0, -1 };
            var deltaY = new int[] { 1, 1, 1 };

            // Puts only 1 queen each row
            int i = queensLeft - 1;

            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                var isOkayToPlace = true;

                for (int j = 0; isOkayToPlace && j < deltaX.Length; j++)
                {
                    var x = i;
                    var y = k;

                    while (IsInRange(matrix, x, y))
                    {
                        if (matrix[x, y] != 0)
                        {
                            isOkayToPlace = false;
                            break;
                        }

                        x += deltaY[j];
                        y += deltaX[j];
                    }
                }

                if (isOkayToPlace)
                {
                    matrix[i, k] = queensLeft;
                    //PrintMatrix(matrix);

                    total += PlaceQueen(matrix, queensLeft - 1);
                    matrix[i, k] = 0;
                }
            }

            return total;
        }

        private static bool IsInRange(int[,] matrix, int currentRow, int currentCol)
        {
            bool rowInRange = currentRow >= 0 && currentRow < matrix.GetLength(0);
            bool colInRange = currentCol >= 0 && currentCol < matrix.GetLength(1);

            return rowInRange && colInRange;
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
            Console.WriteLine();
        }
    }
}
