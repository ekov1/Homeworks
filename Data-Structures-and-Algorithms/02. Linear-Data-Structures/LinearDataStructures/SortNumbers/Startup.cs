using System;
using System.Linq;
using Utils;

namespace SortNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = NumberParser.ParseNumbers();

            var sortedNumbers = numbers
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(", ", sortedNumbers));
        }
    }
}
