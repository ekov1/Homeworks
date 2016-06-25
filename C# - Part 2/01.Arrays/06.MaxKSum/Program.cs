using System;

namespace _06.MaxKSum
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int sum = 0;
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            for (int i = arr.Length - 1; i > arr.Length - 1- k; i--)
            {
                sum += arr[i];
            }
            Console.WriteLine(sum);
        }
    }
}
