namespace _03.CompareSortAlgorithms.Models
{
    using System;

    /// <summary>
    /// NOTE: Those algorithms are from internet
    /// </summary>
    public class SortingAlgorithms
    {
        public static void InsertionSort<T>(T[] arrToSort)
            where T : IComparable<T>
        {
            for (int i = 1; i < arrToSort.Length; i++)
            {
                T elNow = arrToSort[i];
                int j = i - 1;

                while (j >= 0 && arrToSort[j].CompareTo(elNow) > 0)
                {
                    SwapElements(arrToSort, j + 1, j);
                    j--;
                    elNow = arrToSort[j + 1];
                }
            }
        }

        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minElIndex = i;
                T minEl = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(minEl) < 0)
                    {
                        minElIndex = j;
                        minEl = arr[j];
                    }
                }

                SwapElements(arr, i, minElIndex);
            }
        }

        public static void QuickSort<T>(T[] elements, int left, int right)
            where T : IComparable<T>
        {
            int i = left, j = right;
            T pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(elements, left, j);
            }

            if (i < right)
            {
                QuickSort(elements, i, right);
            }
        }

        private static void SwapElements<T>(T[] arrToSwap, int firstIndex, int secondIndex)
           where T : IComparable<T>
        {
            T elAtFirstIndex = arrToSwap[firstIndex];
            arrToSwap[firstIndex] = arrToSwap[secondIndex];
            arrToSwap[secondIndex] = elAtFirstIndex;
        }
    }
}
