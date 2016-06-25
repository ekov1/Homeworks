using System;

namespace _08.BinaryShort
{
    class Program
    {
        static void Main()
        {
            short number = short.Parse(Console.ReadLine());
            string a = Convert.ToString(number, 2).PadLeft(16, '0');
            Console.WriteLine(a);
        }


       

            
    }

}
