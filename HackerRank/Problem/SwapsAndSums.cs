using HackerRank.DataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank.Problem
{
    public class SwapsAndSums
    {
        public static IEnumerable<long> Solve(int[] a, IEnumerable<int[]> queries)
        {
            var treapCount = 2;
            var treaps = new Treap[treapCount];
            for (int i = 0; i < treapCount; i++)
                treaps[i] = new Treap(100000);
            for (int i = 0; i < a.Length; i++)
                treaps[i % treapCount].Append(a[i]);
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
                    Treap.TSwap(ref treaps[0], ql[0], qr[0], ref treaps[1], ql[1], qr[1]);
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

        public void Main()
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nq = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nq[0]);

            int q = Convert.ToInt32(nq[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))            ;

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
