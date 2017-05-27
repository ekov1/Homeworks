using System.Collections.Generic;

namespace Utils
{
    public static class SelectionSorter
    {
        public static void Sort(IList<int> items)
        {
            int currentIndex = int.MinValue;
            int smallestindex = 0;

            for (int i = 0; i < items.Count; i++)
            {
                smallestindex = i;

                for (int j = i; j < items.Count; j++)
                {
                    currentIndex = j;

                    if (items[currentIndex] < items[smallestindex])
                    {
                        smallestindex = currentIndex;
                    }
                }

                ArrayInteraction<int>.SwapValues(items, i, smallestindex);
            }
        }
    }
}
