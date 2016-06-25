using System;

namespace _03.Methods
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            PrintName(name);
        }

        static void PrintName(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
