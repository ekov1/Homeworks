using System;

namespace _04.HexToDecimal
{
    class Program
    {
        static void Main()
        {
            string hexNum = Console.ReadLine();
            Console.WriteLine(HexToDec(hexNum));
        }

        static long HexToDec(string hexNum)
        {
            int digit = 0;
            long result = 0;
            for (int i = 0; i < hexNum.Length; i++)
            {
                if (hexNum[i] >= '0' && hexNum[i] <= '9')
                {
                    digit = hexNum[i] - '0';
                }
                else if (hexNum[i] >= 'A' && hexNum[i] <= 'F')
                {
                    digit = hexNum[i] - 'A' + 10;
                }

                result += digit * ((long)Math.Pow(16, hexNum.Length - i - 1));
            }

            return result;
        }
    }
}
