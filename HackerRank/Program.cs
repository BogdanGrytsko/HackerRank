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
    private static IEnumerable<char> GetTextEditor(List<Tuple<int, string>> queries)
    {
        var st = new Stack<Tuple<int, string>>();
        var list = new List<char>(queries.Count);
        queries.Reverse();
        foreach (var q in queries)
        {
            st.Push(q);
        }
        var opStack = new Stack<Tuple<int, string>>();
        while (st.Any())
        {
            var query = st.Pop();
            if (query.Item1 == 1)
            {
                list.AddRange(query.Item2);
                opStack.Push(Tuple.Create(6, query.Item2.Length.ToString()));
            }
            else if (query.Item1 == 2)
            {
                var c = int.Parse(query.Item2);
                var removed = list.GetRange(list.Count - c, c).ToArray();
                list.RemoveRange(list.Count - c, c);
                var str = new string(removed);
                opStack.Push(Tuple.Create(5, str));
            }
            else if (query.Item1 == 3)
            {
                var idx = int.Parse(query.Item2) - 1;
                yield return list[idx];
            }
            else if (query.Item1 == 4)
            {
                var q = opStack.Pop();
                st.Push(q);
            }
            else if (query.Item1 == 5)
            {
                list.AddRange(query.Item2);
            }
            else if (query.Item1 == 6)
            {
                var c = int.Parse(query.Item2);
                list.RemoveRange(list.Count - c, c);
            }
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nq = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nq[0]);

        var queries = new List<Tuple<int, string>>();

        for (int queriesRowItr = 0; queriesRowItr < n; queriesRowItr++)
        {
            var line = Console.ReadLine().Split(' ');
            if (line.Length > 1)
                queries.Add(Tuple.Create(int.Parse(line[0]), line[1]));
            else
                queries.Add(Tuple.Create(int.Parse(line[0]), string.Empty));
        }

        var result = GetTextEditor(queries);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
