using System;
using System.Collections.Generic;

namespace ColorfulBunnies
{
    public class Startup
    {
        public static void Main()
        {
            var bunnyAnswers = ParseInput();

            var minimumBunnies = FindBunniesCount(bunnyAnswers);

            Console.WriteLine(minimumBunnies);
        }

        private static int[] ParseInput()
        {
            var askedBunnies = int.Parse(Console.ReadLine());
            var bunnyAnswers = new int[askedBunnies];

            for (int i = 0; i < askedBunnies; i++)
            {
                bunnyAnswers[i] = int.Parse(Console.ReadLine());
            }

            return bunnyAnswers;
        }

        public static long FindBunniesCount(int[] bunnyAnswers)
        {
            var uniqueAnswers = GetUniqueAnswers(bunnyAnswers);
            long answer = 0;

            foreach (var item in uniqueAnswers)
            {
                if (item.Value == 1)
                {
                    answer += item.Key + 1;
                    continue;
                }

                answer += CalculateBunnyAnswer(item.Key, item.Value);
            }

            return answer;
        }

        private static long CalculateBunnyAnswer(int key, int value)
        {
            var groupLength = key + 1;
            var answer = 0;

            while (value > 0)
            {
                if (groupLength > value)
                {
                    answer += groupLength;
                    break;
                }

                answer += groupLength;
                value -= groupLength;
            }

            return answer;
        }

        private static Dictionary<int, int> GetUniqueAnswers(int[] bunnyAnswers)
        {
            var uniqueAnswers = new Dictionary<int, int>();

            for (int i = 0; i < bunnyAnswers.Length; i++)
            {
                if (!uniqueAnswers.ContainsKey(bunnyAnswers[i]))
                {
                    uniqueAnswers[bunnyAnswers[i]] = 1;
                    continue;
                }

                uniqueAnswers[bunnyAnswers[i]]++;
            }

            return uniqueAnswers;
        }
    }
}
