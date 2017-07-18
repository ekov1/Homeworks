using System;
using System.Collections.Generic;

namespace TreesAndTraversals.Utils.PriorityQueue
{
    public class PriorityQueue<T>
    {
        private Func<T, T, bool> compareFunc;
        private List<T> buffer;

        public PriorityQueue(Func<T, T, bool> cmpFunc)
        {
            this.compareFunc = cmpFunc;
            this.buffer = new List<T>() { default(T) };
        }

        public T Top => this.buffer[1];

        public int Count => this.buffer.Count - 1;

        public void Enqueue(T value)
        {
            this.buffer.Add(value);
            var index = this.Count;

            while (index > 1 && compareFunc(value, buffer[index / 2]))
            {
                buffer[index] = buffer[index / 2];
                index = index / 2;
            }

            buffer[index] = value;
        }

        public T Dequeue()
        {
            var min = this.Top;
            var endElement = this.buffer[this.Count];
            this.buffer.RemoveAt(this.Count);

            if (this.Count > 0)
            {
                this.NormalizeLowerHeap(1, endElement);
            }

            return min;
        }

        private void NormalizeLowerHeap(int currentIndex, T value)
        {
            while (currentIndex * 2 + 1 < this.buffer.Count)
            {
                var smallerChildIndex = compareFunc(this.buffer[currentIndex * 2], this.buffer[currentIndex * 2 + 1]) ?
                currentIndex * 2 :
                currentIndex * 2 + 1;

                if (compareFunc(this.buffer[smallerChildIndex], value))
                {
                    this.buffer[currentIndex] = this.buffer[smallerChildIndex];
                    currentIndex = smallerChildIndex;
                }
                else
                {
                    break;
                }
            }

            if (currentIndex * 2 < this.buffer.Count)
            {
                var childIndex = currentIndex * 2;

                if (compareFunc(this.buffer[childIndex], value))
                {
                    this.buffer[currentIndex] = this.buffer[childIndex];
                    currentIndex = childIndex;
                }
            }

            this.buffer[currentIndex] = value;
        }
    }
}
