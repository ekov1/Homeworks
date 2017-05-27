using System;

namespace _13.QueueImplementation
{
    public class Startup
    {
        public static void Main()
        {
            var linkedQueue = new LinkedQueue<string>();
            var firstItem = "TestItem 1";
            var secondItem = "TestItem 2";
            var thirdItem = "TestItem 3";

            linkedQueue.Enqueue(firstItem);
            linkedQueue.Enqueue(secondItem);
            linkedQueue.Enqueue(thirdItem);

            var firstListItem = linkedQueue.Peek();
            Console.WriteLine("First element neightbour --- " + firstListItem.NextItem.Value);

            var removedItem = linkedQueue.Dequeue();
            Console.WriteLine("Removed item --- " + removedItem.Value);
        }
    }
}
