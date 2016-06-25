using System;

namespace _01.FillTheMatrix
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char ch = char.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            int k = 1;
            int col = 0;
            int row = 0;
            if (ch == 'a')
            {
                for (col = 0; col < arr.GetLength(1); col++)
                {
                    for (row = 0; row < arr.GetLength(0); row++)
                    {
                        arr[row, col] = k;
                        k++;
                    }
                }
            }
            else if (ch == 'b')
            {
                for (col = 0; col < arr.GetLength(1); col++)
                {
                    if (col % 2 == 0)
                    {
                        for (row = 0; row < arr.GetLength(0); row++)
                        {

                            arr[row, col] = k;
                            k++;
                        }
                    }
                    else
                    {
                        for (row = arr.GetLength(0) - 1; row >= 0; row--)
                        {
                            arr[row, col] = k;
                            k++;
                        }
                    }
                }
            }
            else if (ch == 'c')
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    row = i;
                    col = 0;
                    while (row < n && col < n)
                    {
                        arr[row++, col++] = k++;
                    }
                }

                for (int j = 1; j < n; j++)
                {
                    row = j;
                    col = 0;
                    while (row < n && col < n)
                    {
                        arr[col++, row++] = k++;
                    }
                }
            }
            else if (ch == 'd')
            {
                int offset = 0;
                while (k <= n * n)           
                {
                    
                    for (row = offset; row < n - offset; row++)
                    {
                        col = offset;
                        arr[row, col] = k;
                        k++;
                    }
                    for (col = 1 + offset; col < n - offset; col++)
                    {
                        row = n - 1 - offset;
                        arr[row, col] = k;
                        k++;
                    }
                    for (row = n - 2 - offset; row >= offset; row--)
                    {
                        col = n - 1 - offset;
                        arr[row, col] = k;
                        k++;
                    }
                    for (col = n - 2 - offset; col >= offset + 1; col--)
                    {
                        row = offset;
                        arr[row, col] = k;
                        k++;
                    }
                    offset++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < n - 1)
                    {
                        Console.Write(arr[i, j] + " ");
                    }
                    else if (j == n -1)
                    {
                        Console.Write(arr[i, j]);
                    }
                        
                }
                Console.WriteLine();
            }
        }
    }
}
