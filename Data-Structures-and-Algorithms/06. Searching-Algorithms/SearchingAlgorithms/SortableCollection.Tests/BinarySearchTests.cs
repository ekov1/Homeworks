namespace SortableCollection.Tests
{
    using NUnit.Framework;
    using Utils;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public static void BinarySearch_ShouldReturnNoItemFoundMessage_WhenEmptyListIsPassed()
        {
            // Arrange
            var notFoundMessage = "Item not found";
            var searchValue = 24;
            var emptyList = new List<int>();

            // Act
            var result = SortableCollection<int>.BinarySearch(emptyList, searchValue);

            // Assert
            Assert.AreEqual(notFoundMessage, result);
        }

        [Test]
        public static void BinarySearch_ShouldReturnNoItemFoundMessage_WhenNullListIsPassed()
        {
            // Arrange
            var notFoundMessage = "Item not found";
            var searchValue = 24;

            // Act
            var result = SortableCollection<int>.BinarySearch(null, searchValue);

            // Assert
            Assert.AreEqual(notFoundMessage, result);
        }

        [Test]
        public static void BinarySearch_ShouldReturnElement_WhenValidListIsPassed()
        {
            // Arrange
            var searchValue = 3;
            var list = Enumerable.Range(1, 500).ToList();

            // Act
            var result = SortableCollection<int>.BinarySearch(list, searchValue);

            // Assert
            Assert.AreEqual(searchValue.ToString(), result);
        }
    }
}
