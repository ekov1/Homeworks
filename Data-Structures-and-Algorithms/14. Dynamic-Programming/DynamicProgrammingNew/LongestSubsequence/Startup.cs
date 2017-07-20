using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestSubsequence
{
    public class Startup
    {
        public static void Main()
        {
            var a = "ABCBDAB";
            var b = "BDCABA";

            var subSolutions = LongestSubSequenceDynamic(a, b);

            PrintMatrix(subSolutions);

            ShowLongestSubsequence(subSolutions, a, b, a.Length, b.Length);
            Console.WriteLine();
        }

        private static void ShowLongestSubsequence(int[,] subSolutions, string first, string second, int currentRow, int currentCol)
        {
            if (currentRow == 0 || currentCol == 0)
            {
                return;
            }

            if (first[currentRow - 1] == second[currentCol - 1])
            {
                ShowLongestSubsequence(subSolutions, first, second, currentRow - 1, currentCol - 1);
                Console.Write(first[currentRow - 1]);
            }
            else if(subSolutions[currentRow - 1, currentCol] > subSolutions[currentRow, currentCol - 1])
            {
                ShowLongestSubsequence(subSolutions, first, second, currentRow - 1, currentCol);
            }
            else
            {
                ShowLongestSubsequence(subSolutions, first, second, currentRow, currentCol - 1);
            }
        }

        private static int[,] LongestSubSequenceDynamic(string first, string second)
        {
            var subSolutions = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        subSolutions[i, j] = subSolutions[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        subSolutions[i, j] = Math.Max(subSolutions[i - 1, j], subSolutions[i, j - 1]);
                    }
                }
            }

            return subSolutions;
        }

        private static int LongestSubSequence(string first, string second)
        {
            if (first.Length == 0 || second.Length == 0)
            {
                return 0;
            }

            if (first[first.Length - 1] == second[second.Length - 1])
            {
                Console.WriteLine(first[first.Length - 1]);
                return LongestSubSequence(first.Substring(0, first.Length - 1), second.Substring(0, second.Length - 1)) + 1;
            }

            return Math.Max(LongestSubSequence(first.Substring(0, first.Length - 1), second),
                LongestSubSequence(first, second.Substring(0, second.Length - 1)));
        }

        private static void PrintMatrix(int[,] matrix)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    builder.Append(matrix[i, j] + " ");
                }

                builder.AppendLine();
            }

            Console.WriteLine(builder.ToString());
        }
    }
}
