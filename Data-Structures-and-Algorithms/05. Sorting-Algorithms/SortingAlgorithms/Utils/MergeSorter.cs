using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class MergeSorter
    {
        public static List<int> Sort(List<int> items)
        {
            if (items.Count < 2)
            {
                return items;
            }

            var midIndex = items.Count / 2;
            var left = items.Take(midIndex).ToList();
            var right = items.Skip(midIndex).ToList();

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right); 
        }

        private static List<int> Merge(IList<int> firstList, IList<int> secondList)
        {
            int i = 0,
                j = 0;

            var result = new List<int>();

            while (i < firstList.Count && j < secondList.Count)
            {
                if (firstList[i] <= secondList[j])
                {
                    result.Add(firstList[i]);
                    i++;
                }
                else
                {
                    result.Add(secondList[j]);
                    j++;
                }
            }

            if (i == firstList.Count)
            {
                result.AddRange(secondList.Skip(j));
            }
            else if (j == secondList.Count)
            {
                result.AddRange(firstList.Skip(i));
            }

            return result;
        }
    }
}
