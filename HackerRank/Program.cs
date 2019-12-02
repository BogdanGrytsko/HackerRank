using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    public class RMQSparseTable
    {
        private readonly List<int> elems;
        //M[i][j] is the index of the minimum value in the sub array starting at i having length 2^j.
        private readonly int[][] M;
        private readonly Func<int, int, bool> compare;

        private RMQSparseTable(IEnumerable<int> elems, Func<int, int, bool> compare)
        {
            this.elems = elems.ToList();
            M = new int[this.elems.Count][];
            this.compare = compare;
            PreProcess();
        }

        public RMQSparseTable(IEnumerable<int> elems)
            : this(elems, (a, b) => a <= b)
        {
        }

        public RMQSparseTable(IEnumerable<int> elems, bool max)
         : this(elems, (a, b) => a >= b)
        {
        }

        private void PreProcess()
        {
            var logN = (int)Math.Ceiling(Math.Log(elems.Count, 2));
            for (int i = 0; i < elems.Count; i++)
            {
                if (M[i] == null)
                    M[i] = new int[logN];
                M[i][0] = i;
            }
            for (int j = 1; j < logN; j++)
            {
                var pow = (int)Math.Pow(2, j - 1);
                for (int i = 0; i + pow < elems.Count; i++)
                {
                    var idx1 = M[i][j - 1];
                    var idx2 = M[i + pow][j - 1];
                    if (compare(elems[idx1], elems[idx2]))
                        M[i][j] = idx1;
                    else
                        M[i][j] = idx2;
                }
            }
        }

        public int MinIdx(int i, int j)
        {
            var k = (int)Math.Floor(Math.Log(j - i + 1, 2));
            var idx1 = M[i][k];
            var idx2 = M[j - (int)Math.Pow(2, k) + 1][k];
            if (compare(elems[idx1], elems[idx2]))
                return idx1;
            return idx2;
        }

        public int MinElem(int i, int j)
        {
            return elems[MinIdx(i, j)];
        }
    }

    // Complete the solve function below.
    static IEnumerable<int> solve(int[] arr, int[] queries)
    {
        var rmq = new RMQSparseTable(arr, true);
        foreach (var d in queries)
        {
            var list = new List<int>();
            for (int i = 0; i + d - 1 < arr.Length; i++)
            {
                list.Add(rmq.MinElem(i, i + d - 1));
            }
            yield return list.Min();
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nq = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nq[0]);

        int q = Convert.ToInt32(nq[1]);

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;

        int[] queries = new int[q];

        for (int queriesItr = 0; queriesItr < q; queriesItr++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[queriesItr] = queriesItem;
        }

        int[] result = solve(arr, queries).ToArray();

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
