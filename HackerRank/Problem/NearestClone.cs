using HackerRank.DataStructure;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Problem
{
    public class NearestClone
    {
        public static int findShortest(int graphNodes, int[] graphFrom, int[] graphTo, long[] ids, int val)
        {
            var edges = new int[graphFrom.Length][];
            for (int i = 0; i < graphFrom.Length; i++)
            {
                edges[i] = new int[2];
                edges[i][0] = graphFrom[i];
                edges[i][1] = graphTo[i];
            }
            var graph = new Tree(edges, ids.Select(i => (int)i).ToArray());
            var start = new List<(int, int)>();
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                if (graph.Nodes[i].Value == val)
                    start.Add((i, i));
            }
            return BFS(graph, new Queue<(int, int)>(start));
        }

        private static int BFS(Tree graph, Queue<(int idx, int col)> queue)
        {
            while (queue.Any())
            {
                var (idx, col) = queue.Dequeue();
                var n = graph[idx];
                if (n.Visited) continue;
                n.Visited = true;
                n.Value = col;
                foreach (var edge in n.Edges)
                {
                    var eNode = graph[edge];
                    if (eNode.Visited && eNode.Value != n.Value)
                    {
                        return eNode.Depth + n.Depth;
                    }
                    eNode.Depth = n.Depth + 1;
                    queue.Enqueue((edge, col));
                }
            }
            return -1;
        }
    }
}
