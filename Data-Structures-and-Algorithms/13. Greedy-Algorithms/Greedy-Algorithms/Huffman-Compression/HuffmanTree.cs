using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Compression
{
    public class HuffmanTree
    {
        private char? value;
        private HuffmanTree left;
        private HuffmanTree right;

        public HuffmanTree(char value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }

        public HuffmanTree(HuffmanTree left, HuffmanTree right)
        {
            this.value = null;
            this.left = left;
            this.right = right;
        }

        public void Dfs()
        {
            this.Dfs("");
        }

        private void Dfs(string result)
        {
            if (this.value.HasValue)
            {
                Console.WriteLine($"{this.value.Value} - {result}");
                return;
            }

            this.left.Dfs(result + "0");
            this.right.Dfs(result + "1");
        }
    }
}
