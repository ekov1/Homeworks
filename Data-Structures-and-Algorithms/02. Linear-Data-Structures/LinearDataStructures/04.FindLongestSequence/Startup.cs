using System;
using System.Collections.Generic;
using Utils;

namespace _04.FindLongestSequence
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = NumberParser.ParseNumbers();
            var startIndex = -1;
            var sequenceLength = 0;
            var bestSequenceLength = 0;
            var resultSequence = new List<int>();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1] && startIndex < 0)
                {
                    startIndex = i;
                    sequenceLength = 2;
                }
                else if (numbers[i] == numbers[i + 1])
                {
                    sequenceLength += 1;
                }
                else
                {
                    if (sequenceLength > bestSequenceLength)
                    {
                        bestSequenceLength = sequenceLength;

                        resultSequence.Clear();
                        resultSequence = numbers.GetRange(startIndex, sequenceLength);
                        startIndex = -1;
                        sequenceLength = 0;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", resultSequence));
        }
    }
}
