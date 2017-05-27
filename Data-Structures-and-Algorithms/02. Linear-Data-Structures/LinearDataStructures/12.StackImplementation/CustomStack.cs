using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.StackImplementation
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 1;
        private T[] buffer;
        private int capacity;
        private int insertIndex;

        public CustomStack()
        {
            this.capacity = InitialCapacity;
            this.insertIndex = -1;
            this.buffer = new T[this.capacity];
        }

        public CustomStack(int length)
        {
            this.buffer = new T[length];
            this.insertIndex = -1;
            this.capacity = length;
        }

        public void Push(T element)
        {
            this.insertIndex++;

            if (this.Count + 1 > capacity)
            {
                this.capacity = this.capacity == 1 ? 4 : (2 * this.capacity);
                var newArray = new T[this.capacity];

                Array.Copy(this.buffer, 0, newArray, this.capacity - 1, this.Count);
                this.buffer = newArray;
            }

            var insertIndex = this.capacity - 1 - this.Count;
            this.buffer[insertIndex] = element;
        }

        public T Pop()
        {
            if (this.insertIndex < 0)
            {
                throw new ArgumentException("No elements to delete in stack!");
            }
            else
            {
                this.insertIndex--;
                return this.buffer[this.insertIndex + 1];

                //var elementToRemove = this.buffer[0];

                //var newArray = new T[this.Count];
                //Array.Copy(this.buffer, 0, newArray, 0, newArray.Length);

                //this.buffer = newArray;

                //return elementToRemove;
            }
        }

        public int Count
        {
            get
            {
                return this.insertIndex + 1;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
