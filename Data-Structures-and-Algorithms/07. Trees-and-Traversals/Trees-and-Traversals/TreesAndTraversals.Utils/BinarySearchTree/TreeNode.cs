using System;

namespace TreesAndTraversals.Utils.BinarySearchTree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
            :this(value, null, null)
        {
        }

        public TreeNode(T value, TreeNode<T> left, TreeNode<T> right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }
    }
}
