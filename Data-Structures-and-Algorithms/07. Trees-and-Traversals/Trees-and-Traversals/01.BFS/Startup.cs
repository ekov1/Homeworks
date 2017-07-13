using System;
using System.Collections.Generic;
using TreesAndTraversals.Utils.BinaryHeap;
using TreesAndTraversals.Utils.BinarySearchTree;

namespace _01.BFS
{
    public class Startup
    {
        public static void Main()
        {
            //BinaryTreeTraversals();
            //BinaryHeapOperations();

            var array = new int[] { 4, 6, 2, 1, 0, 9 };

            array.HeapSort((a, b) => a > b);
        }

        private static void BinaryHeapOperations()
        {
            var heap = new BinaryHeap<int>((a, b) => a > b);
            heap.Insert(3);
            heap.Insert(20);
            heap.Insert(1);
            heap.Insert(0);

            Console.WriteLine("Before removing min: " + heap.Min);
            heap.RemoveMin();
            Console.WriteLine("After removing min: " + heap.Min);
        }

        private static void BinaryTreeTraversals()
        {
            var binarySearchTree = new BinarySearchTree<int>(5);
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                binarySearchTree.Insert(random.Next(100));
            }

            Dfs(binarySearchTree.Root);
        }

        public static void Dfs(TreeNode<int> node)
        {
            if (node == null)
            {
                return;
            }

            Dfs(node.Left);
            Console.WriteLine(node.Value);
            Dfs(node.Right);
        }

        public static void Bfs(TreeNode<int> node)
        {
            var queue = new Queue<TreeNode<int>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var x = queue.Dequeue();
                Console.WriteLine(x.Value);

                if (x.Left != null)
                {
                    queue.Enqueue(x.Left);
                }

                if (x.Right != null)
                {
                    queue.Enqueue(x.Right);
                }
            }
        }
    }
}
