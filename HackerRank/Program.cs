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
        var tree = new Tree(edges, c);
        tree.CalcSumsDFS(1);

        var solutions = new List<long>();
        var s = tree.Sums;
        var max = s[1];
        for (int i = 1; i < s.Length; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                var s1 = s[i];
                var s2 = s[j];
                var s3 = max - s1 - s2;
                if (s1 == s2 && s3 < s1)
                    solutions.Add(s1 - s3);
                if (s1 == s3 && s2 < s1)
                    solutions.Add(s1 - s2);
                if (s3 == s2 && s1 < s2)
                    solutions.Add(s2 - s1);
            }
        }
        if (solutions.Any())
            return solutions.Min();
        return -1;
    }

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
