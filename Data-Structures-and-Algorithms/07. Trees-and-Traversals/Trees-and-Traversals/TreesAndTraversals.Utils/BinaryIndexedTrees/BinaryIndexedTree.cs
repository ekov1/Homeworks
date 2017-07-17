using System;

namespace TreesAndTraversals.Utils.BinaryIndexedTrees
{
    public class BinaryIndexedTree<T>
    {
        private int leavesCount;
        private T[] buffer;
        private Func<T, T, T> combineFunc;

        public BinaryIndexedTree(int elementCount, Func<T, T, T> func)
        {
            this.combineFunc = func;
            this.leavesCount = 1;

            while (this.leavesCount < elementCount)
            {
                this.leavesCount *= 2;
            }

            this.buffer = new T[this.leavesCount * 2];
        }

        public T this[int index]
        {
            get
            {
                return this.buffer[this.leavesCount + index];
            }
            set
            {
                var updateIndex = this.leavesCount + index;
                this.buffer[updateIndex] = value;

                while (updateIndex > 1)
                {
                    UpdateIndex(updateIndex);
                    updateIndex /= 2;
                }
            }
        }

        private void UpdateIndex(int index)
        {
            this.buffer[index / 2] = combineFunc(this.buffer[index], this.buffer[index ^ 1]);
        }

        public T GetInterval(int initialLeft, int initialRight)
        {
            return this.GetInterval(initialLeft, initialRight, 1, 0, this.leavesCount);
        }

        private T GetInterval(int initialLeft, int initialRight, int currentIndex, int leftBound, int rightBound)
        {
            if (leftBound == initialLeft && rightBound == initialRight)
            {
                return this.buffer[currentIndex];
            }

            int middleNode = (leftBound + rightBound) / 2;

            if (initialRight <= middleNode)
            {
                return this.GetInterval(initialLeft, initialRight, currentIndex * 2, leftBound, middleNode);
            }

            if (initialLeft >= middleNode)
            {
                return this.GetInterval(initialLeft, initialRight, currentIndex * 2 + 1, middleNode, rightBound);
            }

            return this.combineFunc(
                this.GetInterval(initialLeft, middleNode, currentIndex * 2, leftBound, middleNode),
                this.GetInterval(middleNode, initialRight, currentIndex * 2 + 1, middleNode, rightBound)
                );
        }
    }
}
