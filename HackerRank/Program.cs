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

    // Complete the riddle function below.
    static long[] MinMaxWindows(long[] arr)
    {
        //number -> max window size in which its minimum
        var numDic = new Dictionary<long, int>();
        var st = new Stack<int>();
        for (int i = 0; i <= arr.Length; i++)
        {
            var currH = i < arr.Length ? arr[i] : -1;
            var lastH = st.Count > 0 ? arr[st.Peek()] : 0;
            if (lastH < currH)
            {
                st.Push(i);
                continue;
            }

            while (st.Count > 0 && arr[st.Peek()] > currH)
            {
                var pop = st.Pop();
                var longestStreak = i - pop;
                var val = arr[pop];
                if (!numDic.ContainsKey(val))
                    numDic[val] = longestStreak;
                else
                    numDic[val] = Math.Max(numDic[val], longestStreak);

                if (st.Count == 0 || arr[st.Peek()] < currH)
                {
                    arr[pop] = currH;
                    st.Push(pop);
                }
            }
        }
        var invDic = new Dictionary<int, long>();
        foreach (var pair in numDic)
        {
            if (invDic.ContainsKey(pair.Value))
                invDic[pair.Value] = Math.Max(invDic[pair.Value], pair.Key);
            else
                invDic[pair.Value] = pair.Key;
        }
        var res = new long[arr.Length];
        long lastVal = 0;
        for (int i = arr.Length ; i > 0; i--)
        {
            if (invDic.ContainsKey(i))
                lastVal = Math.Max(lastVal, invDic[i]);
            res[i - 1] = lastVal;
        }
        return res;
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
