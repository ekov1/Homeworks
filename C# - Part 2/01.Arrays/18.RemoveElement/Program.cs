using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RemoveElementsFromArray
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int[] size = new int[n];
        int max = 1;
        for (int i = 0; i < size.Length; i++)
        {
            size[i] = 1;
        }

        for (int i = 1; i < numbers.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (numbers[i] >= numbers[j] && size[i] <= size[j] + 1)
                {
                    size[i] = size[j] + 1;
                    if (size[i] > max)
                    {
                        max = size[i];
                    }
                }
            }
        }

        Console.WriteLine(n - max);
    }

    
}