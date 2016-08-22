using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.NumberAsArray
{
    class Program
    {
        static void Main()
        {
            string[] sizes = new string[2];
            string size = Console.ReadLine();
            sizes = size.Split();
            byte[] firstNumber = Console.ReadLine().Split(' ').Select(byte.Parse).ToArray();
            byte[] secondNumber = Console.ReadLine().Split(' ').Select(byte.Parse).ToArray();

            List<int> result = SumNumbers(firstNumber, secondNumber);
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static List<int> SumNumbers(byte[] firstNumber, byte[] secondNumber)
        {
            int max = Math.Max(firstNumber.Length, secondNumber.Length);

            List<int> sumOfNums = new List<int>();
            byte[] biggerNum = firstNumber.Length > secondNumber.Length ? firstNumber : secondNumber;
            int min = Math.Min(firstNumber.Length, secondNumber.Length);
            int addition = 0;
            for (int i = 0; i < min ; i++)
            {
                int sum = firstNumber[i] + secondNumber[i] + addition;
                if (sum >= 10)
                {
                    addition = 1;
                    sum = sum % 10;
                    sumOfNums.Add(sum);
                }
                else
                {
                    sumOfNums.Add(sum);
                    addition = 0;
                }
            }
            for (int i = min; i < max; i++)
            {

                int sum = biggerNum[i] + addition;
                if (sum >= 10)
                {
                    addition = 1;
                    sum = sum % 10;
                    sumOfNums.Add(sum);
                }
                else
                {
                    sumOfNums.Add(sum);
                    addition = 0;
                }
            }
            if (addition == 1)
            {
                sumOfNums.Add(1);
            }
            return sumOfNums;
        }
    }
}
