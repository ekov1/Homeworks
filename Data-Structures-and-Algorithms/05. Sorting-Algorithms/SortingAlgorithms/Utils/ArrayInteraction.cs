using System.Collections.Generic;

namespace Utils
{
    public static class ArrayInteraction<T>
    {
        public static void SwapValues(IList<T> collection, int firstIndex, int secondIndex)
        {
            var temp = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temp;
        }
    }
}
