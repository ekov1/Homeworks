using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace _08.FindMajorant
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = NumberParser.ParseCollectionNumbers();

            var majorant = GetMajorant(numbers);

            Console.WriteLine(majorant);
        }

        private static int GetMajorant(IList<int> numbers)
        {
            var majorant = int.MinValue;

            var uniqueNumbers = numbers
                .Distinct()
                .OrderBy(x => x)
                .ToArray();

            for (int i = 0; i < uniqueNumbers.Length; i++)
            {
                var occurances = numbers.Where(x => x == uniqueNumbers[i]).Count();

                if ((numbers.Count / 2) + 1 <= occurances && uniqueNumbers[i] > majorant)
                {
                    majorant = uniqueNumbers[i];
                }
            }

            return majorant;
        }
    }
}
