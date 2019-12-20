//using System.CodeDom.Compiler;
//using System.Collections.Generic;
//using System.Collections;
//using System.ComponentModel;
//using System.Diagnostics.CodeAnalysis;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Runtime.Serialization;
//using System.Text.RegularExpressions;
//using System.Text;
//using System;

//class Solution
//{
//    // Complete the balancedForest function below.
//    static long balancedForest(int[] c, int[][] edges)
//    {
//        var tree = new Tree(edges, c);
//        tree.CalcSumsDFS(1);

//        var solutions = new List<long>();
//        var sums = tree.Sums;
//        var max = sums[1];
//        var dic = new Dictionary<long, List<int>>();
//        for (int i = 1; i < sums.Length; i++)
//        {
//            var sum = sums[i];
//            if (!dic.ContainsKey(sum))
//                dic.Add(sum, new List<int> { i });
//            else
//                dic[sum].Add(i);
//        }

//        for (int i = 2; i < sums.Length; i++)
//        {
//            var s1 = sums[i];
//            var sLeft = max - s1;
//            //case when we can split into 2 trees, and just add a "big" node
//            if (s1 == sLeft)
//            {
//                solutions.Add(s1);
//            }
//            //LCA(s1, s3) = 1
//            //s1 == s3
//            if (dic.TryGetValue(s1, out var list1) && list1.Count > 1 && 2 * s1 > sLeft)
//            {
//                solutions.Add(2 * s1 - sLeft);
//            }
//            //s2 == s3
//            if (sLeft % 2 == 0 && dic.TryGetValue(sLeft / 2, out var list3) && sLeft/2 > s1)
//            {
//                foreach (var it in list3)
//                {
//                    if (it != i && tree.LCA(i, it) == 1)
//                    {
//                        solutions.Add(sLeft / 2 - s1);
//                    }
//                }
//            }
//            //s1 == s2
//            var s3 = max - 2 * s1;
//            if (dic.TryGetValue(s3, out var _))
//            {
//                solutions.Add(sLeft - s3);
//            }
//            //LCA(s1, s3) != 1
//            //s1 == s2

//            ////common ancestor.
//            //var ss = max - 2 * s1;
//            //if (ss % 2 == 0 && dic.TryGetValue(ss/2, out var list4) && ss/2 > s1)
//            //{
//            //    foreach (var it in list4)
//            //    {
//            //        if (it != i && tree.LCA(i, it) != 1)
//            //        {
//            //            solutions.Add(ss / 2 - s1);
//            //        }
//            //    }
//            //}
//        }
//        if (solutions.Any())
//            return solutions.Min();
//        return -1;
//    }

//    public class Tree
//    {
//        private readonly List<List<int>> tree = new List<List<int>>();
//        private readonly int[] verticles;
//        private readonly int[] parent;
//        private readonly int[] level;
//        private readonly long[] sums;

//        public Tree(int[][] edges, int[] verticles)
//        {
//            this.verticles = verticles;
//            parent = new int[verticles.Length + 1];
//            sums = new long[verticles.Length + 1];
//            level = new int[verticles.Length + 1];
//            Build(edges);
//        }

//        private void Build(int[][] edges)
//        {
//            for (int i = 0; i <= edges.Length + 1; i++)
//                tree.Add(new List<int>());
//            foreach (var edge in edges)
//            {
//                tree[edge[0]].Add(edge[1]);
//                tree[edge[1]].Add(edge[0]);
//            }
//        }

//        public long CalcSumsDFS(int root)
//        {
//            long sum = verticles[root - 1];
//            foreach (var verticle in tree[root])
//            {
//                if (verticle != parent[root])
//                {
//                    level[verticle] = level[root] + 1;
//                    parent[verticle] = root;
//                    sum += CalcSumsDFS(verticle);
//                }
//            }
//            sums[root] = sum;
//            return sum;
//        }

//        public int LCA(int i, int j)
//        {
//            if (i == j)
//                return i;
//            if (level[i] > level[j])
//                return LCA(parent[i], j);
//            else if (level[j] > level[i])
//                return LCA(i, parent[j]);
//            return LCA(parent[i], parent[j]);
//        }

//        public long[] Sums => sums;
//    }

//    static void Main(string[] args)
//    {
//        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//        int q = Convert.ToInt32(Console.ReadLine());

//        for (int qItr = 0; qItr < q; qItr++)
//        {
//            int n = Convert.ToInt32(Console.ReadLine());

//            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
//            ;

//            int[][] edges = new int[n - 1][];

//            for (int i = 0; i < n - 1; i++)
//            {
//                edges[i] = Array.ConvertAll(Console.ReadLine().Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
//            }

//            var result = balancedForest(c, edges);

//            textWriter.WriteLine(result);
//        }

//        textWriter.Flush();
//        textWriter.Close();
//    }
//}

using HackerRank.Problem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{

    /*
     * Complete the runningMedian function below.
     */
    static double[] runningMedian(int[] a)
    {
        var sol = new RunningMedian();
        return sol.Solve(a).ToArray();
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int aCount = Convert.ToInt32(Console.ReadLine());

        int[] a = new int[aCount];

        for (int aItr = 0; aItr < aCount; aItr++)
        {
            int aItem = Convert.ToInt32(Console.ReadLine());
            a[aItr] = aItem;
        }

        double[] result = runningMedian(a);
        foreach (var item in result)
        {
            textWriter.WriteLine(item.ToString("F1"));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
