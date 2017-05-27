using System;

namespace _13.QueueImplementation
{
    public class LinkedQueue<T>
    {
        private ListItem<T> firstItem;

        public LinkedQueue()
        {
        }

        public void Enqueue(T item)
        {
            var itemToInsert = new ListItem<T>() { Value = item };

            if (this.firstItem == null)
            {
                this.firstItem = itemToInsert;
            }
            else
            {
                var lastItemInQueue = this.GetLastElement();
                lastItemInQueue.NextItem = itemToInsert;
            }
        }

        public ListItem<T> Dequeue()
        {
            if (this.firstItem == null)
            {
                throw new ArgumentException("No items in list to remove!");
            }
            else
            {
                var itemToRemove = this.firstItem;
                this.firstItem = this.firstItem.NextItem;

                return itemToRemove;
            }
        }

        public ListItem<T> Peek()
        {
            return this.firstItem;
        }

        private ListItem<T> GetLastElement()
        {
            ListItem<T> resultItem = this.firstItem;

            while (resultItem.NextItem != null)
            {
                resultItem = resultItem.NextItem;
            }

            return resultItem;
        }
    }
}
