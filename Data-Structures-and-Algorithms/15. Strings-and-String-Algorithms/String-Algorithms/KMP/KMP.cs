using System;
using System.Collections.Generic;
using System.Linq;

namespace KMP
{
    public class KMP
    {
        private int[] precomputedArray;

        public KMP(string pattern, string text)
        {
            this.precomputedArray = this.PrecomputePattern(pattern);
        }

        public void SearchInArray(string pattern, string text)
        {
            var j = 0;
            var i = 0;
            var counter = 0;

            for (i = 0; i < text.Length;)
            {
                if (j >= precomputedArray.Length)
                {
                    PrintMatch(i - counter, pattern.Substring(j - counter, counter));
                    return;
                }

                if (text[i] == pattern[j])
                {
                    ++counter;
                    ++i;
                    ++j;
                }
                else if (text[i] != pattern[j] && j > 0)
                {
                    counter = 0;
                    j = this.precomputedArray[j - 1];
                }
                else
                {
                    counter = 0;
                    ++i;
                }
            }

            if (j >= precomputedArray.Length)
            {
                PrintMatch(i - counter, pattern.Substring(j - counter, counter));
                return;
            }
        }

        private int[] PrecomputePattern(string pattern)
        {
            var result = new int[pattern.Length];
            var j = 0;

            for (int i = 1; i < pattern.Length;)
            {
                if (pattern[i] == pattern[j])
                {
                    result[i] = j + 1;
                    ++i;
                    ++j;
                }
                else if (pattern[i] != pattern[j] && j > 0)
                {
                    while (j > 0)
                    {
                        if (pattern[j] == pattern[i])
                        {
                            result[i] = j + 1;
                            break;
                        }

                        j = result[j - 1];
                    }
                    ++i;

                }
                else
                {
                    i++;
                }
            }

            return result;
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
