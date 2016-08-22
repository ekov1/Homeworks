using System;

namespace _03.DecimalToHex
{
    class Program
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(DecToHex(number));
        }

        static string DecToHex(long dec)
        {
            string result = "";
            do
            {
                long digit = dec % 16;

                if (digit >= 0 && digit <= 9)
                {
                    result = (char)(digit + '0') + result;
                }
                else if (digit >= 10 && digit <= 15)
                {
                    result = (char)(digit - 10 + 'A') + result;
                }

                dec = dec / 16;

            } while (dec != 0);

            return result;
        }
    }
}
