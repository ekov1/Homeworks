using System;

namespace _06.AllSubsetFromElements
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Enter subset length:");
            var subsetLength = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a set of elements separated by a space:");
            var elementsSet = Console.ReadLine().Split(' ');

            var newSet = new string[subsetLength];

            GetSubsets(elementsSet, newSet, 0, 0);
        }

        private static void GetSubsets(string[] set, string[] subset, int startIndex, int currentIndex)
        {
            if (currentIndex == subset.Length)
            {
                Console.WriteLine($"({string.Join(", ", subset)})");
                return;
            }

            for (int i = startIndex; i < set.Length; i++)
            {
                subset[currentIndex] = set[i];
                GetSubsets(set, subset, i + 1, currentIndex + 1);
            }
        }
    }
}
