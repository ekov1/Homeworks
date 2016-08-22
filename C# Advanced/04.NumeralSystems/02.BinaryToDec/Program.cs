using System;

namespace _02.BinaryToDec
{
    class Program
    {
        static void Main()
        {
            string binary = Console.ReadLine();
            Console.WriteLine(BinaryToDec(binary));
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
