namespace _01.SchoolClasses.SchoolUnits.UniqueData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class UniqueTextIdentifier
    {
        private static List<string> uText;

        static UniqueTextIdentifier()
        {
            uText = new List<string>();
        }

        public static string GenerateUniqueText()
        {
            Random gen = new Random();
            StringBuilder builder = new StringBuilder();

            while (true)
            {
                builder.Clear();
                for (int i = 0; i < 5; i++)
                {
                    builder.Append((char)(gen.Next(33, 126)));
                }

                if (uText.IndexOf(builder.ToString()) < 0)
                {
                    uText.Add(builder.ToString());
                    return builder.ToString();
                }
            }
        }
    }
}
