using System;
using System.Diagnostics;
using Utils;

namespace PerformanceTesting
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = NumbersGenerator.GenerateNumberArray(1000);
            var testCount = 100;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < testCount; i++)
            {
                NumbersGenerator.ShuffleNumbers(numbers);
                QuickSorter.Sort(numbers, true);
            }

            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
