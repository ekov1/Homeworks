using System;

namespace _02.GetLargestNum
{
    class Program
    {
        static void Main()
        {
            string[] numbers = new string[3];
            string num = Console.ReadLine();
            numbers = num.Split();
            int max = GetMax(numbers);
            Console.WriteLine(max);
        }

        static int GetMax(params string[] numbers)
        {
            int best = int.MinValue;
            int curr = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                curr = int.Parse(numbers[i]);
                if (curr > best)
                {
                    best = curr;
                }
            }
            return best;
        }
    }
}
