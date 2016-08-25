using System;

class MergeSortAlgorithm
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        int[] temp = new int[numbers.Length];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        MergeSort(numbers, temp, 0, numbers.Length - 1);

        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }

    static void MergeSort(int[] array, int[] tmp, int start, int end)
    {
        // Array with 1 element
        if (start >= end) return;

        // Define a middle of the array
        int middle = start + (end - start) / 2;

        MergeSort(array, tmp, start, middle);
        MergeSort(array, tmp, middle + 1, end);

        CompareAndSort(array, tmp, start, middle, end);
    }

    static void CompareAndSort(int[] array, int[] tmp, int start, int middle, int end)
    {
        int left_tmp = start, left_arr = start, middle_arr = middle + 1;

        while (left_arr <= middle && middle_arr <= end)
        {
            if (array[left_arr] > array[middle_arr])
            {
                tmp[left_tmp++] = array[middle_arr++];
            }
            else
            {
                tmp[left_tmp++] = array[left_arr++];
            }
        }

        while (left_arr <= middle)
            tmp[left_tmp++] = array[left_arr++];

        while (middle_arr <= end)
            tmp[left_tmp++] = array[middle_arr++];

        for (int i = start; i <= end; i++)
            array[i] = tmp[i];
    }
}