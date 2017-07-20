using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SuperSum
{
    // For input : 200 200
    // Dynamic approach time: 0.687
    // Recursion with memoization approach time: 1.022
    public class Startup
    {
        private static BigInteger?[,] partials;

        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            partials = new BigInteger?[input[0] + 1, input[1] + 1];

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = SuperSumDynamic(input[0], input[1]);
            //var result = SuperSumRecursive(input[0], input[1]);
            Console.WriteLine(result);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        private static BigInteger? SuperSumRecursive(int k, int n)
        {
            if (k == 0)
            {
                return n;
            }

            if (partials[k, n] != null)
            {
                return partials[k, n];
            }

            BigInteger? result = 0;
            for (int i = 1; i <= n; i++)
            {
                var currentSum = SuperSumRecursive(k - 1, i);
                partials[k - 1, i] = currentSum;

                result += currentSum;
            }

            return result;
        }

        private static BigInteger SuperSumDynamic(int k, int n)
        {
            var partialSums = new BigInteger[k + 1, n + 1];

            for (int i = 0; i <= k; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == 0)
                    {
                        partialSums[i, j] = j;
                    }
                    else
                    {
                        BigInteger sum = 0;

                        for (int m = 1; m <= j; m++)
                        {
                            sum += partialSums[i - 1, m];
                        }

                        partialSums[i, j] = sum;
                    }
                }
            }

            return partialSums[k, n];
        }

        private static void PrintMatrix(BigInteger?[,] matrix)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    builder.Append(matrix[i, j] + " ");
                }

                builder.AppendLine();
            }

            Console.WriteLine(builder.ToString());
        }
    }
}
