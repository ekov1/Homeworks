using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SortingArray
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] numbers = new string[n];
            string num = Console.ReadLine();
            numbers = num.Split(' ');

            string res = SortArray(numbers);
            Console.WriteLine(res);
        }

        static string SortArray(string[] numbers)
        {
            //Selection Sort
            int[] sortedNums = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                sortedNums[i] = int.Parse(numbers[i]);
            }

            int smallest = sortedNums[0];

            for (int k = 0; k < sortedNums.Length; k++)
            {
                smallest = sortedNums[k];
                for (int i = k; i < sortedNums.Length; i++)
                {
                    if (sortedNums[i] < smallest)
                    {
                        smallest = sortedNums[i];
                        sortedNums[i] = sortedNums[k];
                        sortedNums[k] = smallest;
                    }
                }
            }
            string result = "";
            for (int i = 0; i < sortedNums.Length; i++)
            {
                result += sortedNums[i] + " ";
            }
            return result;
        }
    }
}
