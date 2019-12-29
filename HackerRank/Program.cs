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

    // Complete the minimumSwaps function below.
    static int minimumSwaps(int[] a)
    {
        var swaps = 0;
        var dic = new Dictionary<int, int>();
        for (int i = 0; i < a.Length; i++)
        {
            dic[a[i]] = i;
        }
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] - i == 1) continue;
            var swapPos = dic[i + 1];
            var tmp = a[swapPos];
            a[swapPos] = a[i];
            a[i] = tmp;

            dic[a[i]] = i;
            dic[a[swapPos]] = swapPos;
            swaps++;
        }
        return swaps;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = minimumSwaps(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
