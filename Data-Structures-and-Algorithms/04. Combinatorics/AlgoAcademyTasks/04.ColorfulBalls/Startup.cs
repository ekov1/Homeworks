using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace SequenceOfBalls
{
    public class Startup
    {
        private const int MaxElementsToOccur = 30;
        private static BigInteger[] memo = new BigInteger[MaxElementsToOccur + 1];

        public static void Main()
        {
            var sequence = Console.ReadLine();
            Console.WriteLine(FindCombinations(sequence));
        }

        private static BigInteger FindCombinations(string sequence)
        {
            BigInteger allNums = Fact(sequence.Length);
            var repeatingBalls = GetUniqueItemCount(sequence.ToArray());
            BigInteger divisionNumber = 1;

            foreach (var key in repeatingBalls)
            {
                divisionNumber *= Fact(key);
            }

            return allNums / divisionNumber;
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

        private static BigInteger Fact(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            if (memo[number] == 0)
            {
                memo[number] = number * Fact(number - 1);
            }

            return memo[number];
        }
    }
}
