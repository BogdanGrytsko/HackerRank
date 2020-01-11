using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the reverseShuffleMerge function below.
    static IEnumerable<int> TaleOfTwoStacks(int[][] queries)
    {
        var st1 = new Stack<int>();
        var st2 = new Stack<int>();
        foreach (var query in queries)
        {
            if (query[0] == 1)
            {
                st1.Push(query[1]);
            }
            else if (query[0] == 2)
            {
                if (!st2.Any())
                {
                    while (st1.Any())
                    {
                        st2.Push(st1.Pop());
                    }
                }
                st2.Pop();
            }
            else if (query[0] == 3)
            {
                if (!st2.Any())
                {
                    while (st1.Any())
                    {
                        st2.Push(st1.Pop());
                    }
                }
                yield return st2.Peek();
            }
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nq = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nq[0]);

        int[][] queries = new int[n][];

        for (int queriesRowItr = 0; queriesRowItr < n; queriesRowItr++)
        {
            queries[queriesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        var result = TaleOfTwoStacks(queries).ToArray();

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
