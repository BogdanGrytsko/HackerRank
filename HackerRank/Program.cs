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

    // Complete the findShortest function below.

    /*
     * For the unweighted graph, <name>:
     *
     * 1. The number of nodes is <name>Nodes.
     * 2. The number of edges is <name>Edges.
     * 3. An edge exists between <name>From[i] to <name>To[i].
     *
     */
    static IEnumerable<int> RunBFS(int graphNodes, int[] graphFrom, int[] graphTo, int val)
    {
        var edges = new int[graphFrom.Length][];
        for (int i = 0; i < graphFrom.Length; i++)
        {
            edges[i] = new int[2];
            edges[i][0] = graphFrom[i];
            edges[i][1] = graphTo[i];
        }
        var graph = new Tree(edges, new int[graphNodes]);
        var que = new Queue<int>();
        que.Enqueue(val);
        BFS(graph, que);
        for (int i = 1; i < graph.Nodes.Count; i++)
        {
            var n = graph.Nodes[i];
            if (i == val) continue;
            if (n.Depth == 0)
                yield return -1;
            else
                yield return 6 * n.Depth;
        }
    }

    private static void BFS(Tree graph, Queue<int> queue)
    {
        while (queue.Any())
        {
            var idx = queue.Dequeue();
            var n = graph[idx];
            if (n.Visited) continue;
            n.Visited = true;
            foreach (var edge in n.Edges)
            {
                var eNode = graph[edge];
                if (eNode.Depth == 0)
                    eNode.Depth = n.Depth + 1;
                queue.Enqueue(edge);
            }
        }
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

        var q = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            string[] graphNodesEdges = Console.ReadLine().Split(' ');
            int graphNodes = Convert.ToInt32(graphNodesEdges[0]);
            int graphEdges = Convert.ToInt32(graphNodesEdges[1]);

            int[] graphFrom = new int[graphEdges];
            int[] graphTo = new int[graphEdges];

            for (int j = 0; j < graphEdges; j++)
            {
                var ln = Console.ReadLine();
                string[] graphFromTo = ln.Split(' ');
                graphFrom[j] = Convert.ToInt32(graphFromTo[0]);
                graphTo[j] = Convert.ToInt32(graphFromTo[1]);
            }

            //long[] ids = Array.ConvertAll(Console.ReadLine().Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray(), idsTemp => Convert.ToInt64(idsTemp));
            int val = Convert.ToInt32(Console.ReadLine());

            var ans = RunBFS(graphNodes, graphFrom, graphTo, val);

            textWriter.WriteLine(string.Join(" ", ans));

            textWriter.Flush();
        }

        textWriter.Close();
    }
}
