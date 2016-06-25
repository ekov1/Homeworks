using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.SeriesOfLetters
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            ConsecLetters(input);
        }
        static void ConsecLetters(string input)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(input[0]);
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] != input[i + 1])
                {
                    builder.Append(input[i + 1]);
                }

            }
            Console.WriteLine(builder.ToString());
        }

    }
}
