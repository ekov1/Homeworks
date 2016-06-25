using System;
using System.Linq;
using System.Text;

namespace _12.ParsingURL
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            GettingResource(input);
        }

        static void GettingResource(string input)
        {
            int indexOfDots = input.IndexOf(':', 0);
            string protocol = input.Substring(0, indexOfDots);

            int indexOfSlashes = input.IndexOf("//", indexOfDots);
            int indexOfContent = input.IndexOf('/', indexOfSlashes + 2);
            string server = input.Substring(indexOfSlashes + 2, indexOfContent - indexOfSlashes - 2);
            string content = input.Substring(indexOfContent, input.Length - indexOfContent);

            Console.WriteLine("[protocol] = {0}", protocol);
            Console.WriteLine("[server] = {0}", server);
            Console.WriteLine("[resource] = {0}", content);

        }
    }
}
