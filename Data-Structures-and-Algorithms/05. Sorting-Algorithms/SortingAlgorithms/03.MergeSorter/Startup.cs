using System;
using Utils;

namespace _03.MergeSorter
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = NumbersGenerator.GenerateNumberArray(50);
            NumbersGenerator.ShuffleNumbers(numbers);

            Console.WriteLine(string.Join(" ", numbers));

            var sortedNumbers = Utils.MergeSorter.Sort(numbers);

            Console.WriteLine(string.Join(" ", sortedNumbers));
        }
    }
}
