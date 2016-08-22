using System;

namespace _15.PrimeNumbers
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[] arr = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                arr[i] = true;
            }

            for (int j = 2; j <= n; j++)
            {
                if (arr[j])
                {
                    for (long p = 2; (p * j) <= n; p++)
                    {
                        arr[p * j] = false;
                    }
                }
            }

            int biggest = 0;
            for (int i = n - 1; i >= 2; i--)
            {
                if (arr[i] == true)
                {
                    biggest = i;
                    break;
                }
            }
            Console.WriteLine(biggest);
        }
    }
}
