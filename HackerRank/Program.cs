using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static int jennysSubtrees(int n, int r, int[][] edges)
    {
        return -1;
    }

    public class Tree
    {
        public class Node
        {
            public Node Parent { get; set; }
            public long Sum { get; set; }
            public int Value { get; set; }
            public bool Visited { get; set; }
            public List<int> Edges { get; set; }

            public int Count { get; set; }

            public Node(int val)
            {
                Value = val;
                Sum = val;
                Edges = new List<int>();
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

        string[] nr = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        int r = Convert.ToInt32(nr[1]);

        int[][] edges = new int[n - 1][];

        for (int edgesRowItr = 0; edgesRowItr < n - 1; edgesRowItr++)
        {
            edges[edgesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), edgesTemp => Convert.ToInt32(edgesTemp));
        }

        int result = jennysSubtrees(n, r, edges);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
