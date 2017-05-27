using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class SortableCollection<T> where T : IComparable
    {
        private const string itemNotFoundMessage = "Item not found";

        public static T LinearSearch(List<T> items, Func<T, bool> condition)
        {
            var searchItem = default(T);

            for (int i = 0; i < items.Count; i++)
            {
                if (condition(items[i]))
                {
                    return items[i];
                }
            }

            return searchItem;
        }

        public static string BinarySearch(List<T> items, T searchValue)
        {

            if (items == null || searchValue.Equals(null) || items.Count == 0)
            {
                return itemNotFoundMessage;
            }

            int left = 0;
            int right = items.Count - 1;

            while (left <= right)
            {
                var midIndex = (right + left) / 2;

                if(searchValue.Equals(items[midIndex]))
                {
                    return items[midIndex].ToString();
                }

                if (searchValue.CompareTo(items[midIndex]) < 0)
                {
                    right = midIndex - 1;
                }
                else if (searchValue.CompareTo(items[midIndex]) > 0)
                {
                    left = midIndex + 1;
                }
            }

            return itemNotFoundMessage;
        }
    }
}
