namespace GenericTypes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class GenericList<T> where T : IComparable<T>
    {
        private int nextIndex;
        private T[] data;

        public GenericList(int initCapacity)
        {
            nextIndex = 0;
            this.data = new T[initCapacity];
        }

        public void AddElement(T item)
        {
            this.data[nextIndex++] = item;

            if (this.nextIndex == this.data.Length)
            {
                AutoGrow();
            }
        }

        public T this[int index]
        {
            get { return this.data[index]; }
            private set { this.data[index] = value; }
        }

        public void Clear()
        {
            this.data = new T[this.data.Length];
        }

        public void RemoveAtIndex(int index)
        {
            for (int i = index; i < this.nextIndex && i < this.data.Length - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }
            this.nextIndex--;
            this.data[nextIndex] = default(T);
        }

        public void Insert(int index, T item)
        {
            if (this.nextIndex == this.data.Length)
            {
                AutoGrow();
            }

            for (int i = this.nextIndex; i > 0 && i >= index; i--)
            {
                this.data[i] = this.data[i - 1];
            }
            this.data[index] = item;
            this.nextIndex++;
        }

        public void AutoGrow()
        {
            int capacity = this.data.Length;
            Array.Resize<T>(ref this.data, capacity * 2);
        }

        public T Min()
        {
            if (this.nextIndex == 0)
            {
                throw new ArgumentException("No elements in the list to display!");
            }

            T smallest = this.data[0];
            foreach (var item in this.data)
            {
                if (smallest.CompareTo(item) > 0)
                {
                    smallest = item;
                }
            }
            return smallest;
        }

        public T Max()
        {
            if (this.nextIndex == 0)
            {
                throw new ArgumentException("No elements in the list to display!");
            }

            T biggest = this.data[0];
            foreach (var item in this.data)
            {
                if (biggest.CompareTo(item) < 0)
                {
                    biggest = item;
                }
            }
            return biggest;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < this.nextIndex; i++)
            {
                builder.Append(this.data[i]);
                if (i < this.nextIndex - 1)
                {
                    builder.Append(", ");
                }
            }
            return builder.ToString();
        }
    }
}
