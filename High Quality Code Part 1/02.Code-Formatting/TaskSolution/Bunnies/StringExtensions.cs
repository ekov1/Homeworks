namespace Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class StringExtensions
    {
        public static string SplitToSeparateWordsByUppercaseLetter(this string sequence)
        {
            var stringMargin = 10;
            var stringSize = sequence.Length + stringMargin;
            var builder = new StringBuilder(stringSize);
            var whitespace = ' ';

            foreach (var letter in sequence)
            {
                if (char.IsUpper(letter))
                {
                    builder.Append(whitespace);
                }

                builder.Append(letter);
            }

            return builder.ToString().Trim();
        }
    }
}
