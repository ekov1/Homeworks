using System;

namespace _01.DecToBinary
{
    class Program
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(DecToBinary(number));
        }

        static string DecToBinary(long number)
        {
            string result = "";
            do
            {
                long digit = number % 2;
                result = digit + result;
                number /= 2;

            } while (number !=0);

            return result;
        }
    }
}
