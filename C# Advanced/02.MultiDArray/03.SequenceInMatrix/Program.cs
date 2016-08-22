using System;
using System.Linq;

namespace _03.SequenceInMatrix
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(input[0]);
            int m = Convert.ToInt32(input[1]);

            int[,] numbers = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] arrayFil = Console.ReadLine().Split(' ');

                for (int j = 0; j < m; j++)
                {
                    numbers[i, j] = Convert.ToInt32(arrayFil[j]);
                }
            }

            int current = 1;
            int best = 0;

            for (int row = 0; row < int.Parse(input[0]); row++)
            {
                current = 1;
                for (int col = 0; col < int.Parse(input[1]) - 1; col++)
                {
                    if (numbers[row, col] == numbers[row, col + 1])
                    {
                        current++;
                    }
                    else
                    {
                        current = 1;
                    }
                    if (current > best)
                    {
                        best = current;
                    }
                }
            }
            for (int col = 0; col < int.Parse(input[1]); col++)
            {
                current = 1;
                for (int row = 0; row < int.Parse(input[0]) - 1; row++)
                {
                    if (numbers[row, col] == numbers[row + 1, col])
                    {
                        current++;
                    }
                    else
                    {
                        current = 1;
                    }
                    if (current > best)
                    {
                        best = current;
                    }


                }
            }
            Console.WriteLine(best);
        }

    }
}
