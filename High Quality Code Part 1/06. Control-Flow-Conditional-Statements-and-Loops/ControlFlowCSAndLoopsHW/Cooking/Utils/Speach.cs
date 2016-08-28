namespace Cooking.Utils
{
    using System;
    using Contracts;

    public class Speach : ITalkable
    {
        public void Say(string words)
        {
            Console.WriteLine(words);
        }
    }
}
