using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace AverageAndSumOfNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = NumberParser.ParseNumbers();

            Console.WriteLine($"Sum of numbers -> {numbers.Sum()}");
            Console.WriteLine($"Average of numbers -> {numbers.Average()}");
        }
    }
}
