using System;
using System.Linq;

namespace _01.NestedLoopWithRecursion
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Enter a number N:");
            var n = int.Parse(Console.ReadLine());

            LoopNumbers(n, "", n);
        }

        private static void LoopNumbers(int n, string resultString, int digitLength)
        {
            if (n == 0)
            {
                var splittedString = resultString.ToArray();
                Console.WriteLine(string.Join(" ", splittedString));
                return;
            }

            for (int i = 1; i <= digitLength; i++)
            {
                LoopNumbers(n - 1, resultString + i, digitLength);
            }
        }
    }
}
