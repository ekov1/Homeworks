using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Teams
{
    class Program
    {
        private static bool[][] matrix;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            matrix = new bool[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new bool[n];
                var currentLine = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    if (i ==j || currentLine[j] == '1')
                    {
                        matrix[i][j] = true;
                    }
                }
            }

            // Solution

            WarshallAlgorithm(n);

            var result = new int[] { 0, 0 };

            for (int i = 0; i < n; i++)
            {
                var isGood = true;

                for (int j = 0; j < n && isGood; j++)
                {
                    if (!matrix[i][j])
                    {
                        isGood = false;
                    }
                }

                if (isGood)
                {
                    result[0]++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                var isGood = true;

                for (int j = 0; j < n && isGood; j++)
                {
                    if (!matrix[j][i])
                    {
                        isGood = false;
                    }
                }

                if (isGood)
                {
                    result[1]++;
                }
            }

            Console.WriteLine(result[0]);
            Console.WriteLine(result[1]);
        }

        public static void WarshallAlgorithm(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (!matrix[j][k])
                        {
                            matrix[j][k] = (matrix[j][i] && matrix[i][k]);
                        }
                    }
                }
            }
        }
    }
}
