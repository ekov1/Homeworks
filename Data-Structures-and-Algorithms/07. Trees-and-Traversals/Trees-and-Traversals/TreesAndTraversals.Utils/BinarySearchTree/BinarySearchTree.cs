using System;

namespace TreesAndTraversals.Utils.BinarySearchTree
{
    public class BinarySearchTree<T>
        where T : IComparable
    {
        public TreeNode<T> Root { get; set; }

        public BinarySearchTree(T value)
        {
            this.Root = new TreeNode<T>(value);
        }

        public void Insert(T value)
        {
            var placeToInsert = FindPlace(this.Root, value);

            if (placeToInsert != null)
            {
                if (value.CompareTo(placeToInsert.Value) > 0)
                {
                    placeToInsert.Right = new TreeNode<T>(value);
                }
                else
                {
                    placeToInsert.Left = new TreeNode<T>(value);
                }
            }
        }

        public TreeNode<T> FindPlace(TreeNode<T> node, T valueToIsert)
        {
            if (valueToIsert.CompareTo(node.Value) > 0 && node.Right != null)
            {
                return FindPlace(node.Right, valueToIsert);
            }
            else if (valueToIsert.CompareTo(node.Value) < 0 && node.Left != null)
            {
                return FindPlace(node.Left, valueToIsert);
            }

            if (node.Left == null || node.Right == null)
            {
                return node;
            }
            else
            {
                return null;
            }
        }
    }
}
