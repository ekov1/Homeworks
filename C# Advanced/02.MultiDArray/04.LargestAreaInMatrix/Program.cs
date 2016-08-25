using System;
using System.Linq;

namespace _03.SequenceInMatrix
{
    class Program
    {
        static int currentNum;
        static int rows;
        static int cols;
        static int[,] arr = new int[rows, cols];

        static void FindAllNumbers(int row, int col)
        {
            
            if (row < 0 || col < 0 || row >= arr.GetLength(0) || col >= arr.GetLength(1))
            {
                return; //Out of boundaries
            }
            if (row == arr.GetLength(0) - 1 && col == arr.GetLength(1) - 1)
            {
                return;  //End of grid
            }
            int count = 1;
            if (currentNum != arr[row, col])
            {
                return;
            }

            count++;

                FindAllNumbers(row - 1, col); //Up
                FindAllNumbers(row, col - 1); //Left
                FindAllNumbers(row + 1, col); //Down
                FindAllNumbers(row, col + 1); //Right
        }
        static void Main()
        {   //Input
            string[] sizes = Console.ReadLine().Split(' ');
            rows = Convert.ToInt32(sizes[0]);
            cols = Convert.ToInt32(sizes[1]);

            for (int i = 0; i < rows; i++)
            {
                string[] arrayFil = Console.ReadLine().Split(' ');

                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = Convert.ToInt32(arrayFil[j]);
                }
            }
            // Searching for largest area
            
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    currentNum = arr[row, col];
                    FindAllNumbers(row, col);
                }
            }
        }

    }
}
