using System;

namespace _08.SumOfIntegers
{
    class Program
    {
        static void Main()
        {
            string numbers = Console.ReadLine();
            string[] arrNumbers = numbers.Split();
            SumNumbers(arrNumbers);
        }

        static void SumNumbers(string[] numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += int.Parse(numbers[i]);
            }
            Console.WriteLine(sum);
        }
    }
}
