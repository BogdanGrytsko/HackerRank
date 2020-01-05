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

    // Complete the minTime function below.
    static long minTime(long[] machines, long goal)
    {
        Array.Sort(machines);
        return minTime(machines, goal, 0, machines[0] * goal);
    }

    static long minTime(long[] machines, long goal, long l, long r)
    {
        var mid = (l + r) / 2;
        long res = -1;
        while (l < r)
        {
            mid = (l + r) / 2;
            var g = CalcResult(machines, mid);
            if (g < goal)
                l = mid + 1;
            else
            {
                res = mid;
                r = mid;
            }
        }
        return res;
    }

    private static long CalcResult(long[] machines, long time)
    {
        long produced = 0;
        foreach (var machine in machines)
        {
            produced += time / machine;
        }
        return produced;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nGoal = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nGoal[0]);

        long goal = Convert.ToInt64(nGoal[1]);

        long[] machines = Array.ConvertAll(Console.ReadLine().Split(' '), machinesTemp => Convert.ToInt64(machinesTemp))
        ;
        long ans = minTime(machines, goal);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
