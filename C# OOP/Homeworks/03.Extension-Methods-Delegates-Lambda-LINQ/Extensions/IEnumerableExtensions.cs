namespace Extensions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static decimal MySum<T>(this IEnumerable<T> groupOfItems)
        {
            var result = groupOfItems
                .Select(x => Convert.ToDecimal(x))
                .Sum();

            return result;
        }

        public static decimal MyProduct<T>(this IEnumerable<T> groupOfItems) 
        {
            decimal result = 0;
            var decimalList = groupOfItems
                .Select(x => Convert.ToDecimal(x))
                .ToList();

            foreach (var item in decimalList)
            {
                result *= item;
            }

            return result;
        }

        public static decimal MyMin<T>(this IEnumerable<T> groupOfItems)
        {
            var result = groupOfItems
                .Select(x => Convert.ToDecimal(x))
                .Min();

            return result;
        }

        public static decimal MyMax<T>(this IEnumerable<T> groupOfItems)
        {
            var result = groupOfItems
                .Select(x => Convert.ToDecimal(x))
                .Max();

            return result;
        }

        public static decimal MyAverage<T>(this IEnumerable<T> groupOfItems)
        {
            var result = groupOfItems
                   .Select(x => Convert.ToDecimal(x))
                   .Average();

            return result;

        }

        public static string Print<T>(IEnumerable<T> genericGroup)
        {
            return string.Join(" ", genericGroup);
        }
    }
}
