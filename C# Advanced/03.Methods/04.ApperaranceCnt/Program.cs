using System;

namespace _04.ApperaranceCnt
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] numbers = new string[n];
            string num = Console.ReadLine();
            numbers = num.Split();
            int x = int.Parse(Console.ReadLine());
            int result = AppCount(numbers, x);
            Console.WriteLine(result);
        }

        static int AppCount(string[] numbers, int x)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (int.Parse(numbers[i]) == x)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
