namespace MatrixWalk
{
    using System;

    public class Matrix
    {
        public static void Main()
        {
            //Console.WriteLine("Enter a positive number ");
            //string input = Console.ReadLine();
            //int n = 0;

            //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            //{
            //    Console.WriteLine("You haven't entered a correct positive number");
            //    input = Console.ReadLine();
            //}

            int n = 3;
            int[,] matrica = new int[n, n];
            int step = n,
                k = 1,
                i = 0,
                j = 0,
                dx = 1,
                dy = 1;

            while (true)
            {
                matrica[i, j] = k;

                if (!proverka(matrica, i, j))
                {
                    PrintMatrixSteps(matrica);
                    break;
                }

                if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrica[i + dx, j + dy] != 0)
                {
                    while (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrica[i + dx, j + dy] != 0)
                    {
                        change(ref dx, ref dy);
                    }
                }

                i += dx;
                j += dy;
                k++;
            }
        }

        private static void PrintMatrixSteps(int[,] matrix)
        {
            int rowsNumber = matrix.GetLength(0);

            for (int row = 0; row < rowsNumber; row++)
            {
                for (int col = 0; col < rowsNumber; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void change(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;

            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }

            dx = dirX[cd + 1];
            dy = dirY[cd + 1];
        }

        private static bool proverka(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }

            return false;
        }

        private static void find_cell(int[,] matrix, out int x, out int y)
        {
            int rowsNumber = matrix.GetLength(0);
            x = 0;
            y = 0;

            for (int i = 0; i < rowsNumber; i++)
            {
                for (int j = 0; j < rowsNumber; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }
    }
}
