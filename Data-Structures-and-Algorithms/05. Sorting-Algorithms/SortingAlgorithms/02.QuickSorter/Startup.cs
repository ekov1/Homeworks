using System;
using Utils;

namespace _02.QuickSorter
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = NumbersGenerator.GenerateNumberArray(50);
            NumbersGenerator.ShuffleNumbers(numbers);

            Console.WriteLine(string.Join(" ", numbers));

            var sortedNumbers = QuickSorter.Sort(numbers);
            Console.WriteLine(string.Join(" ", sortedNumbers));

            //InsertionSorter.Sort(numbers);
            //Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
