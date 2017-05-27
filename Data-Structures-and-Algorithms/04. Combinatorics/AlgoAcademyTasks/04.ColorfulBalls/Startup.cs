using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ColorfulBalls
{
    public class Startup
    {
        public static void Main()
        {
            var stopwatch = new Stopwatch();

            var set = (Console.ReadLine()).ToArray();

            stopwatch.Start();

            var groups = GetUniqueItemCount(set);

            var permutationsCount = GetCombinations(set, new List<char>(), groups, groups.Sum());

            Console.WriteLine(permutationsCount);

            Console.WriteLine(stopwatch.Elapsed);
        }

        private static List<int> GetUniqueItemCount(char[] set)
        {
            var uniqueSet = set.Distinct().ToList();
            var groups = new List<int>();

            for (int i = 0; i < uniqueSet.Count; i++)
            {
                groups.Add(set.Count(x => x == uniqueSet[i]));
            }

            return groups;
        }

        private static long GetCombinations(char[] set, List<char> permutation, List<int> groups, int k)
        {
            if (k == permutation.Count)
            {
                return 1;
            }

            long total = 0;

            for (int i = 1; i <= groups.Count; i++)
            {
                if (groups[i - 1] == 0)
                {
                    continue;
                }

                permutation.Add(set[i - 1]);
                groups[i - 1]--;

                total += GetCombinations(set, permutation, groups, k);

                groups[i - 1]++;
                permutation.RemoveAt(permutation.Count - 1);
            }

            return total;
        }

        private static long GetPermutations(int[] permutation, int[] set, bool[] indexInUse, int index)
        {
            if (index == permutation.Length)
            {
                return 1;
            }

            long total = 0;

            // Need to optimize it to work with bigger sets of numbers
            for (int i = 0; i < set.Length; i++)
            {
                if (!indexInUse[i])
                {
                    indexInUse[i] = true;
                    permutation[index] = set[i];

                    total += GetPermutations(permutation, set, indexInUse, index + 1);

                    indexInUse[i] = false;
                }
            }

            return total;
        }
    }
}
