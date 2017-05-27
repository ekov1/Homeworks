using System;

namespace _01.HanoiTowers
{
    class Startup
    {
        static void Main()
        {
            ArrangeTowers(5, 'A', 'B', 'C');
        }

        private static void ArrangeTowers(int n, char from, char mid, char to)
        {
            if (n == 1)
            {
                Console.WriteLine($"Moving 1 from {from} to {to}");
                return;
            }

            ArrangeTowers(n - 1, from, to, mid);
            Console.WriteLine($"Moving {n} from {from} to {to}");
            ArrangeTowers(n - 1, mid, from, to);
        }
    }
}
