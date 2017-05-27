using System;
using System.Collections.Generic;
using Utils;

namespace _02.ReversedStack
{
    public class Startup
    {
        public static void Main()
        {
            var initialNumbers = NumberParser.ParseNumbers();
            var reversedNumbers = new Stack<int>();

            Console.WriteLine("Initial numbers ->" + string.Join(", ", initialNumbers));

            for (int i = 0; i < initialNumbers.Count; i++)
            {
                reversedNumbers.Push(initialNumbers[i]);
            }

            Console.WriteLine("Reversed numbes -> " + string.Join(", ", reversedNumbers));

        }
    }
}
