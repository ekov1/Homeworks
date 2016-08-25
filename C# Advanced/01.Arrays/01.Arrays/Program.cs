using System;

namespace _01.Arrays
{
    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();


            char[] first = a.ToCharArray();
            char[] second = b.ToCharArray();
            int min = Math.Min(first.Length, second.Length);

            for (int i = 0; i < min; i++)
            {
                if ((int)first[i] > (int)second[i])
                {
                    Console.WriteLine(">");

                    Environment.Exit(0);
                }
                else if ((int)first[i] < (int)second[i])
                {
                    Console.WriteLine("<");

                    Environment.Exit(0);
                }
            }
            if (first.Length == second.Length)
            {
                Console.WriteLine("=");
            }

            else if (first.Length < second.Length)
            {
                Console.WriteLine("<");
            }
            else if (second.Length < first.Length)
            {
                Console.WriteLine(">");
            }
        }
    }
}

