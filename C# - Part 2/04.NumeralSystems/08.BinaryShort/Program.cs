using System;

namespace _08.BinaryShort
{
    class Program
    {
        static void Main()
        {
            short number = short.Parse(Console.ReadLine());
            Console.WriteLine(PrintNumber(number));
        }


        static string PrintNumber(short number)
        {

            string result = "";
            string[] binChar = { "0", "1"};

            for (int i = 0; i < 16; i++)
            {
                // get current 1/ 0
                result = binChar[(number & 1)] + result;

                // shift right
                number >>= 1;
            }

            //print
            return result.PadLeft(16, '0');
        }
    }

}
