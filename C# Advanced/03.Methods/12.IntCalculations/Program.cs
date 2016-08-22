using System;
using System.Linq;

namespace _12.IntCalculations
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console
        .ReadLine()
        .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(item => int.Parse(item))
        .ToArray();
            Calculations(numbers);
        }

        static void Calculations(params int[] numbers)
        {
            int max = numbers.Max();
            int min = numbers.Min();
            double avg = numbers.Average();
            int sum = numbers.Sum();
            long product = 1;
            foreach (var item in numbers)
            {
                product = product * item;
            }
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(avg.ToString("0.00"));
            Console.WriteLine(sum);
            Console.WriteLine(product);
        }
    }
}
