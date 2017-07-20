using System;
using System.Linq;

namespace Tribonacci
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var memo = new long?[input[3]];

            memo[0] = input[0];
            memo[1] = input[1];
            memo[2] = input[2];

            for (int i = 3; i < memo.Length; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2] + memo[i - 3];
            }

            Console.WriteLine(memo[memo.Length - 1]);
        }
    }
}
