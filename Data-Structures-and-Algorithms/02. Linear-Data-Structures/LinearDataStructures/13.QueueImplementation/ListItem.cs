using System;

namespace _13.QueueImplementation
{
    public class ListItem<T>
    {
        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }
    }
}
