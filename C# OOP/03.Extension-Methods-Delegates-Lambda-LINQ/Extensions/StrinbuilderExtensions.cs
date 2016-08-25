namespace Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class StrinbuilderExtensions
    {
        public static string Substring(this StringBuilder builder, int index, int lenght)
        {
            var result = builder.ToString().Substring(index, lenght);
            return result;
        }
    }
}
