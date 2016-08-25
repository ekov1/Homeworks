using System;

namespace _05.LargerThanNeighbours
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] numbers = new string[n];
            string num = Console.ReadLine();
            numbers = num.Split();
            int result = LargerNeighCnt(numbers);
            Console.WriteLine(result);
        }

        static int LargerNeighCnt(string[] numbers)
        {
            int count = 0;
            for (int i = 1; i <= numbers.Length - 2; i++)
            {
                int current = int.Parse(numbers[i]);
                
                    if (current > int.Parse(numbers[i - 1]) && current > int.Parse(numbers[i + 1]))
                    {
                        count++;
                    }
            }
            return count;
        }
    }
}
