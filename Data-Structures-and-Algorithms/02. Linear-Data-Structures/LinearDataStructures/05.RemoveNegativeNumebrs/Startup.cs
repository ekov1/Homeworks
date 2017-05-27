using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace _05.RemoveNegativeNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = NumberParser.ParseNumbers();

            var filteredNumbers = string.Join(", ", RemoveAllNegativeNumbers(numbers));

            Console.WriteLine(filteredNumbers);
        }

        private static IList<int> RemoveAllNegativeNumbers(IList<int> numbers)
        {
            var filteredNumbers = numbers
                .Where(x => x >= 0)
                .ToList();

            return filteredNumbers;
        }
    }
}
