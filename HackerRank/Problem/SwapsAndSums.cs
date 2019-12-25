using HackerRank.DataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static HackerRank.DataStructure.ImplicitTreap;

namespace HackerRank.Problem
{
    public class SwapsAndSums
    {
        public static IEnumerable<long> Solve(int[] a, IEnumerable<int[]> queries)
        {
            var treapCount = 2;
            var treaps = new ImplicitTreap[treapCount];
            for (int i = 0; i < treapCount; i++)
                treaps[i] = new ImplicitTreap(100000);
            for (int i = 0; i < a.Length; i++)
                treaps[i % treapCount].Add(a[i]);
            foreach (var query in queries)
            {
                var l = query[1] - 1;
                var r = query[2] - 1;
                var t = query[0];

                var ql = new int[treapCount];
                var qr = new int[treapCount];
                for (int i = 0; i < treapCount; i++)
                {
                    if (l == r && l % 2 != i)
                    {
                        ql[i] = 0;
                        qr[i] = -1;
                    }
                    else
                    {
                        ql[i] = (l % 2 == i) ? l / 2 : (l + 1) / 2;
                        qr[i] = (r % 2 == i) ? r / 2 : (r - 1) / 2;
                    }
                }

                if (t == 1)
                    TSwap(ref treaps[0], ql[0], qr[0], ref treaps[1], ql[1], qr[1]);
                else
                {
                    long ans = 0;
                    for (int i = 0; i < treapCount; i++)
                    {
                        if (ql[i] <= qr[i])
                            ans += treaps[i].Sum(ql[i], qr[i]);
                    }
                    yield return ans;
                }
            }
        }

        public static void TSwap(ref ImplicitTreap t1, int l1, int r1, ref ImplicitTreap t2, int l2, int r2)
        {
            TreapNode p1 = null, p2 = null, p3 = null, q1 = null, q2 = null, q3 = null;
            Split(t1.Root, r1 + 1, ref p2, ref p3);
            Split(p2, l1, ref p1, ref p2);

            Split(t2.Root, r2 + 1, ref q2, ref q3);
            Split(q2, l2, ref q1, ref q2);

            t1.Root = Merge(p1, Merge(q2, p3));
            t2.Root = Merge(q1, Merge(p2, q3));
        }


        public void Main()
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nq = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nq[0]);

            int q = Convert.ToInt32(nq[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            int[][] queries = new int[q][];

            for (int queriesRowItr = 0; queriesRowItr < q; queriesRowItr++)
            {
                queries[queriesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            }

            var result = Solve(a, queries).ToArray();

            textWriter.WriteLine(string.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
