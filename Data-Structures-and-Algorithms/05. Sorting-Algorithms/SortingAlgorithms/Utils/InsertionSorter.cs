using System.Collections.Generic;

namespace Utils
{
    public class InsertionSorter
    {
        public static void Sort(IList<int> items)
        {
            for (int i =  1; i < items.Count; i++)
            {
                int j = i;

                while (j > 0 && items[j - 1] > items[j])
                {
                        ArrayInteraction<int>.SwapValues(items, j - 1, j);

                    j--;
                }
            }
        }
    }
}
