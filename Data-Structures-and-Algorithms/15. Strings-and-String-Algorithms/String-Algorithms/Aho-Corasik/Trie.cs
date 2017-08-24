using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aho_Corasik
{
    public class Trie
    {
        private Dictionary<char, Trie> children;
        private string pattern;
        public Trie()
        {
            this.children = new Dictionary<char, Trie>();
            this.pattern = null;
        }

        public void AddString(string input)
        {
            var currentNode = this;

            foreach (var ch in input)
            {
                if (!currentNode.children.ContainsKey(ch))
                {
                    currentNode.children[ch] = new Trie();
                }

                currentNode = currentNode.children[ch];
            }

            currentNode.pattern = input;
        }

        public void Dfs()
        {
            Dfs("");
        }

        private void Dfs(string node)
        {
            if (this.pattern != null)
            {
                Console.WriteLine(this.pattern);
            }

            foreach (var child in this.children)
            {
                child.Value.Dfs(node + child.Key);
            }
        }
    }
}
