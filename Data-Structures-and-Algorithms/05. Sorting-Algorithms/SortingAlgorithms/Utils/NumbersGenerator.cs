using System;
using System.Collections.Generic;

namespace Utils
{
    public class NumbersGenerator
    {
        public static List<int> GenerateNumberArray(int maxValue)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < maxValue; i++)
            {
                result.Add(i);
            }

            return result;
        }

        public static void ShuffleNumbers(IList<int> numberArray)
        {
            Random random = new Random();

            for (int i = 0; i < numberArray.Count - 1; i++)
            {
                int randomIndex = random.Next(i, numberArray.Count);

                ArrayInteraction<int>.SwapValues(numberArray, i, randomIndex);
            }
        }
    }
}
