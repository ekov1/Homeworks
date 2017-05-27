using System;

namespace _11.LinkedListImplementation
{
    public class Startup
    {
        public static void Main()
        {
            var thirdItem = new ListItem<string>() { Value = "Third test item" };
            var secondItem = new ListItem<string>() { Value = "Second test item", NextItem = thirdItem };
            var firstItem = new ListItem<string>() { Value = "First test item", NextItem = secondItem };
            var linkedList = new LinkedList<string>() { FirstItem = firstItem };

            var currentItem = linkedList.FirstItem;

            while (true)
            {
                if (currentItem == null)
                {
                    break;
                }

                Console.WriteLine(currentItem.Value);
                currentItem = currentItem.NextItem;
            }
        }
    }
}
