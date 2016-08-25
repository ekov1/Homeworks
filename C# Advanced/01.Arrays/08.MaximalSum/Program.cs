using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MaxSumSequence
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        int tempSum = 0;
        int bestSum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        if (numbers.Min() >= 0)
        {
            Console.WriteLine(numbers.Sum());
        }
        else if (numbers.Max() <= 0)
        {
            Console.WriteLine(numbers.Max());
        }
        else
        {
            
            StringBuilder sequenceJoined = new StringBuilder();
            List<int> sequence = new List<int>();

            foreach (var number in numbers)
            {
                sequence.Add(number);
                tempSum += number;
                if (tempSum <= 0)
                {
                    tempSum = 0;
                    sequence.Clear();
                }
                else if (tempSum > bestSum)
                {
                    bestSum = tempSum;
                }
            }
            Console.WriteLine(bestSum);
        }
    }
}

