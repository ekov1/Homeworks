using System;

namespace _03.EnglishDigit
{
    class Program
    {
        static void Main()
        {
            string n = Console.ReadLine();
            string result = EnglishDigit(n);
            Console.WriteLine(result);
        }

        static string EnglishDigit(string n )
        {
            string digit = n.Substring(n.Length -1, 1);
            string res = "";
            switch (digit)
            {
                case "0": res = "zero"; break;
                case "1": res = "one"; break;
                case "2": res = "two"; break;
                case "3": res = "three"; break;
                case "4": res = "four"; break;
                case "5": res = "five"; break;
                case "6": res = "six"; break;
                case "7": res = "seven"; break;
                case "8": res = "eight"; break;
                case "9": res = "nine"; break;
                default:
                    break;
            }
            return res;
        }
    }
}
