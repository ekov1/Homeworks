using System;

namespace _01.ReverseString
{
    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            char[] b = new char[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[a.Length - 1 - i];
            }
            foreach (var item in b)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
