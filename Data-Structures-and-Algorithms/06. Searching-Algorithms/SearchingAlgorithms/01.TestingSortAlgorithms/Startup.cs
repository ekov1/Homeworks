using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace _01.TestingSortAlgorithms
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = Enumerable.Range(0, 100).ToList();

            TestBinarySearch(numbers);

            CollectionShuffler<int>.Shuffle(numbers);

            TestLinearSearch(numbers);
        }

        private static void TestLinearSearch(List<int> numbers)
        {
            var condition = new Func<int, bool>(x => x == 5);

            var searchItem = SortableCollection<int>.LinearSearch(numbers, condition);

            Console.WriteLine("Linear search item => " + searchItem);
        }

        private static void TestBinarySearch(List<int> numbers)
        {
            var binarySearchItem = SortableCollection<int>.BinarySearch(numbers, 101);

            Console.WriteLine("Binary search item => " + binarySearchItem);
        }
    }
}
