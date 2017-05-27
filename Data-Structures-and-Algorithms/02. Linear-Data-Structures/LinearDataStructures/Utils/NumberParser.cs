using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class NumberParser
    {
        public static List<int> ParseNumbers()
        {
            var line = string.Empty;
            var numbersList = new List<int>();

            line = Console.ReadLine();

            while (line != string.Empty)
            {
                numbersList.Add(int.Parse(line));
                line = Console.ReadLine();
            }

            return numbersList;
        }

        public static List<int> ParseCollectionNumbers()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToList();

            return numbers;
        }
    }
}
