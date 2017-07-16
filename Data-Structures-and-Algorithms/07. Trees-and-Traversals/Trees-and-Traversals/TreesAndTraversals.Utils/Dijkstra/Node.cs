using System;

namespace TreesAndTraversals.Utils.Dijkstra
{
    public class Node : IComparable<Node>
    {
        public int Vertex;
        public int Weight;

        public Node(int vertex, int weight)
        {
            this.Vertex = vertex;
            this.Weight = weight;
        }

        public int CompareTo(Node other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
}
