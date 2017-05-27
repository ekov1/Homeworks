using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace _06.RemoveOddOccurances
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = NumberParser.ParseNumbers();
            var filteredNumbers = RemoveOddOccurances(numbers);

            Console.WriteLine(string.Join(", ", filteredNumbers));
        }

        private static IList<int> RemoveOddOccurances(IList<int> numbers)
        {
            var uniqueNumbers = numbers
                .Distinct()
                .ToArray();

            for (int i = 0; i < uniqueNumbers.Length; i++)
            {
                var numberOccurances = numbers
                    .Where(x => x == uniqueNumbers[i])
                    .Count();

                if (numberOccurances % 2 == 1)
                {
                    numbers = numbers
                        .Where(x => x != uniqueNumbers[i])
                        .ToList();
                }
            }

            return numbers;
        }
    }
}
