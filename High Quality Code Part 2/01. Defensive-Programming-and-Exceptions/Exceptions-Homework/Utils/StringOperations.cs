namespace Exceptions_Homework.Utils
{
    using System;
    using System.Text;

    public static class StringOperations
    {
        public static string ExtractEnding(string initialString, int count)
        {
            if (count > initialString.Length)
            {
                throw new ArgumentException("Count cannot be greater than the string length!");
            }

            StringBuilder result = new StringBuilder();
            var startIndex = initialString.Length - count;

            for (int i = startIndex; i < initialString.Length; i++)
            {
                result.Append(initialString[i]);
            }

            return result.ToString();
        }
    }
}
