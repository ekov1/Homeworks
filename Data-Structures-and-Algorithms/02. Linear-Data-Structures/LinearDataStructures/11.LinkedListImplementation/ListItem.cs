using System;

namespace _11.LinkedListImplementation
{
    public class ListItem<T>
    {
        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }
    }
}
