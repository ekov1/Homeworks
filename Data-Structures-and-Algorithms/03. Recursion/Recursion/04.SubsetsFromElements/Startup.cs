using System;
using System.Linq;

namespace _04.SubsetsFromElements
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Enter numbers N and K:");
            var nAndK = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            Console.WriteLine("Enter set of elements separated by a space:");
            var set = Console.ReadLine().Split(' ');
            var newSet = new string[nAndK[1]];

            GetSubsets(newSet, set, 0);
        }

        private static void GetSubsets(string[] combination, string[] set, int index)
        {
            if (index == combination.Length)
            {
                Console.WriteLine($"({string.Join(", ", combination)})");
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                combination[index] = set[i];
                GetSubsets(combination, set, index + 1);
            }
        }
    }
}
