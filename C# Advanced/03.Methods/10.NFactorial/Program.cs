using System;
using System.Numerics;

namespace _10.NFactorial
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger result = CalcFactorial(n);
            Console.WriteLine(result);
        }
        static BigInteger CalcFactorial(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
            BigInteger sum = 1;
            for (int i = 0; i < n; i++)
            {
                sum = sum * arr[i];
            }
            return sum;
        }
    }
}
