using System;
using System.Collections.Generic;

namespace _07.ReverseNumber
{
    class Program
    {
        static void Main()
        {
            string n = Console.ReadLine();
            char[] numDigit = n.ToCharArray();
            string result = RevNum(numDigit);
            Console.WriteLine(result);
        }

        static string RevNum(char[] numDigit)
        {
            char[] reversedDigit = new char[numDigit.Length];
            
                for (int i = 0; i < numDigit.Length; i++)
                {
                    reversedDigit[i] = numDigit[numDigit.Length - 1 - i];
                }

            return new string(reversedDigit);
        }

    }
}
