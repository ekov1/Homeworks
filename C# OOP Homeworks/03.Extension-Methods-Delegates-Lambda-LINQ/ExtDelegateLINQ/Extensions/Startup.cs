namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    

    class Startup
    {
        static void Main()
        {
            //Problem 1. StringBuilder.Substring

            StringBuilder builder = new StringBuilder();
            builder.Append("teststring");

            var testSubstring = builder.Substring(1, 4);
            Console.WriteLine(testSubstring);

            //Problem 2. IEnumerable extensions

            IEnumerable<int> result = from value in Enumerable.Range(0, 5)
                                      select value;

            Console.WriteLine(IEnumerableExtensions.Print(result));

            Console.WriteLine(result.MySum());
            Console.WriteLine(result.MyProduct());
            Console.WriteLine(result.MyMin());
            Console.WriteLine(result.MyMax());
            Console.WriteLine(result.MyAverage());
        }
    }
}
