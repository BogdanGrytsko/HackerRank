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

    // Complete the roadsAndLibraries function below.
    static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] cities)
    {
        if (c_lib <= c_road)
            return (long)c_lib * n;
        long cost = 0;
        var graph = new Tree(cities, new int[n]);
        for (int i = 1; i < graph.Nodes.Count; i++)
        {
            var node = graph.Nodes[i];
            if (node.Visited) continue;
            var cnt = graph.DFSCount(i);
            cost += (cnt - 1) * c_road + c_lib;
        }
        return cost;
    }

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

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] nmC_libC_road = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nmC_libC_road[0]);

            int m = Convert.ToInt32(nmC_libC_road[1]);

            int c_lib = Convert.ToInt32(nmC_libC_road[2]);

            int c_road = Convert.ToInt32(nmC_libC_road[3]);

            int[][] cities = new int[m][];

            for (int i = 0; i < m; i++)
            {
                cities[i] = Array.ConvertAll(Console.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));
            }

            long result = roadsAndLibraries(n, c_lib, c_road, cities);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
