using System;
using System.Text;

namespace _06.StringLength
{
    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            Console.WriteLine(FillLength(a));
        }

        static string FillLength(string a)
        {
            StringBuilder builder = new StringBuilder();
            a = a.Replace(@"\", string.Empty);
            int difference = 20 - a.Length;

            if (difference != 0)
            {
                builder.Append(a);
                for (int i = 0; i < difference; i++)
                {
                    builder.Append('*');
                }
                string result = builder.ToString();
                return result;
            }

            return a;
        }
    }
}
