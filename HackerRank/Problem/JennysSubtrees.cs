using HackerRank.DataStructure;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Problem
{
    public class JennysSubtrees
    {
        public static int Solve(int n, int r, int[][] edges)
        {
            var treeDic = new Dictionary<int, List<Tree>>();
            var tree = new Tree(edges, new int[n]);
            tree.DFSCount(tree.RootIdx);
            for (int i = tree.RootIdx; i < tree.Nodes.Count; i++)
            {
                tree.ResetVisited();
                var subTree = GetSubTree(tree, i, r);
                var cnt = subTree.DFSCount(i);
                if (!treeDic.ContainsKey(cnt))
                    treeDic.Add(cnt, new List<Tree> { subTree });
                else
                {
                    var isoWithAny = false;
                    foreach (var originalTree in treeDic[cnt])
                    {
                        originalTree.ResetVisited();
                        subTree.ResetVisited();
                        isoWithAny = isoWithAny || Isomorphic(subTree, subTree.RootIdx, originalTree, originalTree.RootIdx);
                    }
                    if (!isoWithAny)
                        treeDic[cnt].Add(subTree);
                }
            }
            return treeDic.Values.Sum(t => t.Count);
        }

        private static bool Isomorphic(Tree tree1, int idx1, Tree tree2, int idx2)
        {
            var iso = true;
            var node1 = tree1.Nodes[idx1];
            var node2 = tree2.Nodes[idx2];
            if (node1.Visited || node2.Visited)
                return iso;
            node1.Visited = node2.Visited = true;
            if (node1.Count != node2.Count || node1.Edges.Count != node2.Edges.Count)
                return false;
            var sorted1 = node1.Edges.OrderBy(e => tree1[e].Count).ToList();
            var sorted2 = node2.Edges.OrderBy(e => tree2[e].Count).ToList();
            for (int i = 0; i < node1.Edges.Count; i++)
            {
                var edge1 = sorted1[i];
                var edge2 = sorted2[i];
                iso = iso && Isomorphic(tree1, edge1, tree2, edge2);
            }
            return iso;
        }

        private static Tree GetSubTree(Tree original, int idx, int r)
        {
            var nodes = original.Nodes.Select(n => new Tree.Node(n.Value));
            var newTree = new Tree(nodes, idx);
            PopulateEdges(original, newTree, idx, r);
            return newTree;
        }

        private static void PopulateEdges(Tree originalTree, Tree newTree, int idx, int r)
        {
            var node = originalTree[idx];
            node.Visited = true;
            foreach (var edge in node.Edges)
            {
                if (originalTree[edge].Visited)
                {
                    newTree[idx].Edges.Add(edge);
                    continue;
                }
                if (r <= 0) continue;
                newTree[idx].Edges.Add(edge);
                PopulateEdges(originalTree, newTree, edge, r - 1);
            }
        }
    }
}
