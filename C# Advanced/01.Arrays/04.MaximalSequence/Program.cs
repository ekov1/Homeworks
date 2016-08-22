using System;

namespace _04.MaximalSequence
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int counter = 1;
            int bestCnt = 0;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            int first = array[0];

            for (int j = 1; j < array.Length - 1; j++)
            {
                if (first < array[j + 1])
                {
                    counter++;
                    if (counter > bestCnt)
                    {
                        bestCnt = counter;
                    }
                }
                else if (first >= array[j + 1])
                {
                    counter = 1;
                }
                first = array[j + 1];
            }
            Console.WriteLine(bestCnt);
        }
    }
}
