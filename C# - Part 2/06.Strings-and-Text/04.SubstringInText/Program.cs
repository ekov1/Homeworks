using System;

namespace _04.SubstringInText
{
    class Program
    {
        static void Main()
        {
            string pattern = Console.ReadLine();
            string main = Console.ReadLine();

            SearchingInString(pattern, main);
        }

        static void SearchingInString(string pattern, string main)
        {
            int counter = 0;
            string sub = "";
            pattern = pattern.ToLower();
            main = main.ToLower();
            for (int i = 0; i < main.Length; i++)
            {
                if ((i + pattern.Length) <= main.Length)
                {
                    sub = main.Substring(i, pattern.Length);
                }
                if (sub == pattern)
                {
                    counter++;
                }
                sub = "";
            }
            Console.WriteLine(counter);
        }
    }
}
