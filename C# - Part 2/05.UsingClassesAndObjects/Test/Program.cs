using System;

namespace Test
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[] vector = new int[number];
            GetVector(number - 1, vector, 0);
        }
        static void GetVector(int index, int[] vector, int start)       
        {
            if (index == - 1)
            {
                Print(vector);
            }
            else
            {
                for (int i = start; i <= 9; i++)
                {
                    vector[index] = i;
                    GetVector(index - 1, vector, i + 1);
                }
            }
        }

        static void Print(int[] vector)
        {
            foreach (var item in vector)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
