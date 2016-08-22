using System;

namespace _11.BinarySearch
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

            int x = int.Parse(Console.ReadLine());
            int min = 0;
            int max = arr.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (min == max && x != arr[mid])
                {
                    Console.WriteLine("-1");
                    break;
                }
                else if (x == arr[mid])
                {
                    Console.WriteLine(mid);
                    break;
                }
                else if (x < arr[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }


        }
    }
}
