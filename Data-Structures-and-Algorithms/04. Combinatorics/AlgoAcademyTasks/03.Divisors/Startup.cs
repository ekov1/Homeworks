using System;
using System.Collections.Generic;

namespace Divisors
{
    // BGCoder : 60/100
    public class Startup
    {
        private static HashSet<int> uniquePermutations = new HashSet<int>();

        public static void Main()
        {
            var numbers = ParseInput();
            Console.WriteLine(FindMinDivisorsCount(numbers));
        }

        private static void GetPermutations(int[] permutation, int[] set, bool[] indexInUse, int index)
        {
            if (index == permutation.Length)
            {
                uniquePermutations.Add(int.Parse(string.Join("", permutation)));
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

        private static List<int> GenerateCombinations(int[] numbers)
        {
            return new List<int>();
        }

        private static int FindMinDivisorsCount(int[] numbers)
        {
            GetPermutations(new int[numbers.Length], numbers, new bool[numbers.Length], 0);
            var numbersDivisors = new Dictionary<int, int>();

            foreach (var number in uniquePermutations)
            {
                var divisors = FindDivisorsCount(number);

                numbersDivisors[number] = divisors;
            }

            return FindMinElementInDict(numbersDivisors);
        }

        private static int FindMinElementInDict(Dictionary<int, int> dict)
        {
            int minElement = 0;
            int minValue = 500;

            foreach (var item in dict)
            {
                if (item.Value < minValue)
                {
                    minValue = item.Value;
                    minElement = item.Key;
                }
            }

            return minElement;
        }

        private static List<int> FindNumberDivisors(int number)
        {
            var divisors = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            }

            return divisors;
        }

        private static int FindDivisorsCount(int number)
        {
            return FindNumberDivisors(number).Count;
        }

        private static int[] ParseInput()
        {
            var numbersCount = int.Parse(Console.ReadLine());
            var numbers = new int[numbersCount];

            for (int i = 0; i < numbersCount; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            return numbers;
        }
    }
}
