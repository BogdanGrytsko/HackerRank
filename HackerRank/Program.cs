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
using HackerRank.Algorithm;

class Solution
{

    // Complete the riddle function below.
    static long[] MinMaxWindows(long[] arr)
    {
        //number -> max window size in which its minimum
        var numDic = new Dictionary<long, int>();
        var st = new Stack<long>();
        for (int i = 0; i < arr.Length; i++)
        {
            var el = arr[i];
            if (!st.Any() || st.Peek() <= el)
            {
                st.Push(el);
                continue;
            }

            UpdateCntDic(numDic, st, el);
            st.Push(el);
        }
        UpdateCntDic(numDic, st, -1);
        var invDic = new Dictionary<int, long>();
        foreach (var pair in numDic)
        {
            if (invDic.ContainsKey(pair.Value))
                invDic[pair.Value] = Math.Max(invDic[pair.Value], pair.Key);
            else
                invDic[pair.Value] = pair.Key;
        }
        var res = new long[arr.Length];
        for (int i = arr.Length ; i > 0; i--)
        {
            if (invDic.ContainsKey(i))
                res[i - 1] = invDic[i];
            else
                res[i - 1] = res[i];
        }
        return res;
    }

    private static void UpdateCntDic(Dictionary<long, int> numDic, Stack<long> st, long el)
    {
        var cnt = 1;
        while (st.Count > 0 && st.Peek() >= el)
        {
            var pop = st.Pop();
            if (st.Count == 0)
            {

            }
            if (!numDic.ContainsKey(pop))
                numDic[pop] = cnt;
            else
                numDic[pop] = Math.Max(numDic[pop], cnt);
            cnt++;
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt64(arrTemp))
        ;
        var res = MinMaxWindows(arr);

        textWriter.WriteLine(string.Join(" ", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
