namespace Exceptions_Homework.Utils
{
    using System;
    using System.Collections.Generic;

    public static class MathOperations
    {
        public static bool IsPrime(int number)
        {
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static T[] GetSubsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array cannot be null!");
            }

            if (count < 0 || count > arr.Length)
            {
                throw new ArgumentException("Count cannot be less than 0 or greater than the array length!");
            }

            if (startIndex < 0 || startIndex >= arr.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            var endIndex = startIndex + count;
            if (endIndex > arr.Length)
            {
                throw new ArgumentOutOfRangeException("endIndex");
            }

            List<T> resultSequence = new List<T>();
            for (int i = startIndex; i < endIndex; i++)
            {
                resultSequence.Add(arr[i]);
            }

            return resultSequence.ToArray();
        }
    }
}
