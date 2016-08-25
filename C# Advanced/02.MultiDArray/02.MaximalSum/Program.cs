using System;
using System.Linq;

namespace _02.MaximalSum
{
    class Program
    {
        static void Main()
        {

            string[] input = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(input[0]);
            int m = Convert.ToInt32(input[1]);

            int[,] arr = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] arrayFil = Console.ReadLine().Split(' ');

                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = Convert.ToInt32(arrayFil[j]);
                }
            }


            int bestSum = int.MinValue;
            int sum = int.MinValue;
            for (int row = 1; row < int.Parse(input[0]) - 1; row++)
            {
                sum = 0;
                for (int col = 1; col < int.Parse(input[1]) - 1; col++)
                {
                    sum = arr[row - 1, col -1] + arr[row - 1, col] + arr[row - 1, col + 1] +
                                arr[row, col - 1] + arr[row, col] + arr[row, col + 1] +
                                arr[row + 1, col - 1] + arr[row + 1, col] + arr[row + 1, col + 1];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                    }
                }
            }
            Console.WriteLine(bestSum);
        }
    }
}
