using System;
using System.Linq;

namespace _04.PermutationsOfANumber
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Enter a number N:");
            var numbersLength = int.Parse(Console.ReadLine());

            var numbers = new int[numbersLength];

            GetPermutations(numbers, 1, numbersLength, 0);
        }

        private static void GetPermutations(int[] numbers, int startNumber, int endNumber, int index)
        {
            if (index == numbers.Length)
            {
                Console.WriteLine("{" + string.Join(", ", numbers) + "}");
            }

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (numbers.Contains(i))
                {
                    continue;
                }

                numbers[index] = i;
                GetPermutations(numbers, startNumber, endNumber, index + 1);
                numbers[index] = 0;
            }
        }
    }
}
