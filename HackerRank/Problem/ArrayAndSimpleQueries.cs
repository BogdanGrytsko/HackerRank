using HackerRank.DataStructure;
using System.Collections.Generic;
using System.Linq;
using static HackerRank.DataStructure.ImplicitTreap;

namespace HackerRank.Problem
{
    public class ArrayAndSimpleQueries
    {
        public List<int> Solve(IEnumerable<int> a, int[][] queries)
        {
            var treap = new ImplicitTreap(a.Count());
            foreach (var it in a)
            {
                treap.Add(it);
            }
            foreach (var query in queries)
            {
                var l = query[1] - 1;
                var r = query[2] - 1;
                TreapNode p1 = null, p2 = null, p3 = null;
                Split(treap.Root, r + 1, ref p2, ref p3);
                Split(p2, l, ref p1, ref p2);
                if (query[0] == 1)
                {
                    treap.Root = Merge(p2, Merge(p1, p3));
                }
                else
                {
                    treap.Root = Merge(p1, Merge(p3, p2));
                }
            }
            return treap.ToList();
        }
    }
}
