using System;
using System.Collections.Generic;
using System.Linq;

namespace TreesAndTraversals.Utils.BinaryHeap
{
    public static class HeapSorter
    {
        public static void HeapSort(this int[] heap, Func<int, int, bool> compareFunc)
        {
            var startIndex = heap.Length / 2 - 1;

            for (int i = startIndex; i >= 0; i--)
            {
                NormalizeLowerHeap(heap, i, heap[i], compareFunc, heap.Length);
            }

            for (int i = heap.Length - 1; i >= 0; i--)
            {
                var value = heap[i];
                heap[i] = heap[0];
                NormalizeLowerHeap(heap, 0, value, compareFunc, i);
            }

            Console.WriteLine(string.Join(" ", heap));
        }

        private static void NormalizeLowerHeap(int[] buffer, int currentIndex, int value, Func<int, int, bool> compareFunc, int length)
        {
            while (currentIndex * 2 + 2 < length)
            {
                var smallerChildIndex = compareFunc(buffer[currentIndex * 2 + 1], buffer[currentIndex * 2 + 2]) ?
                currentIndex * 2 + 1 :
                currentIndex * 2 + 2;

                if (compareFunc(buffer[smallerChildIndex], value))
                {
                    buffer[currentIndex] = buffer[smallerChildIndex];
                    currentIndex = smallerChildIndex;
                }
                else
                {
                    break;
                }
            }

            if (currentIndex * 2 + 1 < length)
            {
                var childIndex = currentIndex * 2 + 1;

                if (compareFunc(buffer[childIndex], value))
                {
                    buffer[currentIndex] = buffer[childIndex];
                    currentIndex = childIndex;
                }
            }

            buffer[currentIndex] = value;
        }
    }
}
