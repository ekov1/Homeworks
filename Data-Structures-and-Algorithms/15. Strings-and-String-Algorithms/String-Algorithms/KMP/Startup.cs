using System;
using System.Collections.Generic;

namespace KMP
{
    public class Startup
    {
        public static void Main()
        {
            var pattern = "abcaby";
            var text = "abxabcabcaby";

            var kmp = new KMP(pattern, text);

            Console.WriteLine(text);
            kmp.SearchInArray(pattern, text);
        }
    }
}
