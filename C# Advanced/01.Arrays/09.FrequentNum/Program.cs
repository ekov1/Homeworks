using System;

namespace _09.FrequentNum
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

            int counter = 1;
            int bestCounter = 0;
            int bestNum = 0;
            Array.Sort(arr);
            int first = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (first == arr[i])
                {
                    counter++;
                    if (counter > bestCounter)
                    {
                        bestCounter = counter;
                        bestNum = arr[i];
                    }
                }
                else if(first != arr[i])
                {
                    counter = 1;
                }
                first = arr[i];
            }
            Console.WriteLine("{0} ({1} times)", bestNum, bestCounter);
        }
    }
}
