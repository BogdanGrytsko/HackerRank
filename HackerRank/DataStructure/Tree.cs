using System;
using System.Collections.Generic;

namespace HackerRank.DataStructure
{
    public class Tree
    {
        public class TreeNode
        {
            public TreeNode Parent { get; set; }
            public long Sum { get; set; }
            public int Value { get; set; }
            public bool Visited { get; set;}
            public List<int> Edges { get; set; }

            public TreeNode(int val)
            {
                Value = val;
                Sum = val;
                Edges = new List<int>();
            }

            public override string ToString()
            {
                return $"{Value}, {Sum}";
            }
        }

        private readonly List<TreeNode> tree = new List<TreeNode>();

        public Tree(int[][] edges, int[] c)
        {
            //to start numeration from 1
            tree.Add(new TreeNode(-1));
            for (int i = 0; i < c.Length; i++)
                tree.Add(new TreeNode(c[i]));
            foreach (var edge in edges)
            {
                tree[edge[0]].Edges.Add(edge[1]);
                tree[edge[1]].Edges.Add(edge[0]);
            }
        }

        public void ResetVisited()
        {
            foreach (var node in tree)
            {
                node.Visited = false;
            }
        }

        public TreeNode this[int nodeIdx]
        {
            get
            {
                return tree[nodeIdx];
            }
        }

        public long DFSSum(int nodeIdx)
        {
            var node = tree[nodeIdx];
            if (node.Visited)
                return 0;
            node.Visited = true;
            foreach (var edge in node.Edges)
            {
                tree[nodeIdx].Sum += DFSSum(edge);
            }
            return tree[nodeIdx].Sum;
        }
    }
}
