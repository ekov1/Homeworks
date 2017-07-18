using Huffman_Compression.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using TreesAndTraversals.Utils.BinaryHeap;

namespace Huffman_Compression
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var charAppearance = new Dictionary<char, int>();

            foreach (var ch in input)
            {
                if (!charAppearance.ContainsKey(ch))
                {
                    charAppearance[ch] = 1;
                }
                else
                {
                    charAppearance[ch]++;
                }
            }

            var queue = new PriorityQueue<Tuple<int, HuffmanTree>>((a, b) => a.Item1 < b.Item1);

            foreach (var item in charAppearance)
            {
                queue.Enqueue(new Tuple<int, HuffmanTree>(
                    item.Value,
                    new HuffmanTree(item.Key)
                    ));
            }

            while (queue.Count > 1)
            {
                var first = queue.Dequeue();
                var second = queue.Dequeue();

                queue.Enqueue(new Tuple<int, HuffmanTree>(
                    first.Item1 + second.Item1,
                    new HuffmanTree(first.Item2, second.Item2)
                    ));
            }

            var root = queue.Dequeue().Item2;

            root.Dfs();
        }
    }
}
