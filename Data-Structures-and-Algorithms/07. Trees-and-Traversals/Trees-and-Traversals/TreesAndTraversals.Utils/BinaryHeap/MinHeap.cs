﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndTraversals.Utils.BinaryHeap
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private Func<T, T, bool> compareFunc;
        private List<T> buffer;

        public MinHeap()
            :this((a, b) => a.CompareTo(b) < 0)
        {
        }

        public MinHeap(Func<T, T, bool> cmpFunc)
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
            while (currentIndex * 2 + 1 < this.Count)
            {
                var smallerChildIndex = compareFunc(this.buffer[currentIndex * 2], this.buffer[currentIndex * 2 + 1]) ?
                currentIndex * 2 :
                currentIndex * 2 + 1;

                if (compareFunc(this.buffer[smallerChildIndex], value))
                {
                    this.buffer[currentIndex] = this.buffer[smallerChildIndex];
                    currentIndex = smallerChildIndex;
                }
            }

            if (currentIndex * 2 < this.Count)
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
