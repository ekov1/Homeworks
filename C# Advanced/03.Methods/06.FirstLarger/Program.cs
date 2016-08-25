using System;

namespace _06.FirstLarger
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] numbers = new string[n];
            string num = Console.ReadLine();
            numbers = num.Split();
            int result = FirstLargerNum(numbers);
            Console.WriteLine(result);
        }

        static int FirstLargerNum(string[] numbers)
        {
            int current = 0;
            int i;
            for (i = 0; i < numbers.Length - 1; i++)
            {
                current = int.Parse(numbers[i]);

                if (current > int.Parse(numbers[i + 1]))
                {
                    break;
                }
            }
            return i;
        }
    }
}
