using System;

namespace _06.BinaryToHex
{
    class Program
    {
        static void Main()
        {
            string bin = Console.ReadLine();
            long dec = BinaryToDec(bin);
            Console.WriteLine(DecToHex(dec));
        }

        static string DecToHex(long number)
        {
            string result = "";
            do
            {
                long digit = number % 16;

                if (digit >= 0 && digit <= 9)
                {
                    result = (char)(digit + '0') + result;
                }
                else if (digit >= 10 && digit <= 15)
                {
                    result = (char)(digit - 10 + 'A') + result;
                }

                number /= 16;

            } while (number != 0);

            return result;
        }

        static long BinaryToDec(string binary)
        {
            long result = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                int digit = binary[i] - '0';
                int position = binary.Length - i - 1;
                result += digit * ((long)Math.Pow(2, position));

            }

            return result;
        }
    }
}
