using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    // Complete the balancedForest function below.
    static long balancedForest(int[] c, int[][] edges)
    {
        var sol = new BalancedForest();
        return sol.Solve(c, edges);
    }

    public class Tree
    {
        public class TreeNode
        {
            public TreeNode Parent { get; set; }
            public long Sum { get; set; }
            public int Value { get; set; }
            public bool Visited { get; set; }
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
            sum = ans = tree.DFSSum(1);
            tree.ResetVisited();
            Solve(1);
            return ans == sum ? -1 : ans;
        }

        private void Solve(int nodeIdx)
        {
            var node = tree[nodeIdx];
            if (node.Visited)
                return;
            node.Visited = true;
            var x = new List<long> { node.Sum * 2, sum * 2 - node.Sum * 4, sum - node.Sum };
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

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
            ;

            int[][] edges = new int[n - 1][];

            for (int i = 0; i < n - 1; i++)
            {
                edges[i] = Array.ConvertAll(Console.ReadLine().Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
            }

            var result = balancedForest(c, edges);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}