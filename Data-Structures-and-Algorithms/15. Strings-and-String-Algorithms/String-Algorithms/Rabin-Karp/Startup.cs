using System;
using System.Collections.Generic;

namespace Rabin_Karp
{
    public class Startup
    {
        public static void Main()
        {
            var pattern = "lal";
            var text = "tlala alal  alalal";

            RabinKarp(pattern, text);
        }

        private static void RabinKarp(string pattern, string text)
        {
            var hashedPattern = new Hash(101, 1000000007, pattern, pattern.Length);
            var hashedText = new Hash(101, 1000000007, text, pattern.Length);

            Console.WriteLine(text);

            for (int i = 1; i <= text.Length - pattern.Length; i++)
            {
                hashedText.RollHash(text[i - 1], text[i + pattern.Length - 1]);

                if (hashedPattern.Equals(hashedText))
                {
                    PrintMatch(i, pattern);
                }
            }
        }

        public static void PrintMatch(int index, string pattern)
        {
            for (int i = 0; i < index; ++i)
            {
                Console.Write(" ");
            }

            Console.WriteLine(pattern);
        }

    }
}
