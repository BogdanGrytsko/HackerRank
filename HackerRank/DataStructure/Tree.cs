using System.Collections.Generic;
using System.Linq;

namespace HackerRank.DataStructure
{
    public class Tree
    {
        public class Node
        {
            public int ParentIdx { get; set; }
            public long Sum { get; set; }
            public int Value { get; set; }
            public bool Visited { get; set; }
            public int Depth { get; set; }
            public int HeavyIdx { get; set; }
            public int HeadIdx { get; set; }
            public int PosIdx { get; set; }
            public List<int> Edges { get; set; }

            public int Count { get; set; }

            public Node(int val)
            {
                Value = val;
                Sum = val;
                Edges = new List<int>();
                HeavyIdx = -1;
                Count = 1;
            }

            public override string ToString()
            {
                return $"V: {Value}, S: {Sum}, C: {Count}, E: {Edges.Count}";
            }
        }

        public Tree(int[][] edges, int[] c)
        {
            //to start numeration from 1
            Nodes.Add(new Node(-1));
            for (int i = 0; i < c.Length; i++)
                Nodes.Add(new Node(c[i]));
            foreach (var edge in edges)
            {
                Nodes[edge[0]].Edges.Add(edge[1]);
                Nodes[edge[1]].Edges.Add(edge[0]);
            }
            RootIdx = 1;
        }

        public Tree(IEnumerable<Node> nodes, int rootIdx)
        {
            RootIdx = rootIdx;
            Nodes = nodes.ToList();
        }

        public int RootIdx { get; private set; }

        public void ResetVisited()
        {
            foreach (var node in Nodes)
            {
                node.Visited = false;
            }
        }

        public List<Node> Nodes { get; } = new List<Node>();

        public Node this[int nodeIdx]
        {
            get
            {
                return Nodes[nodeIdx];
            }
        }

        public long DFSSum(int nodeIdx)
        {
            var node = Nodes[nodeIdx];
            if (node.Visited)
                return 0;
            node.Visited = true;
            foreach (var edge in node.Edges)
                node.Sum += DFSSum(edge);
            return node.Sum;
        }

        public int DFSCount(int nodeIdx)
        {
            var node = Nodes[nodeIdx];
            if (node.Visited)
                return 0;
            node.Visited = true;
            foreach (var edge in node.Edges)
                node.Count += DFSCount(edge);
            return node.Count;
        }
    }
}
