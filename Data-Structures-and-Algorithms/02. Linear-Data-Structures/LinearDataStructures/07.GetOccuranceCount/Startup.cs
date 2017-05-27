using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace _07.GetOccuranceCount
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = NumberParser.ParseNumbers();
            var occurances = GetOccurancesCount(numbers);

            foreach (var record in occurances)
            {
                Console.WriteLine($"{record.Key} -> {record.Value} times");
            }
        }

        private static IDictionary<int, int> GetOccurancesCount(IList<int> numbers)
        {
            var occurances = new Dictionary<int, int>();
            var uniqueNumbers = numbers.Distinct().ToArray();

            for (int i = 0; i < uniqueNumbers.Length; i++)
            {
                var occCount = numbers
                    .Where(x => x == uniqueNumbers[i])
                    .Count();

                occurances[uniqueNumbers[i]] = occCount;
            }

            return occurances;
        }
    }
}
