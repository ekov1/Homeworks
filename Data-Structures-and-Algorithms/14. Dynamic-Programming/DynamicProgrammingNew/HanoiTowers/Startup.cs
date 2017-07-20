using System;
using System.Collections.Generic;
using System.Linq;

namespace HanoiTowers
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            SolveGame(n, 'a', 'b', 'c');
        }

        private static void SolveGame(int n, char source, char mid, char dest)
        {
            if (n == 1)
            {
                Console.WriteLine($"Moving {n} from {source} to {dest}");
                return;
            }

            SolveGame(n - 1, source, dest, mid);
            Console.WriteLine($"Moving {n} from {source} to {dest}");
            SolveGame(n - 1, mid, source, dest);
        }
    }
}
