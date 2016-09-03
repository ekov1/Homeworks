namespace Methods.Utils
{
    using System;
    using System.Collections.Generic;

    public static class ConsoleWriter
    {
        public static void Write(string text)
        {
            Console.WriteLine(text);
        }

        public static void Write(double number)
        {
            Console.WriteLine(number);
        }

        public static void FormatPrintNumber(object number, char formatType)
        {
            var formatTypes = new Dictionary<char, string>()
            {
                { 'f', "{0:f2}" },
                { '%', "{0:p0}" },
                { 'r', "{0,8}" }
            };
            var textFormat = formatTypes[formatType];

            Console.WriteLine(textFormat, number);
        }
    }
}
