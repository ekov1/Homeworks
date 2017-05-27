using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.UniquePermutations
{
    public class Startup
    {
        private static HashSet<string> uniquePermutations = new HashSet<string>();

        public static void Main()
        {
            Console.WriteLine("Enter a set of numbers separated by a space:");
            var numbersSet = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            var permutationSet = new int[numbersSet.Length];
            var indexInUse = new bool[numbersSet.Length];

            GetPermutations(permutationSet, numbersSet, indexInUse, 0);

            PrintPermutations();
        }

        private static void PrintPermutations()
        {
            foreach (var perm in uniquePermutations)
            {
                Console.WriteLine(perm);
            }
        }

        private static void GetPermutations(int[] permutation, int[] set, bool[] indexInUse, int index)
        {
            if (index == permutation.Length)
            {
                var permString = "{" + string.Join(", ", permutation) + "}";
                uniquePermutations.Add(permString);

                return;
            }

            // Need to optimize it to work with bigger sets of numbers
            for (int i = 0; i < set.Length; i++)
            {
                if (!indexInUse[i])
                {
                    indexInUse[i] = true;
                    permutation[index] = set[i];

                    GetPermutations(permutation, set, indexInUse, index + 1);

                    indexInUse[i] = false;
                }
            }
        }
    }
}
