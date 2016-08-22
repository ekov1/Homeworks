using System;

namespace _07.SelectionSort
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int smallest = arr[0];

            for (int k = 0; k < arr.Length; k++)
            {
                smallest = arr[k];
                for (int i = k; i < arr.Length; i++)
                {
                    if (arr[i] < smallest)
                    {
                        smallest = arr[i];
                        arr[i] = arr[k];
                        arr[k] = smallest;
                    }
                }
            }
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
