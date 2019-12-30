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

    // Complete the countTriplets function below.
    static long countTriplets(List<long> arr, long r)
    {
        long triplets = 0;
        var dupletDic = new Dictionary<long, long>();
        var tripletDic = new Dictionary<long, long>();
        foreach (var it in arr)
        {
            var dupKey = it / r;
            if (tripletDic.TryGetValue(dupKey, out var dupCnt) && it % r == 0)
                triplets += dupCnt;
            if (dupletDic.TryGetValue(dupKey, out var cnt) && it % r == 0)
                AddToDic(tripletDic, it, cnt);
            AddToDic(dupletDic, it);
        }
        return triplets;
    }

    public static void AddToDic<TKey>(IDictionary<TKey, long> dic, TKey key, long val = 1)
    {
        if (dic.ContainsKey(key))
            dic[key] += val;
        else
            dic[key] = val;
    }

    static void Main(string[] args)
    {
        //ReadFromFile();
        //return;
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }

    public static void ReadFromFile()
    {
        var path = Environment.GetEnvironmentVariable("OUTPUT_PATH");
        TextWriter textWriter = new StreamWriter(path, true);

        var lines = File.ReadAllLines(path.Replace("Results", "Input"));
        string[] nr = lines[0].TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = lines[1].TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
