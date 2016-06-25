using System;

namespace _05.HexToBinary
{
    class Program
    {
        static void Main()
        {
            string hex = Console.ReadLine();
            long dec = HexToDec(hex);
            Console.WriteLine(DecToBinary(dec));
        }

        static long HexToDec(string hexNum)
        {
            int ditit = 0;
            long result = 0;
            for (int i = 0; i < hexNum.Length; i++)
            {
                if (hexNum[i] >= '0' && hexNum[i] <= '9')
                {
                    ditit = hexNum[i] - '0';
                }
                else if (hexNum[i] >= 'A' && hexNum[i] <= 'F')
                {
                    ditit = hexNum[i] - 'A' + 10;
                }

                result += ditit * ((long)Math.Pow(16, hexNum.Length - i - 1));
            }

            return result;
        }

        static string DecToBinary(long number)
        {
            string result = "";
            do
            {
                long digit = number % 2;
                result = digit + result;
                number /= 2;

            } while (number != 0);

            return result;
        }
    }
}
