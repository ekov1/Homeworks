namespace Utils
{
    using System;
    using System.Collections.Generic;

    public class CollectionShuffler<T>
    {

        // Complexity of the algorithm is N ( linear )
        public static void Shuffle(List<T> items)
        {
            var random = new Random();

            for (int i = 0; i < items.Count; i++)
            {
                var randomIndex = random.Next(i, items.Count);

                SwapValues(items, i, randomIndex);
            }
        }

        private static void SwapValues(List<T> collection, int firstIndex, int secondIndex)
        {
            var temp = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temp;
        }
    }
}
