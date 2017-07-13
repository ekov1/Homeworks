using System.Collections.Generic;

namespace _01.EdgesCount
{
    public class Graph
    {
        private int[][] nodes;
        private HashSet<int> visited;

        public Graph(int[][] nodes)
        {
            this.nodes = nodes;
            this.visited = new HashSet<int>();
        }

        public HashSet<int> Visited
        {
            get
            {
                return this.visited;
            }
        }

        public int NodesCount
        {
            get
            {
                return this.nodes.Length;
            }
        }

        public void Dfs(int node)
        {
            for (int i = 0; i < this.nodes[node].Length; i++)
            {
                if (this.nodes[node][i] == 1 && !this.visited.Contains(i))
                {
                    this.visited.Add(i);
                    this.Dfs(i);
                }
            }
        }

        public void Bfs(int node)
        {
            var q = new Queue<int>();
            q.Enqueue(node);
            this.visited.Add(node);

            while (q.Count != 0)
            {
                var currentNode = q.Dequeue();

                for (int i = 0; i < this.NodesCount; i++)
                {
                    if (this.nodes[currentNode][i] == 1 && !this.visited.Contains(i))
                    {
                        q.Enqueue(i);
                        this.visited.Add(i);
                    }
                }
            }
        }
    }
}
