using HackerRank.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Problem
{
    public class CrazyHelix
    {
        private int reverseCnt;

        public IEnumerable<string> Solve(int n, int[][] queries)
        {
            var treap = new ImplicitTreap(n);
            for (int i = 1; i <= n; i++)
            {
                treap.Add(i);
            }
            foreach (var query in queries)
            {
                if (query[0] == 1)
                {
                    var start = query[1] - 1;
                    var end = query[2] - 1;
                    treap.Reverse(start, end);
                    reverseCnt++;
                }
                if (query[0] == 2)
                {
                    var elem = query[1];
                    var pos = GetIdx(treap, elem, reverseCnt) + 1;
                    yield return $"element {elem} is at position {pos}";
                }
                if (query[0] == 3)
                {
                    var pos = query[1] - 1;
                    var elem = treap[pos];
                    yield return $"element at position {pos} is {elem}";
                }
            }
        }

        public static int GetIdx(ImplicitTreap treap, int elem, int revCnt)
        {
            //todo : improve this, introduce caching.
            long idx = elem - 1;
            for (int i = 0; i < revCnt; i++)
            {
                idx = treap[(int)idx] - 1;
            }
            return (int)idx;
        }
    }
}
