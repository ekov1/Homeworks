namespace Statistics.Utils
{
    using System;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
