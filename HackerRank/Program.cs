using HackerRank.Problem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    public static IEnumerable<string> Solve(int n, int[][] queries)
    {
        var sol = new CrazyHelix();
        return sol.Solve(n, queries);
    }

    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nq = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nq[0]);

        int q = Convert.ToInt32(nq[1]);

        int[][] queries = new int[q][];

        for (int queriesRowItr = 0; queriesRowItr < q; queriesRowItr++)
        {
            queries[queriesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        var result = Solve(n, queries).ToArray();

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}

