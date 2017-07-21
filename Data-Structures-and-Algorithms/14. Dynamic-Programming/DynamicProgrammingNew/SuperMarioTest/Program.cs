using System;

namespace SuperMarioTest
{
    public class IndexedTree
    {
        private long[] tree;
        private int lastIndex;
        private int arraySize;
        private int leafIndex;

        public IndexedTree(int elementsCount)
        {
            this.leafIndex = 1;

            while (elementsCount > this.leafIndex)
            {
                this.leafIndex *= 2;
            }

            this.tree = new long[this.leafIndex * 2];

            for (int i = 0; i < tree.Length; i++)
            {
                this.tree[i] = long.MaxValue;
            }

            this.lastIndex = 0;
            this.arraySize = elementsCount;
        }

        public long Top
        {
            get
            {
                return this.tree[1];
            }
        }

        public void Push(long value)
        {
            var indexToInsert = this.leafIndex + this.lastIndex;
            ++this.lastIndex;

            if (this.lastIndex == this.arraySize)
            {
                this.lastIndex = 0;
            }

            this.tree[indexToInsert] = value;

            while (indexToInsert > 1)
            {
                tree[indexToInsert / 2] = Math.Min(tree[indexToInsert], tree[indexToInsert ^ 1]);
                indexToInsert /= 2;
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            var strs = Console.ReadLine().Split(' ');
            var n = int.Parse(strs[0]);
            var k = int.Parse(strs[1]);

            if (n < k)
            {
                Console.WriteLine(0);
                return;
            }

            strs = Console.ReadLine().Split(' ');
            var f = long.Parse(strs[0]);
            var a = int.Parse(strs[1]);
            var b = int.Parse(strs[2]);
            var m = int.Parse(strs[3]);

            var tree = new IndexedTree(k);
            tree.Push(f);

            for (int i = 1; i < k; i++)
            {
                f = (f * a + b) % m;
                tree.Push(f);
            }

            for (int i = k; i < n; i++)
            {
                f = (f * a + b) % m;
                var currentValue = tree.Top + f;
                tree.Push(currentValue);
            }

            Console.WriteLine(tree.Top);
        }
    }
}