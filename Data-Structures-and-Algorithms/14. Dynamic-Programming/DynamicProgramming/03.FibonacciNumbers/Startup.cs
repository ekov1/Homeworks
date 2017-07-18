using System;

namespace _03.FibonacciNumbers
{
    public class Startup
    {
        private static long[] memory = new long[200];

        public static void Main()
        {
            for (int i = 1; i < 90; i++)
            {
                Console.WriteLine(Fibonacci(i));
            }
        }

        private static long Fibonacci(int n)
        {
            if (memory[n] != 0)
            {
                return memory[n];
            }

            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }

            memory[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            return memory[n];
        }
    }
}
