using System;
using System.Collections.Generic;
using System.Linq;

namespace Aho_Corasik
{
    public class Startup
    {
        public static void Main()
        {
            var trie = new Trie();
            trie.AddString("gosho");
            trie.Dfs();
        }
    }
}
