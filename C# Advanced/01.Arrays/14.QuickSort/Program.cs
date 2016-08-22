using System;

class QuickSort
{
    public static int partition(int[] arr, int left, int right)
    {
        int i = left;
        int j = right;
        int tmp;
        int pivot = arr[(left + right) / 2];
        while (i <= j)
        {
            while (arr[i] < pivot)
            {
                i++;
            }
            while (arr[j] > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
                i++;
                j--;
            }
        }
        return i;
    }

    public static void quickSort(int[] arr, int left, int right)
    {
        int index = partition(arr, left, right);
        if (left < index - 1)
        {
            quickSort(arr, left, index - 1);
        }
        if (index < right)
        {
            quickSort(arr, index, right);
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] toSort = new int[n];
        for (int i = 0; i < n; i++)
        {
            toSort[i] = int.Parse(Console.ReadLine());
        }

        quickSort(toSort, 0, toSort.Length - 1);

        foreach (int a in toSort)
        {
            Console.WriteLine(a);
        }
    }
}