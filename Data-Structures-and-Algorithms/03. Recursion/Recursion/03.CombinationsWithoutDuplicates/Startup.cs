using System;
using System.Linq;

namespace _03.CombinationsWithoutDuplicates
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Enter a numbers N and K separated by a space:");
            var nAndK = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            GetCombinations(1, nAndK[0], 0, new int[nAndK[1]]);
        }

        private static void GetCombinations(int startNumber, int endNumber, int k, int[] combination)
        {
            if (k == combination.Length)
            {
                Console.WriteLine("( {0} )", string.Join(";", combination));
                return;
            }

            for (int i = startNumber; i <= endNumber; i++)
            {
                combination[k] = i;
                GetCombinations(i + 1, endNumber, k + 1, combination);
            }
        }
    }
}
