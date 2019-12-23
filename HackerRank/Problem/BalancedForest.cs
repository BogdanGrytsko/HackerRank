using HackerRank.DataStructure;
using System.Collections.Generic;

namespace HackerRank.Problem
{
    public class BalancedForest
    {
        private Tree tree;
        private readonly HashSet<long> s, q;
        private long ans, sum;

        public BalancedForest()
        {
            s = new HashSet<long>();
            q = new HashSet<long>();
        }

        public long Solve(int[] c, int[][] edges)
        {
            tree = new Tree(edges, c);
            sum = ans = tree.DFSSum(tree.RootIdx);
            tree.ResetVisited();
            Solve(tree.RootIdx);
            return ans == sum ? -1 : ans;
        }

        private void Solve(int nodeIdx)
        {
            var node = tree[nodeIdx];
            if (node.Visited) 
                return;
            node.Visited = true;
            var x = new List<long> { node.Sum * 2, sum * 2 - node.Sum*4, sum - node.Sum };
            var y = new List<long> { 3 * node.Sum - sum, x[2] / 2 - node.Sum };
            var length = x[2] % 2 == 1 ? 2 : 3;
            for (int i = 0; i < length; i++)
            {
                if (s.Contains(x[i] / 2) || q.Contains((x[0] + x[i]) / 2))
                    ans = Min(ans, y[i / 2]);
            }
            q.Add(node.Sum);
            for (int i = 0; i < node.Edges.Count; i++)
                Solve(node.Edges[i]);
            q.Remove(node.Sum);
            s.Add(node.Sum);
        }

        private static long Min(long x, long y)
        {
            return y >= 0 ? (x < y ? x : y) : x;
        }
    }
}
