using System.Collections.Generic;
using System.Threading.Tasks;

namespace Utils
{
    public class QuickSorter
    {
        public static List<int> Sort(List<int> items, bool insertionSortOptimization = false, bool isAsync = false)
        {
            if (items.Count < 2)
            {
                return items;
            }

            if (items.Count <= 30 && insertionSortOptimization)
            {
                InsertionSorter.Sort(items);
            }

            var pivotIndex = items.Count / 2;
            var pivot = items[pivotIndex];

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < items.Count; i++)
            {
                if (pivotIndex == i)
                {
                    continue;
                }

                if (items[i] < pivot)
                {
                    left.Add(items[i]);
                }
                else
                {
                    right.Add(items[i]);
                }
            }

            List<int> result = new List<int>();
            var sortedLeft = new List<int>();
            var sortedRight = new List<int>();

            if (isAsync)
            {
                Task leftTask = Task.Run(() => sortedLeft = Sort(left));
                Task rightTask = Task.Run(() => sortedRight = Sort(right));
                Task.WaitAll(leftTask, rightTask);
            }
            else
            {
                sortedLeft = Sort(left);
                sortedRight = Sort(right);
            }

            result.AddRange(sortedLeft);
            result.Add(pivot);
            result.AddRange(sortedRight);

            return result;
        }
    }
}
