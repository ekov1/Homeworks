using System;
using Utils;

namespace _01.SelectionSorter
{
    public class Startup
    {
        public static void Main()
        {
            var initialNumbers = NumbersGenerator.GenerateNumberArray(50);
            NumbersGenerator.ShuffleNumbers(initialNumbers);

            Console.WriteLine("Unsorted numbers\n" + string.Join(" ", initialNumbers) + Environment.NewLine);

            SelectionSorter.Sort(initialNumbers);

            Console.WriteLine("Sorted numbers\n" + string.Join(" ", initialNumbers));
        }
    }
}
