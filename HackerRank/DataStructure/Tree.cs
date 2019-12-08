using System;
using System.Collections.Generic;

namespace HackerRank.DataStructure
{
    public class Tree
    {
        private readonly List<List<int>> tree = new List<List<int>>();
        private readonly int[] verticles;
        private readonly int[] parent;
        private readonly long[] sums;

        public Tree(int[][] edges, int[] verticles)
        {
            this.verticles = verticles;
            parent = new int[verticles.Length + 1];
            sums = new long[verticles.Length + 1];
            Build(edges);
        }

        private void Build(int[][] edges)
        {
            for (int i = 0; i <= edges.Length + 1; i++)
                tree.Add(new List<int>());
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]);
                tree[edge[1]].Add(edge[0]);
            }
        }

        public long CalcSumsDFS(int root)
        {
            long sum = verticles[root - 1];
            foreach (var verticle in tree[root])
            {
                if (verticle != parent[root])
                {
                    parent[verticle] = root;
                    sum += CalcSumsDFS(verticle);
                }
            }
            sums[root] = sum;
            return sum;
        }

        public long[] Sums => sums;
    }
}
