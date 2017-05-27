namespace XMLProcessing.Utils
{
    using System;
    using Contracts;

    public class ConsoleReader : IReader
    {
        public void ReadLine()
        {
            Console.ReadLine();
        }
    }
}
