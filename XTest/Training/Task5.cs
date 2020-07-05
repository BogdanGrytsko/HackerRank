using System.Collections.Generic;
using Xunit;

namespace XTest.Training
{
    public class Task5
    {
        [Fact]
        public void Test()
        {
            var graph = new List<List<int>>
            {
                new List<int>{1, 3},
                new List<int> {3, 2},
                new List<int> {1, 2},
                new List<int> {8, 1},
                new List<int> {8, 10},
                new List<int> {18, 20},
                new List<int> {18, 21},
                new List<int> {22, 23},
            };
            Assert.Equal(5, Connections(graph, 1, 24));
        }

        private class Node
        {
            public Node()
            {
                Edges = new List<Node>();
            }

            public int Value { get; set; }
            public List<Node> Edges { get; set; }

            public override string ToString()
            {
                return $"{Value}, {Edges.Count}";
            }
        }

        public int Connections(List<List<int>> graph, int person, int cnt)
        {
            var nodes = new List<Node>();
            for (int i = 0; i < cnt; i++)
            {
                nodes.Add(new Node {Value = i});
            }

            foreach (var edge in graph)
            {
                nodes[edge[0]].Edges.Add(nodes[edge[1]]);
                nodes[edge[1]].Edges.Add(nodes[edge[0]]);
            }

            var start = nodes[person];
            var queue = new Queue<Node>();
            var traversed = new HashSet<Node>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var it = queue.Dequeue();
                traversed.Add(it);
                foreach (var edge in it.Edges)
                {
                    if (!traversed.Contains(edge))
                        queue.Enqueue(edge);
                }
            }
            return traversed.Count;
        }
    }
}