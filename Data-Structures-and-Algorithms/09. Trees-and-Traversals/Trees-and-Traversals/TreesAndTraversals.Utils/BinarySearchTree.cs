using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndTraversals.Utils
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public T Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }

        private int size;

        private Node root;

        public BinarySearchTree()
        {
            this.root = null;
            this.size = 0;
        }

        public T Add(Node node, T value)
        {

        }
    }
}
